#pragma pattern_limit 400000

bitfield UInt_10_10_10_2_Vector {
    unsigned X : 10;
    unsigned Y : 10;
    unsigned Z : 10;
    unsigned W : 2;
};

struct Vertex {
    UInt_10_10_10_2_Vector Position;
    UInt_10_10_10_2_Vector Normal;
    UInt_10_10_10_2_Vector Tangent;
    UInt_10_10_10_2_Vector TexCoords;
    UInt_10_10_10_2_Vector Bitangent;
    UInt_10_10_10_2_Vector Weights;
    UInt_10_10_10_2_Vector Misc;
};

//Array sizes are left for testing but should be provided by
//the compressed chunk header as specified in the comments
//for each field
struct VertexStream {
    Vertex Vertices[56588 / 28]; //This value should be (DecompressedVertexStreamSize / 28)
    u16 Indices[4474]; //The size of this array should be DecompressedIndexStreamSize
};

VertexStream file @ 0x00;