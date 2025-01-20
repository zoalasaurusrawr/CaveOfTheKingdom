using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Section7
{
    public uint Field1 { get; set; }
    public uint Field2 { get; set; }
    public short Field3 { get; set; }
    public short Field4 { get; set; }
}