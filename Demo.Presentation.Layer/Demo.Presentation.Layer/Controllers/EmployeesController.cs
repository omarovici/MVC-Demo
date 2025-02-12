using Business.Logic.Layer.Interfaces;
using Demo.Data.Access.Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.Presentation.Layer.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _repository;
    private readonly IDepartmentRepository _departmentRepository;

    public EmployeesController(IEmployeeRepository repository, IDepartmentRepository departmentRepository)
    {
        _repository = repository;
        _departmentRepository = departmentRepository;
    }

    public IActionResult Index()
    {
        var employees = _repository.GetAllWithDepartment();
        return View(employees);
    }

    public IActionResult Create()
    {
        var departments = _departmentRepository.GetAll();
        SelectList departmentsList = new SelectList(departments, "Id", "Name");
        ViewBag.Departments = departmentsList;
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _repository.Create(employee);
            return RedirectToAction("Index");
        }
        return View(employee);
    }
    public IActionResult Details(int? id) => EmployeeControlHandler(id , nameof(Details));
    public IActionResult Edit(int? id) => EmployeeControlHandler(id , nameof(Edit));
    public IActionResult Delete(int? id) => EmployeeControlHandler(id , nameof(Delete));
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmDelete(int? id)
    {
        var employee = _repository.Get(id.Value);
        if(employee == null) return NotFound();
        _repository.Delete(employee);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit([FromRoute] int id, Employee employee)
    {
        if (id != employee.Id) return BadRequest();
        try
        {
            if (ModelState.IsValid)
            {
                _repository.Update(employee);
                TempData["Success"] = "Employee Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        return View(employee);
        
    }
    private IActionResult EmployeeControlHandler(int? id , string viewName)
    {
        if(!id.HasValue) return BadRequest();
        var employee = _repository.Get(id.Value);
        if(employee == null) return NotFound();
        return View(viewName , employee);
    }
}