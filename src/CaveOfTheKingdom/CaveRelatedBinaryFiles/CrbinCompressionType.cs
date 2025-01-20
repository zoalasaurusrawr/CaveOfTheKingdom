namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

public enum CrbinCompressionType : uint
{
    Unknown = 0,
    Uncompressed = 2,
    Zstd = 3,
    MeshCodec = 5
}