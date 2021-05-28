using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19IMS.Models
{
    public class CovidVaccine
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }

        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string NationalIdNo { get; set; }
        public string MobileNo { get; set; }
        public string HomeAddress { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string AppointmentBranch { get; set; }
        public string AppointmentDate { get; set; }
        public string Remarks { get; set; }
    }
}
