using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using US07.Models;

namespace US07.Controllers
{
    public class LoginController : Controller
    {
        private ApplicationDbContext _context;

        public LoginController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Compte Comp)

        {
            ScryptEncoder encoder = new ScryptEncoder();


            var data = _context.Comptes.Where(c => c.Identifiant.Equals(Comp.Identifiant)).ToList();

            if (data.Count() > 0)
            {
                bool val = encoder.Compare(Comp.MotDePasse, data.SingleOrDefault().MotDePasse);
                if (val)

                {
                    
                    
                        Session["FullName"] = data.SingleOrDefault().Identifiant;
                        Session["Role"] = data.SingleOrDefault().Role;
                        Session["Id"] = data.SingleOrDefault().Id;
                        var cookie = new HttpCookie("Identifiant", data.FirstOrDefault().Identifiant);
                        cookie.Expires = DateTime.Now.AddDays(1);

                        HttpContext.Response.Cookies.Add(cookie);

                        return RedirectToAction("Index", "Administration");
                   
                    

                }
                else
                {
                    TempData["Compte"] = "Identifaint ou mot de passe ";
                    return RedirectToAction("Index", "Home");
                }



            }
            else
            {
                TempData["Compte"] = "Verifiez vos données";
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index", "Home");
        }
    }
}