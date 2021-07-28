using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace US07.Models
{
    public class ProduitSecteur
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int CarteMembre { get; set; }
        public string Secteur { get; set; }
        public decimal MntDonnee { get; set; }
        public decimal MntReste { get; set; }
        public string Taille { get; set; }

    }
}