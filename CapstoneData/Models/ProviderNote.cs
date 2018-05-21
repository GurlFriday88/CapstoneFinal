using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapstoneData.Models
{
    public class ProviderNote
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

      
        public virtual Provider Provider { get; set; }

        public virtual Contact Contact { get; set; }

        public IEnumerable<Patient> Patients { get; set; }

        
    }
}
