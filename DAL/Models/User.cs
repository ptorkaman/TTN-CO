using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Users")]

    public  class User
    {
        public User()
        {
            //UserRoles = new HashSet<UserRole>();
            //UserMenus = new HashSet<UserMenu>();
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

        public virtual Person Person { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual IList<UserMenu> UserMenus { get; set; }
        public virtual IList<UserWarhouse> UserWarhouses { get; set; }

        //public virtual IList<UserStation> Stations { get; set; }
        //public virtual IList<UserMenu> UserMenus { get; set; }


        public bool IsAdmin { get; set; }

        public DateTime LastLoginDate { get; set; }

        //public National National { get; set; }
        public long? NationalId { get; set; }

        [StringLength(100)]
        public string SerialNumber { get; set; }

        //[StringLength(50)]
        //public string UserName { get; set; }

        public string UserPassword { get; set; }

      
    }

}
