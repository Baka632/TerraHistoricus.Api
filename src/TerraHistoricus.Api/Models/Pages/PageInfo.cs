namespace TerraHistoricus.Api.Models.Pages;

/// <summary>
/// 提供页面基本信息的结构
/// </summary>
/// <param name="Height">页面高度</param>
/// <param name="Width">页面宽度</param>
/// <param name="IsDoublePage">指示此页面是否为双面的值</param>
public record struct PageInfo(
    int Height,
    int Width,
    [property: JsonPropertyName("doublePage")] bool IsDoublePage);
