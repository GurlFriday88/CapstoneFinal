using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapstoneData.Models
{
    public class Store
    {
        public int ID { get; set; }

        [Required]
        public String Name { get; set; }

        public virtual Contact Contact { get; set; }




    }
}
