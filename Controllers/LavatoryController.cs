using Microsoft.AspNetCore.Mvc;
using AdministracaoShrekPark.Models;

namespace AdministracaoShrekPark.Controllers;

public class LavatoryController : Controller
{
    private readonly ShrekParkManagerContext _context;

    public LavatoryController (ShrekParkManagerContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {
        return View(_context.Lavatories);
    }

    public IActionResult Show(int id)
    {
        Lavatory lavatory = _context.Lavatories.Find(id);

        if(lavatory == null)
        {
            return NotFound();
        }
        else
        {
            return View(lavatory);
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] Lavatory lavatoryViewModel)
    {
        if(!ModelState.IsValid){
            return View("Create");
        }

        if(_context.Lavatories.Find(lavatoryViewModel.Id) == null)
        {
            Lavatory lavatory = new Lavatory(lavatoryViewModel.Id,lavatoryViewModel.Localization,lavatoryViewModel.NumberOfBooths,lavatoryViewModel.Mirror,lavatoryViewModel.ToiletPaper);
            _context.Lavatories.Add(lavatory);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
            return Content("Lavatório já criado no banco de dados do parque, tente outro id");
        }
    }

    public IActionResult Update(int id)
    {
        Lavatory lavatory = _context.Lavatories.Find(id);

        if(lavatory == null)
        {
            return Content("Lavatório não existente, crie com este id ou tente outro");
        }
        else
        {
            return View(lavatory);
        }

    }

    [HttpPost]
    public IActionResult Update([FromForm] Lavatory lavatoryViewModel)
    {
        if(!ModelState.IsValid){
            return View();
        }

        Lavatory lavatory = _context.Lavatories.Find(lavatoryViewModel.Id);
        
        lavatory.Localization = lavatoryViewModel.Localization;
        lavatory.NumberOfBooths = lavatoryViewModel.NumberOfBooths;
        lavatory.Mirror = lavatoryViewModel.Mirror;
        lavatory.ToiletPaper = lavatoryViewModel.ToiletPaper;
        _context.SaveChanges();
        return RedirectToAction("List");
    }

    public IActionResult Delete(int id)
    {
        _context.Lavatories.Remove(_context.Lavatories.Find(id));
        _context.SaveChanges();
        return View();
    }
}