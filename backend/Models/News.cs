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

    [Column(TypeName = "nvarchar(500)")]
    public string? Title { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string? Summary { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? Content { get; set; }

    [Column(TypeName = "nvarchar(700)")]
    public string? Img { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}