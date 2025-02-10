using System.ComponentModel.DataAnnotations;

namespace Demo.Data.Access.Layer.Models;

public class Employee
{
    public int Id { get; set; }
    [StringLength(maximumLength: 50 , MinimumLength = 5)]
    public string Name { get; set; }
    [Range(19,60)]
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