namespace CaveOfTheKingdom.Chunks;

public struct Flags
{
    public CompressionType CompressionType { get; set; }
    public ushort Reserved { get; set; }

    public static Flags Read(BinaryReader reader)
    {
        ushort data = reader.ReadUInt16();
        return new Flags
        {
            CompressionType = (CompressionType)(data & 0b11),
            Reserved = (ushort)(data >> 2)
        };
    }
}
