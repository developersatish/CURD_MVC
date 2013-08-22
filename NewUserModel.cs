using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlyMvc.Infrastructure;

namespace OnlyMvc.Models
{
    public class NewUserModel
    {
        public NewUserModel()
        {
            this.NewUserModels = new List<NewUserModel>();
            this.ID = 0;
            this.IsEdit = false;
            this.HomeCity = null;
        }

        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string ImageName { get; set; }

        public bool IsEdit { get; set; }

        [Display(Name = "City")]
        public CityType? HomeCity { get; set; }

        public List<NewUserModel> NewUserModels { get; set; }
    }
}