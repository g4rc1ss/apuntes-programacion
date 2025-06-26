namespace Builder.Query.Extensions;

internal static class ExtensionsMethod
{
    internal static IPatronBuilder Select(this IPatronBuilder patron, string select)
    {
        PatronBuilder? patronBuilder = patron as PatronBuilder;
        patronBuilder.Select = select;
        return patronBuilder;
    }

    internal static IPatronBuilder Where(this IPatronBuilder patron, string where)
    {
        PatronBuilder? patronBuilder = patron as PatronBuilder;
        patronBuilder.Where = where;
        return patronBuilder;
    }

    internal static IPatronBuilder From(this IPatronBuilder patron, string from)
    {
        PatronBuilder? patronBuilder = patron as PatronBuilder;
        patronBuilder.From = from;
        return patronBuilder;
    }

    internal static IPatronBuilder OrderBy(this IPatronBuilder patron, string orderBy)
    {
        PatronBuilder? patronBuilder = patron as PatronBuilder;
        patronBuilder.Orderby = orderBy;
        return patronBuilder;
    }
}
