using CaveOfTheKingdom.Chunks;

namespace Unit.Tests.TheoryData;

public class ChunkHeaderTestDataCollection : TheoryData<ChunkHeaderTestData>
{
    public ChunkHeaderTestDataCollection()
    {
        Add(new ChunkHeaderTestData
        {
            CompressedChunkFilename = "Assets/Compressed/Cave_Dummy/C.crbin.60cd2fe4/000000.chunk",
            DecompressedChunkFilename = "Assets/Decompressed/Cave_Dummy/C.crbin.60cd2fe4/000000.chunk",
            ExpectedHash = 1624059876,
            ExpectedDecompressedVertexStreamSize = 24052,
            ExpectedDecompressedIndexStreamSize = 5616,
            ExpectedDecompressedChunkFileSize = 65536,
            ExpectedCompressedVertexStreamSize = 3700,
            ExpectedCompressedIndexStreamSize = 1387,
            ExpectedWorkingMemorySize = 1243600,
            ExpectedCompressionType = CompressionType.MeshCodec,
        });
    }
}

public class ChunkHeaderTestData
{
    public string CompressedChunkFilename { get; set; } = string.Empty;
    public string DecompressedChunkFilename { get; set; } = string.Empty;
    public uint ExpectedHash { get; set; }
    public uint ExpectedDecompressedVertexStreamSize { get; set; }
    public uint ExpectedDecompressedIndexStreamSize { get; set; }
    public uint ExpectedDecompressedChunkFileSize { get; set; }
    public uint ExpectedCompressedVertexStreamSize { get; set; }
    public uint ExpectedCompressedIndexStreamSize { get; set; }
    public uint ExpectedWorkingMemorySize { get; set; }
    public CompressionType ExpectedCompressionType { get; set; }
}