using Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("UserTypes")]

    public class UserType : BaseClass<int> 
    {
        public string Title { get; set; }

        

    }
}
