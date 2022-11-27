using Microsoft.AspNetCore.Mvc;
using AdministracaoShrekPark.Models;

namespace AdministracaoShrekPark.Controllers;

public class StoreController : Controller
{
    private readonly ShrekParkManagerContext _context;

    public StoreController (ShrekParkManagerContext context)
    {
        _context = context;
    }

    public IActionResult List()
    {
        return View(_context.Stores);
    }

    public IActionResult Show(int id)
    {
        Store store = _context.Stores.Find(id);

        if(store == null)
        {
            return NotFound();
        }
        else
        {
            return View(store);
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([FromForm] Store storeViewModel)
    {
        if(!ModelState.IsValid){
            return View("Create");
        }

        if(_context.Stores.Find(storeViewModel.Id) == null)
        {
            Store store = new Store(storeViewModel.Id,storeViewModel.Brand,storeViewModel.Type,storeViewModel.Localization);
            _context.Stores.Add(store);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
        else
        {
            return Content("Loja já criada no banco de dados do parque, tente outro id");
        }
    }

    public IActionResult Update(int id)
    {
        Store store = _context.Stores.Find(id);

        if(store == null)
        {
            return Content("Loja não existente, crie com este id ou tente outro");
        }
        else
        {
            return View(store);
        }

    }

    [HttpPost]
    public IActionResult Update([FromForm] Store storeViewModel)
    {
        if(!ModelState.IsValid){
            return View();
        }

        Store store = _context.Stores.Find(storeViewModel.Id);
        
        store.Brand = storeViewModel.Brand;
        store.Type = storeViewModel.Type;
        store.Localization = storeViewModel.Localization;
        _context.SaveChanges();
        return RedirectToAction("List");
    }

    public IActionResult Delete(int id)
    {
        _context.Stores.Remove(_context.Stores.Find(id));
        _context.SaveChanges();
        return View();
    }
}