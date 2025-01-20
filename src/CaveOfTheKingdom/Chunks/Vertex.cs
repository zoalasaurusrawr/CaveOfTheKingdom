using CaveOfTheKingdom.CaveRelatedBinaryFiles;

namespace CaveOfTheKingdom.Chunks;

public struct Vertex : IEquatable<Vertex>
{
    public Vector3Struct Position { get; set; }
    public Vector3Struct Normal { get; set; }
    public Vector3Struct Tangent { get; set; }
    public Vector3Struct TexCoords { get; set; }
    public Vector3Struct Bitangent { get; set; }
    public Vector3Struct Weights { get; set; }
    public Vector3Struct Misc { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Vertex vertex && Equals(vertex);
    }

    public bool Equals(Vertex other)
    {
        return Position.Equals(other.Position) &&
               Normal.Equals(other.Normal) &&
               Tangent.Equals(other.Tangent) &&
               TexCoords.Equals(other.TexCoords) &&
               Bitangent.Equals(other.Bitangent) &&
               Weights.Equals(other.Weights) &&
               Misc.Equals(other.Misc);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Position, Normal, Tangent, TexCoords, Bitangent, Misc, Weights);
    }

    public static bool operator ==(Vertex left, Vertex right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Vertex left, Vertex right)
    {
        return !(left == right);
    }
}