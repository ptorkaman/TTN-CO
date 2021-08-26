using Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Repository;

namespace TTNCO.ActionFilters
{
    public class PermissionAttribute : ActionFilterAttribute
    {
        private string[] _permissions;
        private readonly IUserRepository _userRepository;
        public PermissionAttribute(IUserRepository userRepository, params string[] permissions)
        {
            _userRepository = userRepository;
            _permissions = permissions.Select(z => z.ToLower()).ToArray();
        }

        /// <summary>
        /// Get User roles 
        /// then get user roles permissins 
        /// distinct roles permissions
        /// if permissions contain action required permissions Ok otherwise 401
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userToken = context.HttpContext.Request.Headers[HeaderNames.Authorization];
            if (string.IsNullOrEmpty(userToken))
                context.Result = new UnauthorizedResult();

            var userClaims = (new JwtSecurityTokenHandler().ReadToken(userToken) as JwtSecurityToken).Claims;
            var userRoles = userClaims.Where(z => z.Type == ClaimTypes.Role).Select(z => z.Value).ToList();
            var userPermissions = _userRepository.GetRolesPermissionsAsync(userRoles).Result.DistinctBy(z => z.Name.ToLower());

            if (!userPermissions.Select(z => z.Name.ToLower()).ContainsAllItems(_permissions))
                context.Result = new UnauthorizedResult();

            base.OnActionExecuting(context);
        }
    }
}
