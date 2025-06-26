using System.Text;

namespace Builder.Query;

internal class PatronBuilder : IPatronBuilder
{
    internal string? Select { get; set; }
    internal string? Where { get; set; }
    internal string? From { get; set; }
    internal string? Orderby { get; set; }

    public string Build()
    {
        StringBuilder? query = new();

        query.AppendLine($"SELECT {(!string.IsNullOrEmpty(Select) ? Select : "*")}");
        query.AppendLine($"FROM {From}");

        if (!string.IsNullOrEmpty(Where))
        {
            query.AppendLine($"WHERE {Where}");
        }
        if (!string.IsNullOrEmpty(Orderby))
        {
            query.AppendLine($"ORDER BY {Orderby}");
        }

        return query.ToString();
    }
}
