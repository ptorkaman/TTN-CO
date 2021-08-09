using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("UserType", Schema = "TTN")]

    public class UserType : BaseClass<int> 
    {
        public string Title { get; set; }

        

    }
}
