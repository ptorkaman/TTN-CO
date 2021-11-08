using Common.Extensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IRepository<Role> _roleRepository;

        public UserRepository(TTNContext dbContext, IRepository<UserRole> userRoleRepository, IRepository<Role> roleRepository) : base(dbContext)
        {
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public User GetByUserAndPass(string username, string password, CancellationToken cancellationToken)
        {

            var passwordHash = SecurityHelper.GetSha256Hash(password);
            var user= Table
               .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
              .ThenInclude(x => x.RolePermissions)
                .Include(x => x.UserMenus)
                .ThenInclude(x => x.Menu)
                .Include(x => x.UserWarhouses)
                .ThenInclude(x => x.Warehouse)
                .FirstOrDefault(x => x.Username == username );
            if (user != null)
            {
                var verifyResult = VerifyHashedPassword(user.UserPassword, password);
                if (verifyResult == PasswordVerificationResult.Success)
                    return user;
            }

            return null;
        }
        public virtual PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (Crypto.VerifyHashedPassword(hashedPassword, providedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
        public async Task AddAsync(User user, string password, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.Username == user.Username);
            if (exists)
                throw new Exception("نام کاربری تکراری است");

            var passwordHash = SecurityHelper.GetSha256Hash(password);
            user.Password = passwordHash;
            await base.AddAsync(user, cancellationToken);
        }


        public Task<User> GetByCode(Guid code, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.Code == code).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<List<Role>> GetUserRolesAsync(long userId)
        {
            var roles = await _userRoleRepository.TableNoTracking.Include(z => z.Role).Where(z => z.UserId == userId).Select(z => z.Role).ToListAsync();
            return roles;
        }

        public async Task<List<Permission>> GetRolesPermissionsAsync(IEnumerable<string> roles)
        {
            return await _roleRepository.TableNoTracking
                .Include(z => z.RolePermissions)
                .ThenInclude(z => z.Permission)
                .Where(z => roles.Contains(z.Title))
                .SelectMany(z => z.RolePermissions).Select(z => z.Permission).ToListAsync();
        }

        public User GetByUserName(string userName)
        {
            return Table.Where(p => p.Username == userName).FirstOrDefault();
        }



        //public async  Task<User> GetByUserNameCode(CheckVerificationViewModel model)
        //{
        //    return Table.Where(p => p.Username == model.Username && p.TwoStepCode == model.VerificationCode && p.TwoStepExpiration>=DateTime.Now ).FirstOrDefault();
        //}

        public async Task<User> GetByUserNameVerificationCode(string Username, string VerificationCode)
        {
            var date = DateTime.Now.Date;
            return Table.Where(p => p.VerificationCode == VerificationCode && p.Username == Username).FirstOrDefault();
        }

        public async Task ChangePassword(User user, string newPassword, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.Username == user.Username);
            if (!exists)
                throw new Exception("نام کاربری  وجود ندارد");

            var passwordHash = SecurityHelper.GetSha256Hash(newPassword);
            user.Password = passwordHash;
            await base.UpdateAsync(user, cancellationToken);
        }



        //public async Task<User> GetByUserNameChangePassword(ChangePasswordViewModel model, string username)
        //{
        //    return Table.Where(p => p.Username == username && p.ChangePasswordCode == model.ChangePasswordCode).FirstOrDefault();
        //}
    }
    public enum PasswordVerificationResult
    {
        /// <summary>
        ///     Password verification failed
        /// </summary>
        Failed = 0,

        /// <summary>
        ///     Success
        /// </summary>
        Success = 1,

        /// <summary>
        ///     Success but should update and rehash the password
        /// </summary>
        SuccessRehashNeeded = 2
    }
    internal static class Crypto
    {
        private const int PBKDF2IterCount = 1000; // default for Rfc2898DeriveBytes
        private const int PBKDF2SubkeyLength = 256 / 8; // 256 bits
        private const int SaltSize = 128 / 8; // 128 bits

        /* =======================
         * HASHED PASSWORD FORMATS
         * =======================
         *
         * Version 0:
         * PBKDF2 with HMAC-SHA1, 128-bit salt, 256-bit subkey, 1000 iterations.
         * (See also: SDL crypto guidelines v5.1, Part III)
         * Format: { 0x00, salt, subkey }
         */

        // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            var areSame = true;
            for (var i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }

        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            // Produce a version 0 (see comment above) text hash.
            byte[] salt;
            byte[] subkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }

            var outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }

        // hashedPassword must be of the format of HashWithPassword (salt + Hash(salt+input)
        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

            // Verify a version 0 (see comment above) text hash.

            if (hashedPasswordBytes.Length != (1 + SaltSize + PBKDF2SubkeyLength) || hashedPasswordBytes[0] != 0x00)
            {
                // Wrong length or version header.
                return false;
            }

            var salt = new byte[SaltSize];
            Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
            var storedSubkey = new byte[PBKDF2SubkeyLength];
            Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, PBKDF2SubkeyLength);

            byte[] generatedSubkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, PBKDF2IterCount))
            {
                generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }
            return ByteArraysEqual(storedSubkey, generatedSubkey);
        }
    }

    public class PasswordHasherService : IPasswordHasherService
    {
        /// <summary>
        ///     Hash a password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        /// <summary>
        ///     Verify that a password matches the hashedPassword
        /// </summary>
        /// <param name="hashedPassword"></param>
        /// <param name="providedPassword"></param>
        /// <returns></returns>
        public virtual PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (Crypto.VerifyHashedPassword(hashedPassword, providedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
    }
    public interface IPasswordHasherService
    {
        string HashPassword(string password);

        PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}
