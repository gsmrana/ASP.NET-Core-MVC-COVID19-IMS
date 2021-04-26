using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19IMS.Data
{
    public class CovidTesting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobileNo { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public string NationalIdNo { get; set; }

        public string HomeAddress { get; set; }

        public string Status { get; set; }
        public string AppointmentDateTime { get; set; }
        public string AppointmentLocation { get; set; }
        public string AppointmentBoothNo { get; set; }
        
        public string TestingDate { get; set; }        
        public string TesterName { get; set; }        
        public string TestingResult { get; set; }        
        public string TestingDetails { get; set; }        
    }
}
