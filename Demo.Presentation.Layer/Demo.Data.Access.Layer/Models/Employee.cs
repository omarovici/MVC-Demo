using System.ComponentModel.DataAnnotations;

namespace Demo.Data.Access.Layer.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    [DataType(DataType.Currency)]
    public decimal Salary { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Phone { get; set; }
    public bool IsActive { get; set; }
}