namespace TerraHistoricus.Api.Models.Pages;

/// <summary>
/// 提供页面详细信息的结构
/// </summary>
/// <param name="PageNumber">当前页面的页数</param>
/// <param name="PageUri">页面图像的 Uri</param>
public record struct PageDetail(
    [property: JsonPropertyName("pageNum")] int PageNumber,
    [property: JsonPropertyName("url")] string PageUri);
