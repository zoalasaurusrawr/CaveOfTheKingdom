namespace CaveOfTheKingdom.Chunks;

public struct CompressionInfoHeader
{
    public uint DecompressedVertexStreamSize { get; set; }
    public uint DecompressedIndexStreamSize { get; set; }
    public uint DecompressedChunkFileSize { get; set; }
    public uint WorkingMemorySize { get; set; }
    public Flags Flags { get; set; }
    public uint CompressedVertexStreamSize { get; set; }
    public uint CompressedIndexStreamSize { get; set; }

    public static CompressionInfoHeader Read(BinaryReader reader)
    {
        return new CompressionInfoHeader
        {
            DecompressedVertexStreamSize = reader.ReadUInt32(),
            DecompressedIndexStreamSize = reader.ReadUInt32(),
            DecompressedChunkFileSize = reader.ReadUInt32(),
            WorkingMemorySize = reader.ReadUInt32(),
            Flags = Flags.Read(reader),
            CompressedVertexStreamSize = ReadU24(reader),
            CompressedIndexStreamSize = ReadU24(reader)
        };
    }

    private static uint ReadU24(BinaryReader reader)
    {
        byte[] bytes = reader.ReadBytes(3);
        return (uint)(bytes[0] | bytes[1] << 8 | bytes[2] << 16);
    }
}
