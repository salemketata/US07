using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using US07.Models;

namespace US07.Controllers.Api
{
    [RoutePrefix("api/adm")]
    public class AdmController : ApiController
    {
        private ApplicationDbContext _context;

        public AdmController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("GetComptes")]
        public IHttpActionResult GetComptes()
        {
            var Comptes= _context.Comptes.ToList();
            return Ok(Comptes);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCompte(int id)
        {
            var CompteInDb = _context.Comptes.Single(c => c.Id == id);
            if (CompteInDb == null)
                return NotFound();
            _context.Comptes.Remove(CompteInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("GetCompte/{id}")]
        public IHttpActionResult GetCompte(int id)
        {
            var Compte = _context.Comptes.Where(c => c.Id == id).ToList();
            return Ok(Compte);
        }

        [HttpGet]
        [Route("GetParametrege")]
        public IHttpActionResult GetParametrege()
        {
            var Parametrages = _context.Parametrages.ToList();
            return Ok(Parametrages);
        }

        [HttpGet]
        [Route("GetParametre/{id}")]
        public IHttpActionResult GetParametre(int id)
        {
            var Parametre = _context.Parametrages.Where(c => c.Id == id).ToList();
            return Ok(Parametre);
        }

        [HttpGet]
        [Route("GetNbComptes")]
        public IHttpActionResult GetNbComptes()
        {
            var NbComptes = _context.Comptes.ToList();
            var j = 0;
            foreach(var i in NbComptes)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetNbComptesStaff")]
        public IHttpActionResult GetNbComptesStaff()
        {
            List<Object> Staff = new List<Object>();
            var NbComptesStaff = _context.Comptes.Where(c => c.Role== "Staff").ToList();
            var NbComptesCaissier = _context.Comptes.Where(c => c.Role == "Caissier du groupe").ToList();
            Staff.AddRange(NbComptesStaff);
            Staff.AddRange(NbComptesCaissier);
            var j = 0;
            foreach (var i in Staff)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetNbComptesCaissier")]
        public IHttpActionResult GetNbComptesCaissier()
        {
            var NbComptesCaissier = _context.Comptes.Where(c => c.Role == "Caissier du groupe").ToList();
            var j = 0;
            foreach (var i in NbComptesCaissier)
            {
                j++;
            }
            return Ok(j);
        }

        [HttpGet]
        [Route("GetNbComptesChef")]
        public IHttpActionResult GetNbComptesChef()
        {
            List<Object> Staff = new List<Object>();
            var NbComptesChefMh = _context.Comptes.Where(c => c.Role == "Chef Secteur Mharza & Hay Habib").ToList();
            var NbComptesChefSok= _context.Comptes.Where(c => c.Role == "Chef Secteur Sokra").ToList();
            var NbComptesChefGab = _context.Comptes.Where(c => c.Role == "Chef Secteur Gabes").ToList();
            var NbComptesChefMat = _context.Comptes.Where(c => c.Role == "Chef Secteur Matar").ToList();
            var NbComptesChefMan = _context.Comptes.Where(c => c.Role == "Chef Secteur Manzel Chaker").ToList();
            var NbComptesChefAin = _context.Comptes.Where(c => c.Role == "Chef Secteur Ain").ToList();
            var NbComptesChefLaf = _context.Comptes.Where(c => c.Role == "Chef Secteur Lafrane & Gremda & Tanyour").ToList();
            var NbComptesChefTou = _context.Comptes.Where(c => c.Role == "Chef Secteur Tounes").ToList();
            var NbComptesChefMah = _context.Comptes.Where(c => c.Role == "Chef Secteur Mahdiya & Saltniya").ToList();
            var NbComptesChefAge = _context.Comptes.Where(c => c.Role == "Chef Secteur Agareb").ToList();
            var NbComptesChefSaa = _context.Comptes.Where(c => c.Role == "Chef Secteur Saadi").ToList();
            Staff.AddRange(NbComptesChefMh);
            Staff.AddRange(NbComptesChefSok);
            Staff.AddRange(NbComptesChefGab);
            Staff.AddRange(NbComptesChefMat);
            Staff.AddRange(NbComptesChefMan);
            Staff.AddRange(NbComptesChefAin);
            Staff.AddRange(NbComptesChefLaf);
            Staff.AddRange(NbComptesChefTou);
            Staff.AddRange(NbComptesChefMah);
            Staff.AddRange(NbComptesChefAge);
            Staff.AddRange(NbComptesChefSaa);
            var j = 0;
            foreach (var i in Staff)
            {
                j++;
            }
            return Ok(j);
        }
    }
}
