using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Section3
{
    public ushort Field1 { get; set; }
    public ushort Field2 { get; set; }
}