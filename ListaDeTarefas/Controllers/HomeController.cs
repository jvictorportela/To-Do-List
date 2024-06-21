using ListaDeTarefas.Data;
using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string id)
    {
        var filters = new Filters(id);

        ViewBag.Filters = filters;
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Status = _context.Statuses.ToList();
        ViewBag.Expiration = Filters.ExpirationValuesFilter;
        
        IQueryable<TaskTD> consulta = _context.Tasks
                                     .Include(c => c.Category)
                                     .Include(s => s.Status);


        if (filters.HasACategory)
        {
            consulta = consulta.Where(t => t.CategoryId == filters.CategoryId);
        }

        if (filters.HasAExpiration)
        {
            var today = DateTime.Today;

            if (filters.IsPast)
            {
                consulta = consulta.Where(t => t.ExpirationDate < today);
            }

            if (filters.IsFuture)
            {
                consulta = consulta.Where(t => t.ExpirationDate > today);
            }

            if (filters.IsToday)
            {
                consulta = consulta.Where(t => t.ExpirationDate == today);
            }
        }

        if (filters.HasAStatus)
        {
            consulta = consulta.Where(t => t.StatusId == filters.StatusId);
        }

        var tasks = consulta.OrderBy(t => t.ExpirationDate).ToList();


        return View(tasks);
    }

    public IActionResult Adicionar()
    {
        ViewBag.Categories = _context.Categories.ToList();
        ViewBag.Status = _context.Statuses.ToList();

        var task = new TaskTD { StatusId = "aberto" };

        return View(task);
    }

    [HttpPost]
    public IActionResult Filtrar(string[] filtro)
    {
        string id = string.Join('-', filtro);
        return RedirectToAction("Index", new {Id = id});
    }

    [HttpPost]
    public IActionResult MarcarCompleto([FromRoute] string id, TaskTD tarefaSelecionada)
    {
        tarefaSelecionada = _context.Tasks.Find(tarefaSelecionada.Id)!;

        if (tarefaSelecionada is not null)
        {
            tarefaSelecionada.StatusId = "completo";
            _context.SaveChanges();
        }

        return RedirectToAction("Index", new { id });
    }

    [HttpPost]
    public IActionResult Adicionar(TaskTD task)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Status = _context.Statuses.ToList();

            return View(task);
        }
    }

    [HttpPost]
    public IActionResult DeletarCompletos(string id)
    {
        var paraDeletar = _context.Tasks.Where(s => s.StatusId.Equals("completo")).ToList();

        foreach (var task in paraDeletar)
        {
            _context.Tasks.Remove(task);
        }

        _context.SaveChanges();

        return RedirectToAction("Index", new {Id = id});
    }
}
