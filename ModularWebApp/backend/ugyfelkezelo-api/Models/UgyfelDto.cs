namespace ugyfelkezelo_api.Models;

public class UgyfelDto
{
    public Guid Id { get; set; }
    public string Nev { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telefonszam { get; set; } = null!;
}
