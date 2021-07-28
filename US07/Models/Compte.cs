using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace US07.Models
{
    public class Compte
    {
        public int Id { get; set; }
        public string Identifiant { get; set; }
        public string MotDePasse { get; set; }
        public int CarteMembre { get; set; }
        public string CarteIdentite { get; set; }
        public string Role { get; set; }
        public string NumTel { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public int Age { get; set; }
    }
}