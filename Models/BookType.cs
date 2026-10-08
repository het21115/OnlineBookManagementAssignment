using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookManagementSystem.Models
{
    public class BookType
    {
        [Key]
        public int bookType_id { get; set; }

        [Required(ErrorMessage ="Book type is mandatory..")]
        public string bookType_name { get; set; }
    }
}