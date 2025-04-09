using Core.Backend.Package.Data;

namespace ugyfelkezelo_api.Data;

public class Ugyfel : BaseEntity
{
    public string Nev { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telefonszam { get; set; } = null!;
}