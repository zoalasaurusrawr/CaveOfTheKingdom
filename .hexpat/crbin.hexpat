enum CompressionType : u32 {
    Unknown  = 0,
    Uncompressed  = 2,
    Zstd = 3,
    MeshCodec = 5
};

//3x4 Matrix Layout
//[Right.X    Right.Y    Right.Z    WorldPosition.X]
//[Up.X       Up.Y       Up.Z       WorldPosition.Y]
//[Forward.X  Forward.Y  Forward.Z  WorldPosition.Z]
struct Matrix3x4 {
    float M00;
    float M01;
    float M02;
    float M03;
    float M10;
    float M11;
    float M32;
    float M43;
    float M20;
    float M21;
    float M22;
    float M23;
};

struct Vector3 {
    float X;
    float Y;
    float Z;
};

struct Vector3u16 {
    u16 X;
    u16 Y;
    u16 Z;
};

struct Vector4 {
    float X;
    float Y;
    float Z;
    float W;
};

struct Box3 {
    Vector3 Min;
    Vector3 Max;
};

struct Box4 {
    Vector4 Min;
    Vector4 Max;
};

struct Section1 {
    u32 Field1;
    u32 Field2;
};

struct Section2 {
    u32 Field1;
    u32 Field2;
};

struct Section3 {
    u16 Field1;
    u16 Field2;
};

struct Section4 {
    float Reserve0;
    float Reserve1;
    float Reserve2;
    float Reserve3;
    float Reserve4;
    float Reserve5;
};

struct Section5 {
    u64 Reserve1;
    u64 Reserve2;
};

struct Section6 {
    u16 Field1;
    u16 Field2;
};

struct Section7 {
    u32 Reserve1;
    u32 Reserve2;
    u16 Reserve3;
    u16 Reserve4;
};

struct Section7Quad {
    float Reserve1[6];
};

struct Section8 {
    float Reserve[8];
};

struct Reserve14 {
    u8 Reserve1[4];
};

struct Offset<T> {
    u32 Offset;
    u32 Count;
    T Data[Count] @ Offset;
};

struct ChunkFileInfo {
    u32 FileSize;
    u32 FileIndex;
};

struct Sections {
    Offset<Section1> Section1;  
    Offset<Section2> Section2;  
    Offset<Section3> Section3;  
    Offset<Box3> Section4;  
    Offset<Section5> Section5; 
    Offset<Section6> Section6; 
    Offset<Section7> Section7;  
    Offset<Section8> Section8; 
    Offset<ChunkFileInfo> ChunkFileInfo; 
};

struct SectionsQuad {
    Offset<Vector3u16> Section1;
    Offset<Section2> Section2;
    Offset<Section3> Section3;
    Offset<u8> Section4;
    Offset<Reserve14> Section5;
    Offset<Section6> Section6;
    Offset<Section7Quad> Section7;
    Offset<Box4> Section8;
    Offset<ChunkFileInfo> CrbinOffset;
};

struct Header {
    char Magic[8] [[color("F5756C")]];
    u32 CrbinFilesize;
    CompressionType CompressionType;
    u32 CrbinId;
    Matrix3x4 Transform;
    Offset<Reserve14> UnknownSection1;
    Offset<Reserve14> UnknownSection2;
    Offset<Reserve14> UnknownSection3;
    Offset<Reserve14> UnknownSection4;
    u32 Scale;
    Sections ChunkInfo;
    u32 MapStatic;
    u32 Reserve17;
    Vector3 Origin;
    float Reserve21;
    u32 VertexStride;
    Box3 LocalBounds;
    u32 Reserved1[4];
    SectionsQuad QuadInfo;
    Box3 WorldBounds;
    Box3 FrustumBounds;
    u32 Reserved2[28];
};

Header file @ 0x00;