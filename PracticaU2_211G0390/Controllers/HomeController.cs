using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PracticaU2_211G0390.Models;
using PracticaU2_211G0390.Models.ViewModels;
using System.Numerics;

namespace PracticaU2_211G0390.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MapaCurricularContext context = new MapaCurricularContext();
            var carr = context.Carreras.
                OrderBy(x => x.Id);
            if (carr == null)
            {
                return RedirectToAction("Index");
            }
            return View(carr);
        }

        //esto va cuando va algo en específico. 
        //Descripción de: Tal carrera
        [Route("Info/{nombre}")]
        public IActionResult Info ( string nombre)
        {
            nombre = nombre.Replace("-", " ");
            MapaCurricularContext context = new MapaCurricularContext();
            Carreras? carreras = context.Carreras.
               FirstOrDefault(x=>x.Nombre==nombre);
  
			return View(carreras);
        }



        [Route("MapaCurricular/{nombre}")]
        public IActionResult MapaCurricular(string nombre)
        {
            nombre = nombre.Replace("-", " ");
           
            MapaCurricularContext context = new MapaCurricularContext();
            MapaCurricularViewModel vm = new MapaCurricularViewModel();
            Carreras? carrera = context.Carreras
                .Include(x => x.Materias)
                .FirstOrDefault(x => x.Nombre == nombre);

            if (carrera == null)
            {
                return RedirectToAction("Index");
            }

            vm.Nombre = carrera.Nombre;
            vm.Creditos = (uint)carrera.Materias.Sum(x => x.Creditos);
            vm.numSemestres = carrera.Materias.Max(x => x.Semestre);
            vm.Plan = carrera.Plan;
            vm.Materias = carrera.Materias;
          
            return View(vm);

        }

    }
}
