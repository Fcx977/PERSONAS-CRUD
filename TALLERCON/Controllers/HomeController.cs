using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TALLERCON.Models;
using TALLERCON.Models.View_Models;

namespace TALLERCON.Controllers
{
    public class HomeController : Controller
    {
        private readonly TALLERCONContext _DBContext;

        public HomeController(TALLERCONContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Persona> Lista = _DBContext.Personas.Include(c => c.oRol).ToList();
            return View(Lista);
        }
        [HttpGet]
        public IActionResult Persona_Detalle(int idPersona)
        {

            PersonaVM oPersonaVM = new PersonaVM()
            {
                oPersona = new Persona(),
                oListaRol = _DBContext.Roles.Select(rol => new SelectListItem()
                {
                    Text = rol.Descripcion,
                    Value = rol.IdRol.ToString()


                }).ToList()

            };
            if (idPersona != 0)
            {
                oPersonaVM.oPersona = _DBContext.Personas.Find(idPersona);

            }



            return View(oPersonaVM);
        }

        [HttpPost]
        public IActionResult Persona_Detalle(PersonaVM oPersonaVM)
        {
            if(oPersonaVM.oPersona.DocIdentificacion == 0) {
                _DBContext.Personas.Add(oPersonaVM.oPersona);

            }
            else
            {
                _DBContext.Personas.Update(oPersonaVM.oPersona);

            }

            _DBContext.SaveChanges();



            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Eliminar(int idPersona)
        {
            Persona oPersona = _DBContext.Personas.Include(c => c.oRol).Where(e => e.DocIdentificacion == idPersona).FirstOrDefault();

            return View(oPersona);
        }
        [HttpPost]
        public IActionResult Eliminar(Persona oPersona)
        {
            _DBContext.Personas.Remove(oPersona);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }







    }
}