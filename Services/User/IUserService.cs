using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Utilities;
using Models.User;

namespace Services.User
{
    public interface IUserService
    {
        Task<string> Register(RegisterDTO modelDto, CancellationToken cancellationToken);
        Task<LoginDataDTO> Login(LoginDTO modelDto, CancellationToken cancellationToken, string ip, byte[] key);
        Task<string> CheckVerification(CheckVerificationDTO model, CancellationToken cancellationToken);
        bool ForgetPassword(SendSmsDTO modelDto, CancellationToken cancellationToken);
        IList<MenuDTO> GetMenu(long modelId);
        Domain.User Login1(string username, string password);


    }
}
