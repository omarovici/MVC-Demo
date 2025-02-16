using AutoMapper;
using Business.Logic.Layer.Interfaces;
using Demo.Data.Access.Layer.Models;
using Demo.Presentation.Layer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.Presentation.Layer.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeeRepository _repository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public EmployeesController(IEmployeeRepository repository, IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _repository = repository;
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var employees = _repository.GetAllWithDepartment();
        var employeesVM = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
        return View(employeesVM);
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
    public IActionResult Create(EmployeeViewModel employeeVM)
    {
        if (ModelState.IsValid)
        {
            var employee = _mapper.Map<Employee>(employeeVM);
            _repository.Create(employee);
            return RedirectToAction("Index");
        }
        return View(employeeVM);
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
    public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVM)
    {
        if (id != employeeVM.Id) return BadRequest();
        try
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeVM);
                _repository.Update(employee);
                TempData["Success"] = "Employee Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(employeeVM);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
        return View(employeeVM);
        
    }
    private IActionResult EmployeeControlHandler(int? id , string viewName)
    {
        if (viewName == nameof(Edit))
        {
            var departments = _departmentRepository.GetAll();
            SelectList departmentsList = new SelectList(departments, "Id", "Name");
            ViewBag.Departments = departmentsList;
        }
        if(!id.HasValue) return BadRequest();
        var employee = _repository.Get(id.Value);
        if(employee == null) return NotFound();
        var employeeVM = _mapper.Map<EmployeeViewModel>(employee);
        return View(viewName , employeeVM);
    }
}