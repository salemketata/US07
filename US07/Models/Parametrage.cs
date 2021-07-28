using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace US07.Models
{
    public class Parametrage
    {
        [Key]
        public int Id { get; set; }
        public string Intitule { get; set; }
        public decimal Montant { get; set; }
    }
}