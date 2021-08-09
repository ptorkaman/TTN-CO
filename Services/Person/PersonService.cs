using AutoMapper;
using Common.Exceptions;
using Common.Utilities;
using Domain;
using DTO;
using DTO.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly SiteSettings _siteSetting;
        private readonly IMapper _mapper;
        private readonly PagingSettings _pagingSettings;
        public PersonService(IRepository<Person> personRepository, IOptionsSnapshot<SiteSettings> settings,IMapper mapper)
        {
            _personRepository = personRepository;
            _siteSetting = settings.Value;
            _mapper = mapper;
        }
        public async Task<PersonDTO> Create(PersonDTO modelDto, CancellationToken cancellationToken)
        {
            Person person = new()
            {
                Address = modelDto.Address,
                BirthDate = modelDto.BirthDate,
                CityId = modelDto.CityId,
                Code = modelDto.Code,
                FatherName = modelDto.FatherName,
                FirstName = modelDto.FirstName,
                GenderId = modelDto.GenderId,
                Identity = modelDto.Identity,
                ImagePath = modelDto.ImagePath,
                IsMarried = modelDto.IsMarried,
                MarriageId = modelDto.MarriageId,
                LastName = modelDto.LastName,
                NationalCode = modelDto.NationalCode,
                Mobile = modelDto.Mobile,
                Phone = modelDto.Phone,
                ProvinceId = modelDto.ProvinceId,
                PersonalNo = modelDto.PersonalNo,
                MillitaryId = modelDto.MillitaryId,
                IdNumber = modelDto.IdNumber,
               
            };

            await _personRepository.AddAsync(person, cancellationToken);
            return _mapper.Map<PersonDTO>(person);

        }

        public async Task<bool> DeletePersonAsync(int personId, CancellationToken cancellationToken)
        {
            var model = _personRepository.GetById(personId);
            if (model == null)
                throw new CustomException("خطا در دریافت اطلاعات ");
            _personRepository.DeleteAsync(model, cancellationToken);
            return true;
        }

        public async Task<List<PersonDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var model = _personRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<PersonDTO>>(model);
        }



        public async Task<PagedResult<PersonDTO>> GetAllAsync(int? page, int? pageSize, string orderBy, CancellationToken cancellationToken)
        {
            int pageNotNull = page ?? _pagingSettings.DefaultPage;
            int pageSizeNotNull = pageSize ?? _pagingSettings.PageSize;
            var model = _personRepository.GetPagedAsync(pageNotNull, pageSizeNotNull, cancellationToken);
            return _mapper.Map<PagedResult<PersonDTO>>(model);
        }

        public async Task<PersonDTO> UpdatePersonAsync(int personId, PersonDTO modelDto, CancellationToken cancellationToken)
        {
            Domain.Person person = new()
            {
                Id = personId,
                Address = modelDto.Address,
                BirthDate = modelDto.BirthDate,
                CityId = modelDto.CityId,
                Code = modelDto.Code,
                FatherName = modelDto.FatherName,
                FirstName = modelDto.FirstName,
                GenderId = modelDto.GenderId,
                Identity = modelDto.Identity,
                ImagePath = modelDto.ImagePath,
                IsMarried = modelDto.IsMarried,
                MarriageId = modelDto.MarriageId,
                LastName = modelDto.LastName,
                NationalCode = modelDto.NationalCode,
                Mobile = modelDto.Mobile,
                Phone = modelDto.Phone,
                ProvinceId = modelDto.ProvinceId,
                PersonalNo = modelDto.PersonalNo,
                MillitaryId = modelDto.MillitaryId,
                IdNumber = modelDto.IdNumber,
            };

            await _personRepository.UpdateAsync(person, cancellationToken);
            return _mapper.Map<PersonDTO>(person);
        }

       
    }
}
