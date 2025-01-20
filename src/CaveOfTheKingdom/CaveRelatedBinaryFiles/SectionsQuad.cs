using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SectionsQuad
{
    public Section Section1 { get; set; }
    public Section Section2 { get; set; }
    public Section Section3 { get; set; }
    public Section Section4 { get; set; }
    public Section Section5 { get; set; }
    public Section Section6 { get; set; }
    public Section Section7 { get; set; }
    public Section Section8 { get; set; }
    public Section CrbinOffset { get; set; }
}