using System.Numerics;
using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Vector3Struct
{
    public Vector3Struct()
    {
    }

    public Vector3Struct(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vector3 AsVector3()
    {
        return new Vector3(X, Y, Z);
    }
}