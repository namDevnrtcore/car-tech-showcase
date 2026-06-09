// ============================================
// 📁 Models/Order.cs - Order Entity
// ============================================

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarTechShowcase.Models;

[Table("orders")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? ProductName { get; set; }

    [Column(TypeName = "nvarchar(500)")]
    public string? Price { get; set; }

    public int? Quantity { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string? TotalAmount { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string? FullName { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string? Phone { get; set; }

    [Column(TypeName = "nvarchar(700)")]
    public string? Img { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}