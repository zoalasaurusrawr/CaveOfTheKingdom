using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Box3
{
    public Vector3Struct Min { get; set; }
    public Vector3Struct Max { get; set; }

    public Vector3Struct Scale
    {
        get
        {
            return new Vector3Struct(
                Max.X - Min.X,
                Max.Y - Min.Y,
                Max.Z - Min.Z
            );
        }
    }
}