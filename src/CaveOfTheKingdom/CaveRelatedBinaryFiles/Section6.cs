using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Section6
{
    public short Field1 { get; set; }
    public short Field2 { get; set; }
}