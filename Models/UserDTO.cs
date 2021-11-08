using System;
using System.Collections.Generic;

namespace DTO
{
    public partial class UserDTO:BaseClassDTO<long>
    {
        public UserDTO()
        {
            UserRoles = new HashSet<UserRoleDTO>();
            UserMenus = new HashSet<UserMenuDTO>();

        }

        public long Id { get; set; }
        public long? PersonId { get; set; }
        public Guid Code { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public int? UserType { get; set; }
        public int? PersonalId { get; set; }
        public int? DepartmentId { get; set; }
        public string Email { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public byte? IsEnable { get; set; }
        public byte? IsVerified { get; set; }
        public byte? IsTwoStepVerification { get; set; }
        public string TwoStepCode { get; set; }
        public DateTime? TwoStepExpiration { get; set; }
        public byte? IsLoginNotify { get; set; }
        public string VerificationCode { get; set; }
        public DateTime? VerificationExpiration { get; set; }
        public DateTime? LastLogOnDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ChangePasswordCode { get; set; }

        public virtual PersonDTO Person { get; set; }
        public virtual ICollection<UserRoleDTO> UserRoles { get; set; }
        public virtual ICollection<UserMenuDTO> UserMenus { get; set; }

    }

}
