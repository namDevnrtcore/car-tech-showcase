using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarTechShowcase.Models;

[Table("siteconfig")]
public class SiteConfig
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? CompanyName { get; set; } = "VinMap - Car Screen Pro";

    [Column(TypeName = "nvarchar(500)")]
    public string? AboutShort { get; set; } = "Chuyên cung cấp màn hình ô tô Android cao cấp, chất lượng hàng đầu với dịch vụ lắp đặt chuyên nghiệp.";

    [Column(TypeName = "nvarchar(500)")]
    public string? Address { get; set; } = "123 Đường ABC, Quận 1, TP.HCM";

    [Column(TypeName = "nvarchar(50)")]
    public string? Phone { get; set; } = "0123-456-789";

    [Column(TypeName = "nvarchar(100)")]
    public string? Email { get; set; } = "info@carscreen.vn";

    [Column(TypeName = "nvarchar(200)")]
    public string? WorkingHoursWeekday { get; set; } = "Thứ 2 - Thứ 7: 8:00 - 20:00";

    [Column(TypeName = "nvarchar(200)")]
    public string? WorkingHoursSunday { get; set; } = "Chủ nhật: 9:00 - 18:00";

    // Zalo phone number (for zalo.me link)
    [Column(TypeName = "nvarchar(50)")]
    public string? ZaloPhone { get; set; } = "0123456789";

    [Column(TypeName = "nvarchar(500)")]
    public string? FacebookUrl { get; set; }

    // Google Maps embed src URL
    [Column(TypeName = "nvarchar(max)")]
    public string? MapEmbedUrl { get; set; } = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4946345449366!2d106.69674841533424!3d10.762622492330086!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317529292e8d303b%3A0xc48641e33e271c69!2zMTIzIMSQxrDhu51uZyBBQkMsIFF14bqjIEjGsMG7LCAoQjox2kFDRyk!5e0!3m2!1svi!2svn!4v1705123456789";
}
