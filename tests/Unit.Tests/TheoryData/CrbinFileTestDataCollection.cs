using CaveOfTheKingdom.CaveRelatedBinaryFiles;

namespace Unit.Tests.TheoryData;
public class CrbinFileTestDataCollection : TheoryData<CrbinFileTestData>
{
    public CrbinFileTestDataCollection()
    {
        Add(new CrbinFileTestData
        {
            Filename = "Assets/Compressed/Cave_Dummy/C.crbin",
            Magic = "cave017",
            ExpectedFileSize = 1348,
            ExpectedCompressionType = CrbinCompressionType.MeshCodec,
            ExpectedCrbinId = 1624059876,
            ExpectedChunkFileCount = 1,
            ExpectedSection1Count = 8,
            ExpectedSection2Count = 8,
            ExpectedSection3Count = 8,
            ExpectedSection4Count = 8,
            ExpectedSection5Count = 8,
            ExpectedSection6Count = 8,
            ExpectedSection7Count = 16,
            ExpectedSection8Count = 5,
        });
    }
}

public class CrbinFileTestData
{
    public string Filename { get; set; } = string.Empty;
    public string Magic { get; set; } = string.Empty;
    public uint ExpectedFileSize { get; set; }
    public CrbinCompressionType ExpectedCompressionType { get; set; }
    public uint ExpectedCrbinId { get; set; }
    public int ExpectedSection1Count { get; set; }
    public int ExpectedSection2Count { get; set; }
    public int ExpectedSection3Count { get; set; }
    public int ExpectedSection4Count { get; set; }
    public int ExpectedSection5Count { get; set; }
    public int ExpectedSection6Count { get; set; }
    public int ExpectedSection7Count { get; set; }
    public int ExpectedSection8Count { get; set; }
    public int ExpectedChunkFileCount { get; set; }
}