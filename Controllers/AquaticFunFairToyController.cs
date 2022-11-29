using Microsoft.AspNetCore.Mvc;
using AdministracaoShrekPark.Models;

namespace AdministracaoShrekPark.Controllers;

public class AquaticFunFairToyController : Controller
{
    private readonly ShrekParkManagerContext _context;

    public AquaticFunFairToyController (ShrekParkManagerContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {
        return View(_context.AquaticFunFairToys);
    }

    public IActionResult Show(int id)
    {
        AquaticFunFairToy aquaticFunFairToy = _context.AquaticFunFairToys.Find(id);

        if(aquaticFunFairToy == null)
        {
            return NotFound();
        }
        else
        {
            return View(aquaticFunFairToy);
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] AquaticFunFairToy aquaticFunFairToyViewModel)
    {
        if(!ModelState.IsValid){
            return View("Create");
        }

        if(_context.AquaticFunFairToys.Find(aquaticFunFairToyViewModel.Id) == null)
        {
            AquaticFunFairToy aquaticFunFairToy = new AquaticFunFairToy(aquaticFunFairToyViewModel.Id,aquaticFunFairToyViewModel.Localization,aquaticFunFairToyViewModel.NumberOfPedalBoats,aquaticFunFairToyViewModel.NumberOfFountains,aquaticFunFairToyViewModel.NumberOfSlides);
            _context.AquaticFunFairToys.Add(aquaticFunFairToy);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
            return Content("Brinquedo Aquático já criado no banco de dados do parque, tente outro id");
        }
    }

    public IActionResult Update(int id)
    {
        AquaticFunFairToy aquaticFunFairToy = _context.AquaticFunFairToys.Find(id);

        if(aquaticFunFairToy == null)
        {
            return Content("Brinquedo Aquático não existente, crie com este id ou tente outro");
        }
        else
        {
            return View(aquaticFunFairToy);
        }

    }

    [HttpPost]
    public IActionResult Update([FromForm] AquaticFunFairToy aquaticFunFairToyViewModel)
    {
        if(!ModelState.IsValid){
            return View();
        }

        AquaticFunFairToy aquaticFunFairToy = _context.AquaticFunFairToys.Find(aquaticFunFairToyViewModel.Id);
        
        aquaticFunFairToy.Localization = aquaticFunFairToyViewModel.Localization;
        aquaticFunFairToy.NumberOfBooths = aquaticFunFairToyViewModel.NumberOfBooths;
        aquaticFunFairToy.Mirror = aquaticFunFairToyViewModel.Mirror;
        aquaticFunFairToy.ToiletPaper = aquaticFunFairToyViewModel.ToiletPaper;
        _context.SaveChanges();
        return RedirectToAction("List");
    }

    public IActionResult Delete(int id)
    {
        _context.AquaticFunFairToys.Remove(_context.AquaticFunFairToys.Find(id));
        _context.SaveChanges();
        return View();
    }
}