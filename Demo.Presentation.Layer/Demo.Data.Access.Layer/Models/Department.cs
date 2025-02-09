using System.ComponentModel.DataAnnotations;

namespace Demo.Data.Access.Layer.Models;

public class Department
{
    public int Id { get; set; }
    [Range(0,500)]
    public int Code { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
}