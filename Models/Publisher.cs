using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookManagementSystem.Models
{
    public class Publisher
    {
        [Key]
        public int Publisher_id { get; set; }

        [Required(ErrorMessage = "Publisher name is mandatory..")]
        public string Publisher_name { get; set; }
    }
}