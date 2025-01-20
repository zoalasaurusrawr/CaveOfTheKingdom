using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

[DebuggerDisplay("{Magic}, CrbinFilesize: {CrbinFilesize}, CompressionType: {CompressionType}, CrbinId: {CrbinId}, Transform: {Transform}, ChunkInfo: {ChunkInfo}")]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Header
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public string Magic;

    public uint CrbinFilesize;
    public CrbinCompressionType CompressionType;
    public uint CrbinId;
    public Matrix3x4 Transform;

    public Section UnknownSection1;
    public Section UnknownSection2;
    public Section UnknownSection3;
    public Section UnknownSection4;

    public uint Scale;
    public Sections ChunkInfo;
    public uint MapStatic;
    public uint Reserve17;
    public Vector3Struct Origin;
    public float Reserve21;
    public uint VertexStride;
    public Box3 LocalBounds;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] Reserved1;

    public SectionsQuad QuadInfo;
    public Box3 WorldBounds;
    public Box3 FrustumBounds;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
    public uint[] Reserved2;
}