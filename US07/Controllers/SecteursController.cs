using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using US07.Models;

namespace US07.Controllers
{
    public class SecteursController : Controller
    {
        // GET: Secteurs
        private ApplicationDbContext _context;

        public SecteursController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult IndexMembreMharzaHayHabib()
        {
            return View();
        }

        public ActionResult IndexCaisseMharzaHayHabib()
        {
            return View();
        }

        public ActionResult IndexMharzaHayHabib()
        {
            return View();
        }

        public ActionResult IndexProduitMharzaHayHabib()
        {
            return View();
        }

        public ActionResult IndexDeplacementMharzaHayHabib()
        {
            return View();
        }

        // GET: MharzaHayHabib


        public JsonResult AjouterMembre(Membre membre)
        {

            _context.Membres.Add(membre);
            _context.SaveChanges();
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModifierMembre(Membre Mem)
        {

            var MembreInDb = _context.Membres.Single(c => c.MembreID == Mem.MembreID);
            MembreInDb.Nom = Mem.Nom;
            MembreInDb.Prenom = Mem.Prenom;
            MembreInDb.Secteur = Mem.Secteur;
            MembreInDb.DateDeNaissance = Mem.DateDeNaissance;
            MembreInDb.CarteIdentite = Mem.CarteIdentite;
            MembreInDb.CarteMembre = Mem.CarteMembre;
            MembreInDb.Age = Mem.Age;
            _context.SaveChanges();
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult EnregistrerCollecter(CaisseSecteur Col)
        {
            if (Col.Id == 0)
            {
                _context.CaisseSecteurs.Add(Col);
            }
            else
            {
                var CaisseInDb = _context.CaisseSecteurs.Single(c => c.Id == Col.Id);
                CaisseInDb.Mois = Col.Mois;
                CaisseInDb.Collecte = Col.Collecte;
                CaisseInDb.Credit = Col.Credit;
            }
            _context.SaveChanges();
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult checkMembreCarte(int userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Membres.Where(x => x.CarteMembre == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }
        public JsonResult checkMembreCIN(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Membres.Where(x => x.CarteIdentite == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        public JsonResult AjouterTansaction(TransactionSecteur Tr)
        {
            if(Tr.Type== "Sortie")
            {
                if(Tr.Raison== "Collecte Groupe")
                {
                    Tr.RaisonSpecifique = Tr.Raison + " " + Tr.Mois;
                }
                else
                {
                    Tr.RaisonSpecifique = Tr.Intitule;
                }
            }
            if (Tr.Type == "Entree")
            {
                if (Tr.Raison == "Collecte Mois")
                {
                    Tr.RaisonSpecifique = Tr.Raison + " " + Tr.Mois;
                }
                else
                {
                    Tr.RaisonSpecifique = Tr.Intitule;
                }
            }
            _context.TransactionSecteurs.Add(Tr);
            _context.SaveChanges();
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EnregistrerProduit(ProduitSecteur Pr)
        {
            if (Pr.Id == 0)
            {
                _context.ProduitSecteurs.Add(Pr);
            }
            else
            {
                var PrInDb = _context.ProduitSecteurs.Single(c => c.Id == Pr.Id);
                PrInDb.Taille = Pr.Taille;
                PrInDb.MntDonnee = Pr.MntDonnee;
                PrInDb.MntReste = Pr.MntReste;
            }
            _context.SaveChanges();
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EnregistrerDeplacement(DepalcementSecteur Dep)
        {
            if (Dep.Id == 0)
            {
                _context.DepalcementSecteurs.Add(Dep);
            }
            else
            {
                var DepInDb = _context.DepalcementSecteurs.Single(c => c.Id == Dep.Id);
                DepInDb.MntDonnee = Dep.MntDonnee;
                DepInDb.MntReste = Dep.MntReste;
            }
            _context.SaveChanges();
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);
        }
    }
}