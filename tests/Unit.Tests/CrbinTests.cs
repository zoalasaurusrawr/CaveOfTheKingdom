using CaveOfTheKingdom.CaveRelatedBinaryFiles;
using Shouldly;
using Unit.Tests.TheoryData;

namespace Unit.Tests;
public class CrbinTests
{
    [Theory]
    [ClassData(typeof(CrbinFileTestDataCollection))]
    public void Read_Crbin_Succeeds(CrbinFileTestData testData)
    {
        using (var stream = new FileStream(testData.Filename, FileMode.Open))
        {
            using (var reader = new BinaryReader(stream))
            {
                var crbinFile = CrbinFile.Read(reader);

                Assert.NotNull(crbinFile);
                crbinFile.Magic.ShouldBe(testData.Magic);
                crbinFile.CrbinFilesize.ShouldBe(testData.ExpectedFileSize);
                crbinFile.CrbinId.ShouldBe(testData.ExpectedCrbinId);
                crbinFile.CompressionType.ShouldBe(testData.ExpectedCompressionType);
                crbinFile.Section1.Length.ShouldBe(testData.ExpectedSection1Count);
                crbinFile.Section2.Length.ShouldBe(testData.ExpectedSection2Count);
                crbinFile.Section3.Length.ShouldBe(testData.ExpectedSection3Count);
                crbinFile.Section4.Length.ShouldBe(testData.ExpectedSection4Count);
                crbinFile.Section5.Length.ShouldBe(testData.ExpectedSection5Count);
                crbinFile.Section6.Length.ShouldBe(testData.ExpectedSection6Count);
                crbinFile.Section7.Length.ShouldBe(testData.ExpectedSection7Count);
                crbinFile.Section8.Length.ShouldBe(testData.ExpectedSection8Count);
                crbinFile.ChunkFiles.Length.ShouldBe(testData.ExpectedChunkFileCount);
            }
        }
    }
}
