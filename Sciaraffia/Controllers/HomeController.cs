using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Sciaraffia.Models;
using Sciaraffia.Entidades;
using Sciaraffia.Helper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Sciaraffia.Controllers
{
    public class HomeController : Controller
    {

        HorarioDbContext CitaBD;
       

        /* creando variable para poder manejar la bd tabla */
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,HorarioDbContext _context)
        {
            _logger = logger;
            CitaBD = _context;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
          public IActionResult Registro()
        {
            return View();
        }

        public IActionResult LoginG()
        {
            return View();
        }
        [BindProperty]
        public RegistroH _registro{get;set;}

  
        [BindProperty]
        public Usser _usser{get;set;}
          /* guardando usuario */
        [HttpPost]
        public async Task<IActionResult> SetUsuario(){
          var result = await CitaBD.usuarioC.Where(x=>x.correo == _usser.correo).SingleOrDefaultAsync(); 
          if(result!=null){
            return BadRequest(new JObject(){
                {"StatusCode", 400},
                {"Message","El usuario ya existe"}
            });
          }

            Usuario uss = new Usuario(){
                correo=_usser.correo,
                nombre=_usser.nombre,
                clave=_usser.clave
                   };
            
                CitaBD.usuarioC.Add(uss);
                await CitaBD.SaveChangesAsync();
                return Created($"/Index {_usser.correo}",_usser);
               // return RedirectToAction("Index");
                      // return Json(_usser.correo);

        }
                /* login */

        public async Task<IActionResult> SetLogin(){
        var result = await CitaBD.usuarioC.Where(x=>x.correo == _usser.correo).SingleOrDefaultAsync(); 
        if(result== null){
            return BadRequest(new JObject(){
            {"StatusCode", 400},
            {"Message", "El usuario no existe"}
                    });
        }else{

            if(result.clave==_usser.clave){
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier,result.correo));
                identity.AddClaim(new Claim(ClaimTypes.Name,result.nombre));
                var principal= new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties{ExpiresUtc = DateTime.Now.AddDays(1), IsPersistent = true});

                    return Ok(result);
            }else{

                var respuesta = new JObject(){
            {"StatusCode", 403},
            {"Message", "Contraseña no valida"}};
                return StatusCode(403, respuesta);
            }
        }

        
        }
public async Task<IActionResult> SetLoguot(){
    await HttpContext.SignOutAsync();
    return RedirectToAction("Index");
}




    /* Agenda */

    public IActionResult Agenda()
        {   // modo de busqueda por usuario citas
        if(SessionHelper.GetNameIdentifier(User)=="admin@gmail.com"){
        ViewBag.Registro = CitaBD.HorarioC.ToList();
        }else{
            ViewBag.Registro = CitaBD.HorarioC.Where(x=>x.usuario == SessionHelper.GetNameIdentifier(User)).ToList();
        }
       

       return View();
        }




    // registo de citas horas
    public IActionResult SetRegistroH(){
        HorarioCita hor = new HorarioCita(){
        usuario=_registro.nombre,
        fecha=_registro.fecha,
        hora=_registro.hora
        };

        CitaBD.HorarioC.Add(hor);
        CitaBD.SaveChanges();
        return RedirectToAction("Agenda");
        
    }

    public IActionResult EliminarHora(int id){
        var _hor = CitaBD.HorarioC.Find(id);
        if(_hor == null){
            return StatusCode(404);
        }
        CitaBD.HorarioC.Remove(_hor);
        CitaBD.SaveChanges();
        return RedirectToAction("Agenda");
    }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
