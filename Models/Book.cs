using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineBookManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int Book_id { get; set; }

        [Required(ErrorMessage ="Book name is mandatory..")]
        public string Book_name { get; set; }

        [Required(ErrorMessage ="Book type is mandatory..")]
        public int bookType_id { get; set; }

        [Required(ErrorMessage ="Author is mandatory..")]
        public int Author_id { get; set; }

        [Required(ErrorMessage ="Publisher is mandatory..")]
        public int Publisher_id { get; set; }

        [Required(ErrorMessage ="Publication date is mandatory..")]
        [DataType(DataType.Date)]
        public DateTime Publish_date { get; set; }

        [Required(ErrorMessage ="ISBN number is mandatory..")]
        public string ISBN_no { get; set; }

        [Required(ErrorMessage ="Price is mandatory..")]
        [Range(1,100000, ErrorMessage ="Price must greater than 0..")]
        public decimal Price { get; set; }

        public virtual BookType BookType { get; set; }

        public virtual Author Author { get; set; }

        public virtual Publisher Publisher { get; set; }

    }
}