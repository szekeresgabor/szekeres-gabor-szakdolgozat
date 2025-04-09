using Core.Backend.Package.Data;

namespace szerzodeskezelo_api.Data;

public class Szerzodes : BaseEntity
{
    public string Azonosito { get; set; } = null!;
    public DateTime KotesDatuma { get; set; }
    public DateTime? LejaratDatuma { get; set; }
    public string? Megjegyzes { get; set; }
    public decimal Osszeg { get; set; }
    public Guid UgyfelId { get; set; }
    public Guid? DokumentumId { get; set; }
}
