using System.Numerics;
using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Matrix3x4
{
    public float M00 { get; set; }
    public float M01 { get; set; }
    public float M02 { get; set; }
    public float M03 { get; set; }
    public float M10 { get; set; }
    public float M11 { get; set; }
    public float M12 { get; set; }
    public float M13 { get; set; }
    public float M20 { get; set; }
    public float M21 { get; set; }
    public float M22 { get; set; }
    public float M23 { get; set; }

    public Matrix4x4 ToMatrix4x4()
    {
        return new Matrix4x4(
            M00, M01, M02, M03, // First row (Right + Position.X)
            M10, M11, M12, M13, // Second row (Up + Position.Y)
            M20, M21, M22, M23, // Third row (Forward + Position.Z)
            0f, 0f, 0f, 1f  // Fourth row (default for homogeneous coordinates)
        );
    }
}