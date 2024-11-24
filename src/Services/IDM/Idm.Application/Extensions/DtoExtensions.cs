using Idm.Domain.Abstractions;
using Mapster;

namespace Idm.Application.Extensions
{
    public static class Converter
    {
        // Convert a single entity to DTO
        //public static TDestination AdaptTo<TDestination>(this object source)
        //{
        //    if (source == null) throw new ArgumentNullException(nameof(source));
        //    return source.Adapt<TDestination>();
        //}

        //// Convert a list of entities to DTOs
        //public static List<TDestination> AdaptToList<TSource, TDestination>(this IEnumerable<TSource> sourceList)
        //{
        //    if (sourceList == null) throw new ArgumentNullException(nameof(sourceList));
        //    return sourceList.Adapt<List<TDestination>>();
        //}
    }
}
