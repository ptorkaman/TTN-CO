﻿using AutoMapper;
using Common.Exceptions;
using Domain;
using DTO;
using DTO.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository;
using SmsIrRestfulNetCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserMenuRepository _userMenuRepository;
        private readonly SiteSettings _siteSetting;
        private readonly IMapper _mapper;
        public UserService(IRepository<Person> personRepository, IUserRepository userRepository, IOptionsSnapshot<SiteSettings> settings, IUserMenuRepository userMenuRepository, IMapper mapper)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _userRepository = userRepository;
            _siteSetting = settings.Value;
            _userMenuRepository = userMenuRepository;
        }

        public async Task<LoginDataDTO> Login(LoginDTO modelDto, CancellationToken cancellationToken)
        {
            LoginDataDTO model = new LoginDataDTO();
            var user = await _userRepository.GetByUserAndPass(modelDto.UserName, modelDto.Password, cancellationToken);
            if (user == null)
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");

            var jwt = await GenerateAsync(user);
            model.Token = jwt;
            var Menu =  _userMenuRepository.GetByUserId(user.Id);
            //model.Menu = _mapper.Map<List<UserMenuDTO>>(Menu);
            user.LastLogOnDate = DateTime.Now;
            await _userRepository.UpdateAsync(user, cancellationToken);
            return model;
        }
        public async Task<string> GenerateAsync(Domain.User user)
        {
            var secretKey =  Encoding.UTF8.GetBytes(_siteSetting.Jwt.Key);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var claims = await _getClaimsAsync(user);
            
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _siteSetting.Jwt.Issuer,
                Audience = _siteSetting.Jwt.Issuer,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(_siteSetting.Jwt.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(_siteSetting.Jwt.ExpirationMinutes),
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims)
            };


            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(descriptor);

            var jwt = tokenHandler.WriteToken(securityToken);

            return jwt;
        }
        private async Task<IEnumerable<Claim>> _getClaimsAsync(Domain.User user)
        {
            //JwtRegisteredClaimNames.Sub
            var securityStampClaimType = new ClaimsIdentityOptions().SecurityStampClaimType;

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var usermodel = _userRepository.GetById(user.Id);
            var userRoles = await _userRepository.GetUserRolesAsync(user.Id);
            userClaims.AddRange(userRoles.Select(z => new Claim(ClaimTypes.Role, z.Name)));

            return userClaims;
        }
        public async Task<string> Register(RegisterDTO modelDto, CancellationToken cancellationToken)
        {
            try
            {
                var person = new Person
                {
                    FirstName = modelDto.FirstName,
                    LastName = modelDto.LastName,
                    NationalCode = modelDto.NationalCode,
                    Identity = modelDto.Identity,
                    FatherName = modelDto.FatherName,
                    BirthDate = modelDto.BirthDate != null ? DateTime.Parse(modelDto.BirthDate) : null,
                    GenderId = modelDto.GenderId,
                    MarriageId = modelDto.MarriageId,
                    MillitaryId = modelDto.MillitaryId,
                    Code=Guid.NewGuid()
                };
                await _personRepository.AddAsync(person, cancellationToken);
                var user = new Domain.User
                {
                    Username = modelDto.Username,
                    Password = modelDto.Password,
                    Email = modelDto.Email,
                    PersonId = person.Id,
                    Code=Guid.NewGuid(),
                    
                };
                await _userRepository.AddAsync(user, modelDto.Password, cancellationToken);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            
        }

        public async Task<string> CheckVerification(CheckVerificationDTO model, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameVerificationCode(model.UserName, model.VerificationCode);
            if (user != null)
            {
                user.VerificationCode = null;
                user.VerificationExpiration = null;

                var guid = Guid.NewGuid();

                user.ChangePasswordCode = guid.ToString().Substring(0, 8);

                await _userRepository.ChangePassword(user,model.NewPassword, cancellationToken);
                return "موفقیت آمیز بود";

            }

            else throw new BadRequestException("کد اعتبارسنجی احراز نشد");
        }


        public bool ForgetPassword(SendSmsDTO modelDto, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetByUserName(modelDto.UserName);
            if (user != null)
            {
                var guid = Guid.NewGuid();
                // IList<string> phone = new List<string>();
                // if (user.Username.Substring(0, 1) == "0")
                //     user.Username = user.Username.Substring(1, user.Username.Length - 1);
                // phone.Add("98" + user.Username);

                user.VerificationCode = guid.ToString().Substring(0, 8);
                user.VerificationExpiration = DateTime.Now.AddMinutes(2);
                _userRepository.Update(user);

                Token smsIrRestfulNetCore = new Token();
                var token = new Token().GetToken("userApikey", "secretKey");
                var messageSend = new MessageSend();
                var res = messageSend.Send(token, new MessageSendObject()
                {
                    MobileNumbers = new List<string>() { "989365540839" }.ToArray(),
                    Messages = new List<string> { "test" }.ToArray(),
                    LineNumber = "123456",
                    SendDateTime = null,
                    CanContinueInCaseOfError = false
                });
                if (res.IsSuccessful)
                {
                    return true;
                }
                else return true;

            }
            else return false;
        }
    }
}
