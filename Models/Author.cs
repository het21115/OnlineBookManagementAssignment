using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace OnlineBookManagementSystem.Models
{
    public class Author
    {
        [Key]
        public int Author_id { get; set; }
        
        [Required(ErrorMessage ="Author name is mandatory..")]
        public string Author_name { get; set; }

        [Required(ErrorMessage ="Email is madatory..")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Book type is madatory..")]
        public int bookType_id { get; set; }

        [Required(ErrorMessage = "Phone is mandatory..")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Author_password { get; set; }


        public virtual BookType BookType { get; set; }
    }
}