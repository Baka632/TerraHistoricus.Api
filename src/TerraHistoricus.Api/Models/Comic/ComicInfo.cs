namespace TerraHistoricus.Api.Models.Comic;

/// <summary>
/// 提供漫画基本信息的结构
/// </summary>
/// <param name="Cid">漫画的 CID</param>
/// <param name="Title">漫画的标题</param>
/// <param name="Subtitle">漫画的副标题</param>
/// <param name="CoverUri">漫画封面的 Uri</param>
/// <param name="Type">漫画类型</param>
/// <param name="Authors">漫画作者列表</param>
public record struct ComicInfo(
    string Cid,
    string Title,
    string Subtitle,
    [property: JsonPropertyName("cover")] string CoverUri,
    int Type,
    IEnumerable<string> Authors);
