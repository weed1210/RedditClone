using Reddit.Domain.Enums.Paging;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Reddit.DataAccess.Common.Paging;
public class PagingParam<TKey> where TKey : Enum
{
    public int PageIndex { get; set; } = PagingConstants.DefaultPage;

    /// <summary>
    /// Gets or sets size of current page.
    /// </summary>
    [DefaultValue(PagingConstants.DefaultPageSize)]
    public int PageSize { get; set; } = PagingConstants.DefaultPageSize;

    [Description("Parameter use for sorting result. Value: {propertyName}")]
    public TKey? SortKey { get; set; }

    /// <summary>
    /// Gets or sets ordering criteria.
    /// </summary>
    [EnumDataType(typeof(OrderCriteria))]
    [JsonConverter(typeof(OrderCriteria))]
    public OrderCriteria SortOrder { get; set; }
}