using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Box4
{
    public Vector4Struct Min { get; set; }
    public Vector4Struct Max { get; set; }
}