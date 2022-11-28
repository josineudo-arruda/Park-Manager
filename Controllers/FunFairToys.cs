using Microsoft.AspNetCore.Mvc;
using AdministracaoShrekPark.Models;

namespace AdministracaoShrekPark.Controllers;

public class FunFairToys : Controller
{
    private readonly ShrekParkManagerContext _context;

    public FunFairToys (ShrekParkManagerContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {
        return View(_context.FunFairToys);
    }

    public IActionResult Show(int id)
    {
        FunFairToys funFairToys = _context.FunFairToy.Find(id);

        if(funFairToys == null)
        {
            return NotFound();
        }
        else
        {
            return View(funFairToys);
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] FunFairToys funFairToyViewModel)
    {
        if(!ModelState.IsValid){
            return View("Create");
        }

        if(_context.FunFairToy.Find(funFairToyViewModel.Id) == null)
        {
            FunFairToys funFairToys = new FunFairToys(funFairToyViewModel.Id,funFairToyViewModel.Localization,funFairToyViewModel.NumberOfCarousels,funFairToyViewModel.NumberOfBumperCars,funFairToyViewModel.NumberOfRollerCoasters);
            _context.FunFairToy.Add(funFairToys);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
            return Content("Brinquedo já criado no banco de dados do parque, tente outro id");
        }
    }

    public IActionResult Update(int id)
    {
        FunFairToys funFairToys = _context.FunFairToy.Find(id);

        if(funFairToys == null)
        {
            return Content("Brinquedo não existente, crie com este id ou tente outro");
        }
        else
        {
            return View(funFairToys);
        }

    }

    [HttpPost]
    public IActionResult Update([FromForm] FunFairToys funFairToyViewModel)
    {
        if(!ModelState.IsValid){
            return View();
        }

        FunFairToys funFairToys = _context.FunFairToy.Find(funFairToyViewModel.Id);
        
        funFairToys.Localization = funFairToyViewModel.Localization;
        funFairToys.NumberOfBooths = funFairToyViewModel.NumberOfBooths;
        funFairToys.Mirror = funFairToyViewModel.Mirror;
        funFairToys.ToiletPaper = funFairToyViewModel.ToiletPaper;
        _context.SaveChanges();
        return RedirectToAction("List");
    }

    public IActionResult Delete(int id)
    {
        _context.FunFairToy.Remove(_context.FunFairToy.Find(id));
        _context.SaveChanges();
        return View();
    }
}