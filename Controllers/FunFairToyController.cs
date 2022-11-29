using Microsoft.AspNetCore.Mvc;
using AdministracaoShrekPark.Models;

namespace AdministracaoShrekPark.Controllers;

public class FunFairToyController : Controller
{
    private readonly ShrekParkManagerContext _context;

    public FunFairToyController (ShrekParkManagerContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {
        return View(_context.FunFairToys);
    }

    public IActionResult Show(int id)
    {
        FunFairToy funFairToys = _context.FunFairToys.Find(id);

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
    public IActionResult Create([FromForm] FunFairToy funFairToyViewModel)
    {
        if(!ModelState.IsValid){
            return View("Create");
        }

        if(_context.FunFairToys.Find(funFairToyViewModel.Id) == null)
        {
            FunFairToy funFairToys = new FunFairToy(funFairToyViewModel.Id,funFairToyViewModel.Localization,funFairToyViewModel.NumberOfCarousels,funFairToyViewModel.NumberOfBumperCars,funFairToyViewModel.NumberOfRollerCoasters);
            _context.FunFairToys.Add(funFairToys);
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
        FunFairToy funFairToys = _context.FunFairToys.Find(id);

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
    public IActionResult Update([FromForm] FunFairToy funFairToyViewModel)
    {
        if(!ModelState.IsValid){
            return View();
        }

        FunFairToy funFairToys = _context.FunFairToys.Find(funFairToyViewModel.Id);
        
        funFairToys.Localization = funFairToyViewModel.Localization;
        funFairToys.NumberOfCarousels = funFairToyViewModel.NumberOfCarousels;
        funFairToys.NumberOfBumperCars = funFairToyViewModel.NumberOfBumperCars;
        funFairToys.NumberOfRollerCoasters = funFairToyViewModel.NumberOfRollerCoasters;
        _context.SaveChanges();
        return RedirectToAction("List");
    }

    public IActionResult Delete(int id)
    {
        _context.FunFairToys.Remove(_context.FunFairToys.Find(id));
        _context.SaveChanges();
        return View();
    }
}