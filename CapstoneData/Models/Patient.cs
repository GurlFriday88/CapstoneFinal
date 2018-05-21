using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapstoneData.Models
{
    public class Patient
    {
        public int ID { get; set; }

        [Required]
        public string Type { get; set; }

        public string Frames { get; set; }

        public string Lenses { get; set; }

        public string Exam { get; set; }

        public virtual ProviderNote ProviderNote { get; set; }
    }

    
}
