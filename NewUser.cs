using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlyMvc.Infrastructure;

namespace OnlyMvc.Domain
{
    public class NewUser
    {
        public NewUser()
        {
            this.CreateDate = DateTime.Now;
            this.HomeCity = CityType.Select;
        }
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Choose Image")]
        public string ImageName { get; set; }

        public CityType? HomeCity { get; set; }
    }
}