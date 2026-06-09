// ============================================
// 📁 Models/Product.cs - Product Entity
// ============================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarTechShowcase.Models;

[Table("product")]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string ProductName { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Price { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string? Category { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    [Column(TypeName = "nvarchar(700)")]
    public string? Img { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? Spec { get; set; }

    public bool IsActive { get; set; } = true;
}