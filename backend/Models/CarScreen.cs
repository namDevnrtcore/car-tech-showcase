// ============================================
// 📁 Models/CarScreen.cs - CarScreen Entity
// ============================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarTechShowcase.Models;

[Table("carScreen")]
public class CarScreen
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string ScreenName { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(500)")]
    public string? Location { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? Note { get; set; }

    public int? TypeId { get; set; }

    public bool IsActive { get; set; } = true;
}