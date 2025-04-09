using Core.Backend.Package.Data;

namespace panaszkezelo_api.Data;

public class Panasz : BaseEntity
{
    public string Cim { get; set; } = string.Empty;
    public string Leiras { get; set; } = string.Empty;
    public DateTime BejelentesDatuma { get; set; }
    public string Statusz { get; set; } = "Beérkezett"; // Pl. "Beérkezett", "Folyamatban", "Lezárt"
    public Guid UgyfelId { get; set; }
}
