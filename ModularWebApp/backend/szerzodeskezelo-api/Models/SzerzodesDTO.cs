namespace szerzodeskezelo_api.Models;

public class SzerzodesDto
{
    public Guid Id { get; set; }
    public string Azonosito { get; set; } = null!;
    public DateTime KotesDatuma { get; set; }
    public DateTime? LejaratDatuma { get; set; }
    public string? Megjegyzes { get; set; }
    public Guid UgyfelId { get; set; }
    public Guid? DokumentumId { get; set; }
    public decimal Osszeg { get; set; }
}