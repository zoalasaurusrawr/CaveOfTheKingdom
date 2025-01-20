namespace CaveOfTheKingdom.Chunks;

public struct Chunk
{
    public uint Hash { get; set; }
    public CompressionInfoHeader CompressionInfo { get; set; }
    public byte[] CompressedVertexStream { get; set; }
    public byte[] CompressedIndexStream { get; set; }
    public const int CompressedVertexSizeInBytes = 28;
    public static Chunk Read(BinaryReader reader)
    {
        var chunk = new Chunk
        {
            Hash = reader.ReadUInt32(),
            CompressionInfo = CompressionInfoHeader.Read(reader)
        };

        chunk.CompressedVertexStream = reader.ReadBytes((int)chunk.CompressionInfo.CompressedVertexStreamSize);
        chunk.CompressedIndexStream = reader.ReadBytes((int)chunk.CompressionInfo.CompressedIndexStreamSize);

        return chunk;
    }
}