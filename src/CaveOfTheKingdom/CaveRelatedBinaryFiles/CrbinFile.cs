using System.Numerics;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace CaveOfTheKingdom.CaveRelatedBinaryFiles;

public class CrbinFile
{
    public string Magic { get; set; } = string.Empty;

    public uint CrbinFilesize { get; set; }
    public CrbinCompressionType CompressionType { get; set; }
    public uint CrbinId { get; set; }
    public Matrix3x4 Matrix3x4 { get; set; }
    [JsonIgnore]
    public Matrix4x4 Transform { get; set; }

    public Section UnknownSection1 { get; set; }
    public Section UnknownSection2 { get; set; }
    public Section UnknownSection3 { get; set; }
    public Section UnknownSection4 { get; set; }

    public uint Scale { get; set; }
    public Section1[] Section1 { get; set; } = [];
    public Section2[] Section2 { get; set; } = [];
    public Section3[] Section3 { get; set; } = [];
    public Box3[] Section4 { get; set; } = [];
    public ulong[] Section5 { get; set; } = [];
    public Section6[] Section6 { get; set; } = [];
    public Section7[] Section7 { get; set; } = [];
    public Box4[] Section8 { get; set; } = [];
    public ChunkFileInfo[] ChunkFiles { get; set; } = [];
    public uint MapStatic { get; set; }
    public uint Reserve17 { get; set; }
    public Vector3Struct Origin { get; set; }
    public float Reserve21 { get; set; }
    public uint VertexStride { get; set; }
    public Box3 LocalBounds { get; set; }
    public uint[] Reserved1 { get; set; } = [];

    public SectionsQuad QuadInfo { get; set; }
    public Box3 WorldBounds { get; set; }
    public Box3 FrustumBounds { get; set; }
    public uint[] Reserved2 { get; set; } = [];

    public static CrbinFile Read(BinaryReader reader)
    {
        int headerSize = Marshal.SizeOf<Header>();
        byte[] headerBytes = reader.ReadBytes(headerSize);

        GCHandle handle = GCHandle.Alloc(headerBytes, GCHandleType.Pinned);
        Header header = Marshal.PtrToStructure<Header>(handle.AddrOfPinnedObject());
        handle.Free();

        Console.WriteLine($"Magic: {header.Magic}");
        Console.WriteLine($"File Size: {header.CrbinFilesize}");
        Console.WriteLine($"Compression Type: {header.CompressionType}");
        Console.WriteLine($"Transform Matrix: {header.Transform.M00}, {header.Transform.M01}, ...");
        Console.WriteLine($"Scale: {header.Scale}");
        Console.WriteLine($"Local Bounds: Min ({header.LocalBounds.Min.X}, {header.LocalBounds.Min.Y}, {header.LocalBounds.Min.Z}), " +
                          $"Max ({header.LocalBounds.Max.X}, {header.LocalBounds.Max.Y}, {header.LocalBounds.Max.Z})");

        var result = ReadSections(reader, header);
        return result;
    }

    private static CrbinFile ReadSections(BinaryReader reader, Header header)
    {
        var result = new CrbinFile();

        result.Magic = header.Magic;
        result.CrbinFilesize = header.CrbinFilesize;
        result.CrbinId = header.CrbinId;
        result.CompressionType = header.CompressionType;
        result.Matrix3x4 = header.Transform;
        result.Transform = header.Transform.ToMatrix4x4();
        result.MapStatic = header.MapStatic;
        result.LocalBounds = header.LocalBounds;
        result.WorldBounds = header.WorldBounds;
        result.FrustumBounds = header.FrustumBounds;
        result.VertexStride = header.VertexStride;
        result.Origin = header.Origin;
        result.UnknownSection1 = header.UnknownSection1;
        result.UnknownSection2 = header.UnknownSection2;
        result.UnknownSection3 = header.UnknownSection3;
        result.UnknownSection4 = header.UnknownSection4;
        result.Scale = header.Scale;
        result.Reserve17 = header.Reserve17;
        result.Reserve21 = header.Reserve21;
        result.Reserved1 = header.Reserved1;
        result.Reserved2 = header.Reserved2;

        result.Section1 = ReadSection<Section1>(reader, header.ChunkInfo.Section1, "Section1");
        result.Section2 = ReadSection<Section2>(reader, header.ChunkInfo.Section2, "Section2");
        result.Section3 = ReadSection<Section3>(reader, header.ChunkInfo.NodeRelationships, "NodeRelationships");
        result.Section4 = ReadSection<Box3>(reader, header.ChunkInfo.NodeBounds, "NodeBounds");
        result.Section5 = ReadSection<ulong>(reader, header.ChunkInfo.Section5, "Section5");
        result.Section6 = ReadSection<Section6>(reader, header.ChunkInfo.Section6, "Section6");
        result.Section7 = ReadSection<Section7>(reader, header.ChunkInfo.Section7, "Section7");
        result.Section8 = ReadSection<Box4>(reader, header.ChunkInfo.Section8, "Section8");
        result.ChunkFiles = ReadSection<ChunkFileInfo>(reader, header.ChunkInfo.ChunkFileInfo, "ChunkFileInfo");

        return result;
    }

    private static T[] ReadSection<T>(BinaryReader reader, Section sectionOffset, string sectionName) where T : struct
    {
        if (sectionOffset.Offset == 0 || sectionOffset.Count == 0)
        {
            Console.WriteLine($"{sectionName}: Empty");
            var item = Activator.CreateInstance<T>();
            return [item];
        }

        Console.WriteLine($"{sectionName}: Offset={sectionOffset.Offset}, Count={sectionOffset.Count}");

        reader.BaseStream.Seek(sectionOffset.Offset, SeekOrigin.Begin);

        T[] results = new T[sectionOffset.Count];
        for (int i = 0; i < sectionOffset.Count; i++)
        {
            T entry = ReadStruct<T>(reader);
            results[i] = entry;
            Console.WriteLine($"\tEntry {i + 1}: {entry}");
        }

        return results;
    }

    private static T ReadStruct<T>(BinaryReader reader) where T : struct
    {
        int size = Marshal.SizeOf<T>();
        byte[] buffer = reader.ReadBytes(size);
        GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        T obj = Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject());
        handle.Free();
        return obj;
    }
}