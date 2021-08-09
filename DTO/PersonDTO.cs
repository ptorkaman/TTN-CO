using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public partial class PersonDTO:BaseClassDTO<long>
    {
        public PersonDTO()
        {
            Users = new HashSet<UserDTO>();
        }
        public string PersonalNo { get; set; }
        public Guid Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string IdNumber { get; set; }
        public string Identity { get; set; }
        public string FatherName { get; set; }
        public DateTime? BirthDate { get; set; }
        public byte GenderId { get; set; }
        public byte MarriageId { get; set; }
        public byte? MillitaryId { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public string Address { get; set; }
        public bool? IsMarried { get; set; }
        public bool? Gender { get; set; }
        public virtual ICollection<UserDTO> Users { get; set; }
    }
}
