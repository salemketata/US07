using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using US07.Models;

namespace US07.Controllers.Api
{
    [RoutePrefix("api/Sec")]
    public class SecController : ApiController
    {
        private ApplicationDbContext _context;

        public SecController()
        {
            _context = new ApplicationDbContext();
        }



        [HttpGet]
        [Route("GetMembreMharza")]
        public IHttpActionResult GetMembreMharza()
        {
            var MembreMharza = _context.Membres.Where(c => c.Secteur == "Mharza & Hay habib").ToList();
            return Ok(MembreMharza);
        }

        [HttpGet]
        [Route("GetMembreMatar")]
        public IHttpActionResult GetMembreMatar()
        {
            var MembreMatar = _context.Membres.Where(c => c.Secteur == "Matar").ToList();
            return Ok(MembreMatar);
        }

        [HttpGet]
        [Route("GetMembre/{id}")]
        public IHttpActionResult GetMembre(int id)
        {
            var Membre = _context.Membres.Where(c => c.MembreID == id).ToList();
            return Ok(Membre);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMembre(int id)
        {
            var membreInDb = _context.Membres.Single(c => c.MembreID == id);
            if (membreInDb == null)
                return NotFound();
            _context.Membres.Remove(membreInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("GetCollecteMembre/{id}")]
        public IHttpActionResult GetCollecteMembre(int id)
        {
            var MembreCollecte = _context.CaisseSecteurs.Where(c => c.CarteMembre == id).ToList();
            return Ok(MembreCollecte);
        }

        [HttpGet]
        [Route("GetMois")]
        public IHttpActionResult GetMois(String IDss)
        {
            var idsList = JArray.Parse(IDss).Select(id => id.ToString()).ToList();
            //var idsListlong = idsList.Select(long.Parse).ToList();
            var output = _context.CaisseSecteurs.ToList().Where(fc => idsList[0].Contains(fc.Mois) && idsList[1].Contains(Convert.ToString(fc.CarteMembre)));

            return Json(output);
        }

        [HttpGet]
        [Route("GetNbMembreMharza")]
        public IHttpActionResult GetNbMembre()
        {
            var Membre = _context.Membres.Where(c => c.Secteur == "Mharza & Hay Habib").ToList();
            var j = 0;
            foreach(var i in Membre)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetCollecteMharza")]
        public IHttpActionResult GetCollecteMharza()
        {
            var Collecte = _context.CaisseSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib").ToList();
            decimal j = 0;
            foreach (var i in Collecte)
            {
                j=j+i.Collecte;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetCreditMharza")]
        public IHttpActionResult GetCreditMharza()
        {
            var Collecte = _context.CaisseSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib").ToList();
            decimal j = 0;
            foreach (var i in Collecte)
            {
                j = j + i.Credit;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetCreditCollecteMharza")]
        public IHttpActionResult GetCreditCollecteMharza()
        {
            var Bilan = _context.CaisseSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib").ToList();           
            return Ok(Bilan);
        }

        [HttpGet]
        [Route("GetEnreeMharza")]
        public IHttpActionResult GetEnreeMharza()
        {
            var EntreeMharza = _context.TransactionSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" && c.Type == "Entree").ToList();
            return Ok(EntreeMharza);
        }

        [HttpGet]
        [Route("GetSortieMharza")]
        public IHttpActionResult GetSortieMharza()
        {
            var EntreeMharza = _context.TransactionSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" && c.Type == "Sortie").ToList();
            return Ok(EntreeMharza);
        }

        [HttpGet]
        [Route("GetCaisseMharza")]
        public IHttpActionResult GetCaisseMharza()
        {
            var CaisseMharza = _context.TransactionSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" ).ToList();
            return Ok(CaisseMharza);
        }

        [HttpGet]
        [Route("GetProduitMharza")]
        public IHttpActionResult GetProduitMharza()
        {
            var MembreProduit = _context.ProduitSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib").ToList();
            return Ok(MembreProduit);
        }

        [HttpGet]
        [Route("GetMembreProduit")]
        public IHttpActionResult GetMembreProduit(String IDss)
        {
            var idsList = JArray.Parse(IDss).Select(id => id.ToString()).ToList();
            //var idsListlong = idsList.Select(long.Parse).ToList();
            var output = _context.ProduitSecteurs.ToList().Where(fc =>  idsList[0].Contains(Convert.ToString(fc.CarteMembre)));

            return Json(output);
        }

        [HttpGet]
        [Route("GetNbProduitMharza")]
        public IHttpActionResult GetNbProduitMharza()
        {
            var MembreMharzaNbProduit = _context.ProduitSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib").ToList();
            var j = 0;
            foreach(var i in MembreMharzaNbProduit)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetNbProduitSMharza")]
        public IHttpActionResult GetNbProduitSMharza()
        {
            var MembreMharzaNbProduitS = _context.ProduitSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" && c.Taille=="S").ToList();
            var j = 0;
            foreach (var i in MembreMharzaNbProduitS)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetNbProduitMMharza")]
        public IHttpActionResult GetNbProduitMMharza()
        {
            var MembreMharzaNbProduitM = _context.ProduitSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" && c.Taille == "M").ToList();
            var j = 0;
            foreach (var i in MembreMharzaNbProduitM)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetNbProduitLMharza")]
        public IHttpActionResult GetNbProduitLMharza()
        {
            var MembreMharzaNbProduitL = _context.ProduitSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" && c.Taille == "L").ToList();
            var j = 0;
            foreach (var i in MembreMharzaNbProduitL)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetNbProduitXLMharza")]
        public IHttpActionResult GetNbProduitXLMharza()
        {
            var MembreMharzaNbProduitXL = _context.ProduitSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" && c.Taille == "XL").ToList();
            var j = 0;
            foreach (var i in MembreMharzaNbProduitXL)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetNbProduitXXLMharza")]
        public IHttpActionResult GetNbProduitXXLMharza()
        {
            var MembreMharzaNbProduitXXL = _context.ProduitSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" && c.Taille == "XXL").ToList();
            var j = 0;
            foreach (var i in MembreMharzaNbProduitXXL)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetNbProduitXXXLMharza")]
        public IHttpActionResult GetNbProduitXXXLMharza()
        {
            var MembreMharzaNbProduitXXXL = _context.ProduitSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" && c.Taille == "XXXL").ToList();
            var j = 0;
            foreach (var i in MembreMharzaNbProduitXXXL)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetMontantProduitMharza")]
        public IHttpActionResult GetMontantProduitMharza()
        {
            var MembreMharzaNbProduit = _context.ProduitSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" ).ToList();
            decimal j = 0;
            foreach (var i in MembreMharzaNbProduit)
            {
                j = j + i.MntDonnee;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetMembreDepMharza")]
        public IHttpActionResult GetMembreDepMharza()
        {
            var MembreMharzaDep = _context.Membres.Where(c => c.Secteur == "Mharza & Hay Habib" &&  (DateTime.Today.Year  - c.DateDeNaissance.Year  > 18)).ToList();
            
            return Ok(MembreMharzaDep);
        }

        [HttpGet]
        [Route("GetMembreDepMontMharza")]
        public IHttpActionResult GetMembreDepMontMharza()
        {
            var MembreMharzaDepMont = _context.DepalcementSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib" ).ToList();

            return Ok(MembreMharzaDepMont);
        }

        [HttpGet]
        [Route("GetMembreDepOffMharza")]
        public IHttpActionResult GetMembreDepOffMharza()
        {
            var MembreMharzaDepOff = _context.DepalcementSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib").ToList();
            var j = 0;
            foreach(var i in MembreMharzaDepOff)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetMembreDepOffCollecteMharza")]
        public IHttpActionResult GetMembreDepOffCollecteMharza()
        {
            var MembreMharzaDepOff = _context.DepalcementSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib").ToList();
            decimal j = 0;
            foreach (var i in MembreMharzaDepOff)
            {
                j=j+i.MntDonnee;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetMembreDepOffCreditMharza")]
        public IHttpActionResult GetMembreDepOffCreditMharza()
        {
            var MembreMharzaDepOff = _context.DepalcementSecteurs.Where(c => c.Secteur == "Mharza & Hay Habib").ToList();
            decimal j = 0;
            foreach (var i in MembreMharzaDepOff)
            {
                j = j + i.MntReste;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetMembreDeplacement")]
        public IHttpActionResult GetMembreDeplacement(String IDss)
        {
            var idsList = JArray.Parse(IDss).Select(id => id.ToString()).ToList();
            //var idsListlong = idsList.Select(long.Parse).ToList();
            var output = _context.DepalcementSecteurs.ToList().Where(fc => idsList[0].Contains(Convert.ToString(fc.CarteMembre)));

            return Json(output);
        }
    }
}
