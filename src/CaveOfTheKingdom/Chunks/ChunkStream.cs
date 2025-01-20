using CaveOfTheKingdom.CaveRelatedBinaryFiles;

namespace CaveOfTheKingdom.Chunks;
public class ChunkStream
{
    public Vertex[] Vertices { get; set; } = [];
    public uint[] Indices { get; set; } = [];

    public static ChunkStream Read(BinaryReader reader, Chunk chunk, Func<uint, Vector3Struct> unpack)
    {
        var vertices = new List<Vertex>();
        var indices = new List<uint>();

        while (reader.BaseStream.Position < chunk.CompressionInfo.DecompressedVertexStreamSize)
        {
            var position = unpack(reader.ReadUInt32());
            var normal = unpack(reader.ReadUInt32());
            var tangent = unpack(reader.ReadUInt32());
            var texCoord = unpack(reader.ReadUInt32());
            var color = unpack(reader.ReadUInt32());
            var weights = unpack(reader.ReadUInt32());
            var misc = unpack(reader.ReadUInt32());

            vertices.Add(new Vertex
            {
                Position = position,
                Normal = normal,
                TexCoords = texCoord,
                Tangent = tangent,
                Bitangent = color,
                Weights = weights,
                Misc = misc
            });
        }

        while (reader.BaseStream.Position < chunk.CompressionInfo.CompressedIndexStreamSize)
        {
            var index = reader.ReadUInt16();
            indices.Add(index);
        }

        return new ChunkStream
        {
            Vertices = vertices.ToArray(),
            Indices = indices.ToArray()
        };
    }

    public static Vector3Struct UnpackUInt1010102Vector3(uint packedValue)
    {
        float x = ((packedValue >> 0) & 0x3FF) / 1023.0f - 1.0f;
        float y = ((packedValue >> 10) & 0x3FF) / 1023.0f - 1.0f;
        float z = ((packedValue >> 20) & 0x3FF) / 1023.0f - 1.0f;
        return new Vector3Struct { X = x, Y = y, Z = z};
    }

    public static Vector4Struct UnpackUInt1010102Vector4(uint packedValue)
    {
        float x = ((packedValue >> 0) & 0x3FF) / 1023.0f - 1.0f;
        float y = ((packedValue >> 10) & 0x3FF) / 1023.0f - 1.0f;
        float z = ((packedValue >> 20) & 0x3FF) / 1023.0f - 1.0f;
        float w = ((packedValue >> 30) & 0x3) / 3.0f * 2.0f - 1.0f;
        return new Vector4Struct { X = x, Y = y, Z = z, W = w };
    }
}