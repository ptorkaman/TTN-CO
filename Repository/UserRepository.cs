using Common.Extensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            return Table.Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
               .ThenInclude(x => x.RolePermissions)
                .Include(x => x.UserMenus)
                .ThenInclude(x => x.Menu)
                .FirstOrDefault(x => x.Username == username); ;
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
                .Where(z => roles.Contains(z.Name))
                .SelectMany(z => z.RolePermissions).Select(z => z.Permission).ToListAsync();
        }

        public  User GetByUserName(string userName)
        {
            return  Table.Where(p => p.Username == userName).FirstOrDefault();
        }

       

        //public async  Task<User> GetByUserNameCode(CheckVerificationViewModel model)
        //{
        //    return Table.Where(p => p.Username == model.Username && p.TwoStepCode == model.VerificationCode && p.TwoStepExpiration>=DateTime.Now ).FirstOrDefault();
        //}

        public async Task<User> GetByUserNameVerificationCode(string Username, string VerificationCode)
        {
            var date = DateTime.Now.Date;
            return Table.Where(p =>  p.VerificationCode == VerificationCode && p.Username==Username ).FirstOrDefault();
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
}
