using System.Security.Cryptography;

namespace Core.Backend.Package.Utils;

public static class RsaKeyLoader
{
    public static RSA LoadPrivateKey(string path)
    {
        var rsa = RSA.Create();
        var privateKey = File.ReadAllText(path);
        rsa.ImportFromPem(privateKey.ToCharArray());
        return rsa;
    }

    public static RSA LoadPublicKey(string path)
    {
        var rsa = RSA.Create();
        var publicKey = File.ReadAllText(path);
        rsa.ImportFromPem(publicKey.ToCharArray());
        return rsa;
    }
}
