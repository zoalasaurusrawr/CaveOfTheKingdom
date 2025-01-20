using CaveOfTheKingdom.Chunks;
using Shouldly;
using Unit.Tests.TheoryData;

namespace Unit.Tests;

public class ChunkTests
{
    [Theory]
    [ClassData(typeof(ChunkHeaderTestDataCollection))]
    public void Read_Chunk_Header_Succeeds(ChunkHeaderTestData testData)
    {
        using (var stream = new FileStream(testData.CompressedChunkFilename, FileMode.Open, FileAccess.Read))
        using (var reader = new BinaryReader(stream))
        {
            Chunk chunk = Chunk.Read(reader);

            chunk.Hash.ShouldBe(testData.ExpectedHash);
            chunk.CompressionInfo.DecompressedVertexStreamSize.ShouldBe(testData.ExpectedDecompressedVertexStreamSize);
            chunk.CompressionInfo.DecompressedIndexStreamSize.ShouldBe(testData.ExpectedDecompressedIndexStreamSize);
            chunk.CompressionInfo.DecompressedChunkFileSize.ShouldBe(testData.ExpectedDecompressedChunkFileSize);
            chunk.CompressionInfo.Flags.CompressionType.ShouldBe(testData.ExpectedCompressionType);
            chunk.CompressionInfo.CompressedVertexStreamSize.ShouldBe(testData.ExpectedCompressedVertexStreamSize);
            chunk.CompressionInfo.CompressedIndexStreamSize.ShouldBe(testData.ExpectedCompressedIndexStreamSize);
            chunk.CompressionInfo.WorkingMemorySize.ShouldBe(testData.ExpectedWorkingMemorySize);
        }
    }

    [Theory]
    [ClassData(typeof(ChunkHeaderTestDataCollection))]
    public void Read_Decompressed_Chunk_Stream_Succeeds(ChunkHeaderTestData testData)
    {
        Chunk chunk;
        using (var stream = new FileStream(testData.CompressedChunkFilename, FileMode.Open, FileAccess.Read))
        using (var reader = new BinaryReader(stream))
        {
            chunk = Chunk.Read(reader);
        }

        using (var stream = new FileStream(testData.DecompressedChunkFilename, FileMode.Open, FileAccess.Read))
        using (var reader = new BinaryReader(stream))
        {
            var chunkStream = ChunkStream.Read(reader, chunk, ChunkStream.UnpackUInt1010102Vector3);
            chunkStream.ShouldNotBeNull();
            int expectedVertexCount = (int)chunk.CompressionInfo.DecompressedVertexStreamSize / Chunk.CompressedVertexSizeInBytes;
            chunkStream.Vertices.Count().ShouldBe(expectedVertexCount);
        }
    }
}