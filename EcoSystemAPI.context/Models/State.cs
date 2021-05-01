using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcoSystemAPI.Context.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Mission { get; set; }
        public string Vision { get; set; }
    }
}
