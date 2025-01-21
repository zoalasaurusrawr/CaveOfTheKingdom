# Caves of the Kingdom

Caves of the Kingdom is a reverse engineering research effort focused on understanding the cave mesh format in Tears of the Kingdom.

## .crbin (cave-related binary)

Crbin files represent compression information about chunks and structured **SVO (Sparse-Voxel-Octree)** data. The overall structure of .crbin files is known, but the purpose for each field and/or sections are not fully known. The sections in the hexpat and in the library refer to the sections simply as 'Section<N>', but there are signs of what some of the sections represent:

- **Section1**: Per-Node Page File Size (Prossibly for LOD data)
- **Section2**: SVO Node Relationship Information
- **Section3**: SVO Node Subdivision Information
- **Section4**: SVO Node Bounds
- **Section5**: Per-Node Bitmasks, possibly Morton Z-Order curve information or material properties for rendering

## .chunk

Decompressed chunk information appears to contains **at least** a vertex buffer followed by an index buffer. The vertex buffer doesn't seem to represent triangle data, but instead of a collection of SDF values in the position attribute with other attributes providing normal information and blend weight info for vertex morphing between LODs during rendering.

## .quad

This project does not currently contain information for quad chunks yet because the internal format for decompressed quad chunks appears to be totally different than .chunk files. If/when they get reverse engineered, they'll be included. If you have research you'd like to contribute, please feel free to open a pull request.

## Library Usage

The main library CavesOfTheKingdom provides reading capabilities for .crbin files along with compressed and decompresssed chunks. It does **NOT** provide a mechanism for decompressing vertex and index streams and a compressed and decompressed chunk file is provided in the Unit.Tests project for a dummy cave, which was extracted from Tears of the Kingdom.

Unit.Tests provides an example of how to read each file type.

# Contributions

If you'd like to contribute to this effort, please feel free to open an issue or pull request. **This library represents an ongoing effort and likely has mistakes**.

# Credits & Thanks

- **watertoon**: For the decompression hexpat
- **dt13269**: Most of my research is built on research by them along with hexpat information for multiple files.
- **The Zelda Data Collection & Research community.**

# Libraries & Frameworks

- net8.0
- xUnit
- Shouldly

# Roadmap

- I have a test renderer written to work with OpenGL. Once I can update it, it will provide a way to visualize node information contained in .crbin files.
- Once the rendering process is fully understood, I plan to provide a tool to convert SDF vertex data for chunks into a standard model format.
