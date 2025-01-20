namespace CaveOfTheKingdom.Chunks;

[Flags]
public enum CompressionType : byte
{
    None = 0,
    Zstd = 1,
    MeshCodec = 2,
}
