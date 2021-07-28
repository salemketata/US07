using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace US07.Models
{
    public class Membre
    {
        [Key]
        public int MembreID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int CarteMembre { get; set; }
        public string CarteIdentite { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public int Age { get; set; }
        public string Secteur { get; set; }
    }
}