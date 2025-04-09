namespace panaszkezelo_api.Models;

public class PanaszDto
{
    public Guid Id { get; set; }
    public string Cim { get; set; }
    public string Leiras { get; set; }
    public DateTime BejelentesDatuma { get; set; }
    public string Statusz { get; set; }
    public Guid UgyfelId { get; set; }
}