using Microsoft.AspNetCore.Mvc;
using AdministracaoShrekPark.Models;

namespace AdministracaoShrekPark.Controllers;

public class NurseryController : Controller
{
    private readonly ShrekParkManagerContext _context;

    public NurseryController (ShrekParkManagerContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {
        return View(_context.Nurseries);
    }

    public IActionResult Show(int id)
    {
        Nursery nursery = _context.Nurseries.Find(id);

        if(nursery == null)
        {
            return NotFound();
        }
        else
        {
            return View(nursery);
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] Nursery nurseryViewModel)
    {
        if(!ModelState.IsValid){
            return View("Create");
        }

        if(_context.Nurseries.Find(nurseryViewModel.Id) == null)
        {
            Nursery nursery = new Nursery(nurseryViewModel.Id,nurseryViewModel.Name,nurseryViewModel.Leitos,nurseryViewModel.Localization);
            _context.Nurseries.Add(nursery);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
            return Content("Enfermaria já criada no banco de dados do parque, tente outro id");
        }
    }

    public IActionResult Update(int id)
    {
        Nursery nursery = _context.Nurseries.Find(id);

        if(nursery == null)
        {
            return Content("Enfermaria não existente, crie com este id ou tente outro");
        }
        else
        {
            return View(nursery);
        }

    }

    [HttpPost]
    public IActionResult Update([FromForm] Nursery nurseryViewModel)
    {
        if(!ModelState.IsValid){
            return View();
        }

        Nursery nursery = _context.Nurseries.Find(nurseryViewModel.Id);
        
        nursery.Name = nurseryViewModel.Name;
        nursery.Leitos = nurseryViewModel.Leitos;
        nursery.Localization = nurseryViewModel.Localization;
        _context.SaveChanges();
        return RedirectToAction("List"); 
    }

    public IActionResult Delete(int id)
    {
        _context.Nurseries.Remove(_context.Nurseries.Find(id));
        _context.SaveChanges();
        return View();
    }
}