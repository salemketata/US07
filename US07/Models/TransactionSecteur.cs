using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace US07.Models
{
    public class TransactionSecteur
    {
        [Key]
        public int Id { get; set; }
        public string Raison { get; set; }
        public string RaisonSpecifique { get; set; }
        public string Mois { get; set; }
        public string Intitule { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Secteur { get; set; }
    }
}