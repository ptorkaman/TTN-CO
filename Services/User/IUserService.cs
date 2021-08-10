using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.User
{
    public interface IUserService
    {
        Task<string> Register(RegisterDTO modelDto, CancellationToken cancellationToken);
        Task<LoginDataDTO> Login(LoginDTO modelDto, CancellationToken cancellationToken);
        Task<string> CheckVerification(CheckVerificationDTO model, CancellationToken cancellationToken);
        bool ForgetPassword(SendSmsDTO modelDto, CancellationToken cancellationToken);
        IList<MenuDTO> GetMenu(long modelId);
    }
}
