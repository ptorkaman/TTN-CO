using Domain;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken);
        Task<List<Role>> GetUserRolesAsync(long userId);
        Task<List<Permission>> GetRolesPermissionsAsync(IEnumerable<string> roles);
        Task AddAsync(User user, string password, CancellationToken cancellationToken);
        Task<User> GetByCode(Guid code, CancellationToken cancellationToken);
        User GetByUserName(string userName);
        //Task<User> GetByUserNameCode(CheckVerificationViewModel model);
        Task<User> GetByUserNameVerificationCode(string verificationCode1, string verificationCode2);
        Task ChangePassword(User user, string newPassword, CancellationToken cancellationToken);
        //Task<User> GetByUserNameChangePassword(ChangePasswordViewModel model, string username);
    }
}