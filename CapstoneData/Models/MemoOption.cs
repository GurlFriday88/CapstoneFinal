using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapstoneData.Models
{
    public class MemoOption
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


    }
}
