// ============================================
// 📁 Models/Banner.cs - Banner Entity
// ============================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarTechShowcase.Models;

[Table("banner")]
public class Banner
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? Banner1 { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? Banner2 { get; set; }

    public bool IsActive { get; set; } = true;
}