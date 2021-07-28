using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using US07.Models;


namespace US07.Controllers
{
    public class AdministrationController : Controller
    {
        private ApplicationDbContext _context;

        public AdministrationController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GestionCompte()
        {
            return View();
        }
        
        public ActionResult Parametrage()
        {
            return View();
        }

        public JsonResult AjouterCompte(Compte compte)
        {

            ScryptEncoder encoder = new ScryptEncoder();
            compte.MotDePasse = encoder.Encode(compte.MotDePasse);
            _context.Comptes.Add(compte);
            _context.SaveChanges();
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModifierCompte(Compte Comp)
        {

            var CompteInDb = _context.Comptes.Single(c => c.Id == Comp.Id);
            
            if(Comp.MotDePasse!=null)
            {
                ScryptEncoder encoder = new ScryptEncoder();
                CompteInDb.MotDePasse = encoder.Encode(Comp.MotDePasse);
                CompteInDb.Identifiant = Comp.Identifiant;
                CompteInDb.NumTel = Comp.NumTel;
                CompteInDb.DateDeNaissance = Comp.DateDeNaissance;
                CompteInDb.CarteIdentite = Comp.CarteIdentite;
                CompteInDb.CarteMembre = Comp.CarteMembre;
                CompteInDb.Age = Comp.Age;
                _context.SaveChanges();
            }
            else
            {
                CompteInDb.Identifiant = Comp.Identifiant;
                CompteInDb.NumTel = Comp.NumTel;
                CompteInDb.DateDeNaissance = Comp.DateDeNaissance;
                CompteInDb.CarteIdentite = Comp.CarteIdentite;
                CompteInDb.CarteMembre = Comp.CarteMembre;
                CompteInDb.Age = Comp.Age;
                _context.SaveChanges();
            }
            

            
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult checkCompteCarte(int userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Comptes.Where(x => x.CarteMembre == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }
        public JsonResult checkCompteCIN(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Comptes.Where(x => x.CarteIdentite == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        public JsonResult checkCompteRole(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Comptes.Where(x => x.Role == userdata).SingleOrDefault();
            if (SeachData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        public JsonResult AjouterParametre(Parametrage Par)
        {
            _context.Parametrages.Add(Par);
            _context.SaveChanges();
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ModifierParametre(Parametrage Par)
        {
            var ParametreInDb = _context.Parametrages.Single(c => c.Id == Par.Id);
            ParametreInDb.Intitule = Par.Intitule;
            ParametreInDb.Montant = Par.Montant;
            _context.SaveChanges();
            return Json(new { data = "hello" }, JsonRequestBehavior.AllowGet);
        }

        
    }
}