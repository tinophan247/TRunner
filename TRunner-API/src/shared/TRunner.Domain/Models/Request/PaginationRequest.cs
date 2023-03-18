using Newtonsoft.Json;

namespace TRunner.Domain.Models.Request;

public class PaginationRequest
{
    /// <summary>
    /// Current page
    /// </summary>
    [JsonProperty("pageIndex")]
    public int PageIndex { get; set; } = 1;

    /// <summary>
    /// Total pages
    /// </summary>
    [JsonProperty("pageSize")]
    public int PageSize { get; set; } = 50;

    /// <summary>
    /// The columns which user is sorting on
    /// </summary>
    [JsonProperty("sort")]
    public string[]? Sort { get; set; }

    /// <summary>
    /// The columns which user is filter
    /// </summary>
    [JsonProperty("filter")]
    public string[]? Filter { get; set; }

    /// <summary>
    /// if filter available support condiontion AND and OR
    /// </summary>
    [JsonProperty("filterCondition")]
    public bool FilterCondition { get; set; } = true;

    /// <summary>
    /// The keyword is used for search
    /// </summary>
    [JsonProperty("keyword")]
    public string? Keyword { get; set; }
}
