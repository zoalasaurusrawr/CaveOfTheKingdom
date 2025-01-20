using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ChunkFileInfo
{
    public uint FileSize { get; set; }
    public uint FileIndex { get; set; }
}