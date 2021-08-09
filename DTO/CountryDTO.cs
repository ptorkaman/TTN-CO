using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public  class CountryDTO : BaseClassDTO<int> 
    {
        public string Name { get; set; }
        public string EnglishName { get; set; }
       


    }
}
