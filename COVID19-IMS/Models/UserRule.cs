using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19IMS.Models
{
    public class UserRule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RuleName { get; set; }
    }
}
