// ============================================
// 📁 Models/News.cs - News Entity
// ============================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarTechShowcase.Models;

[Table("news")]
public class News
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar")]
    public string? Title { get; set; }

    [Column(TypeName = "nvarchar")]
    public string? Summary { get; set; }

    [Column(TypeName = "nvarchar")]
    public string? Content { get; set; }

    [Column(TypeName = "nvarchar")]
    public string? Img { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}