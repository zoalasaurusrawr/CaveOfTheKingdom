using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Vector4Struct
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float W { get; set; }
}