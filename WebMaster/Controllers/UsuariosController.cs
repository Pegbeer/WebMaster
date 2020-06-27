using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using RestSharp;
using WebMaster.Models;

namespace WebMaster.Controllers
{
    public class UsuariosController : Controller
    {
        public WebMasterDBContext _context;

        public UsuariosController(WebMasterDBContext master)
        {
            this._context = master;
        }

      
        public IActionResult Login(string usuario, string password)
        {
            var user = checkUser(usuario, password);
            if (user == null)
            {
                ViewBag.error = "Invalid";
                return RedirectToAction("SignIn", "Home");
            }
            else
            {
                HttpContext.Session.SetString("!SESSION", usuario);


                if (user.Rol == "Administrador")
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (user.Rol == "Usuario")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("SignIn", "Home");
                }
                
            }
            
        }

        private Usuarios checkUser(string usuario, string password)
        {
            var user = _context.Usuarios.SingleOrDefault(a => a.Usuario.Equals(usuario));
            if(user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }


    }
}
