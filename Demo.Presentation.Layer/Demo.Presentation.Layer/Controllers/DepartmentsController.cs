using Business.Logic.Layer.Interfaces;
using Demo.Data.Access.Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Layer.Controllers;

public class DepartmentsController : Controller
{
    // private readonly IGenaricRepository<Department> _repository;
    private readonly IDepartmentRepository _repository;
    public DepartmentsController(IDepartmentRepository departmentRepository)
    {
        _repository = departmentRepository;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var departments = _repository.GetAll();
        return View(departments);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Department department)
    {
        if (ModelState.IsValid)
        {
            _repository.Create(department);
            return RedirectToAction("Index");
        }
        return View(department);
    }

    public IActionResult Details(int? id) => DepartmentControlHandler(id , nameof(Details));
    
    public IActionResult Edit(int? id) => DepartmentControlHandler(id , nameof(Edit));
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([FromRoute]int id,Department department)
    {
        if(id != department.Id) return BadRequest();
        try
        {
            if (ModelState.IsValid)
            {
                _repository.Update(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        return View(department);
    }
    public IActionResult Delete(int? id) => DepartmentControlHandler(id , nameof(Delete));
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmDelete(int? id)
    {
        var department = _repository.Get(id.Value);
        if(department == null) return NotFound();
        _repository.Delete(department);
        return RedirectToAction("Index");
    }
    
    private IActionResult DepartmentControlHandler(int? id , string viewName)
    {
        if(!id.HasValue) return BadRequest();
        var department = _repository.Get(id.Value);
        if(department == null) return NotFound();
        return View(viewName , department);
    }
}