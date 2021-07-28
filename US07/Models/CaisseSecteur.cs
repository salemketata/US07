using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace US07.Models
{
    public class CaisseSecteur
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int CarteMembre { get; set; }
        public string Secteur { get; set; }
        public decimal Collecte { get; set; }
        public decimal Credit { get; set; }
        public string Mois { get; set; }
    }
}