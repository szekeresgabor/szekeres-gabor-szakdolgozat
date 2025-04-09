using Core.Backend.Package.Data;

namespace storage_api.Data;

public class StoredFile : BaseEntity
{
    public string FileName { get; set; } = null!;
    public string FilePath { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public long Size { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}