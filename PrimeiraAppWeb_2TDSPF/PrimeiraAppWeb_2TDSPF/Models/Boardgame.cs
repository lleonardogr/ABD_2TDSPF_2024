using System.ComponentModel.DataAnnotations;

namespace PrimeiraAppWeb_2TDSPF.Models;

public class Boardgame
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
}