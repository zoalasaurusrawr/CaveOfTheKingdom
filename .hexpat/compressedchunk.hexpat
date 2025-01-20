// Credits to watertoon and dt13269 for various portions of this file

enum CompressionType : u8 {
    None  = 0,
    Zstd  = 1,
    MeshCodec = 2,
};
bitfield Flags {
    CompressionType CompressionType : 2;
    Reserved                       : 14;
};
struct CompressionInfoHeader {
    u32 DecompressedVertexStreamSize; //In the decompressed stream, this is size from 0x00
    u32 DecompressedIndexStreamSize; //In the decompressed stream, this is size from 0x00
    u32 DecompressedChunkFileSize; //This is equal to the size of the total decompressed streams w/o header
    u32 WorkingMemorySize;
    Flags Flags;
    u24 CompressedVertexStreamSize; 
    u24 CompressedIndexStreamSize;
};

struct ResChunk {
    u32 Hash; //Matches the folder structure "C.crbin.<Hash as Hex>"
    CompressionInfoHeader CompressionInfo;
    u8 VertexStream[mesh_header.CompressedVertexStreamSize];
    u8 IndexStream[mesh_header.CompressedIndexStreamSize];
};

ResChunk file @ 0x00;