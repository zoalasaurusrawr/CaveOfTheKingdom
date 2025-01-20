using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Section1
{
    public uint Field1 { get; set; }
    public uint Field2 { get; set; }
}