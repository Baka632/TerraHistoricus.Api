using TerraHistoricus.Api.Models.Episode;

namespace TerraHistoricus.Api.Models.Comic;

/// <summary>
/// 提供漫画详细信息的结构
/// </summary>
/// <param name="Cid">漫画的 CID</param>
/// <param name="Title">漫画的标题</param>
/// <param name="Subtitle">漫画的副标题</param>
/// <param name="CoverUri">漫画封面的 Uri</param>
/// <param name="Type">漫画类型</param>
/// <param name="Authors">漫画作者列表</param>
/// <param name="Introduction">漫画引言</param>
/// <param name="UpdateTimestamp">漫画更新时间的时间戳</param>
/// <param name="Direction">漫画的方向</param>
/// <param name="ReadConfig">漫画的阅读配置</param>
/// <param name="Keywords">漫画的关键词</param>
/// <param name="Episodes">漫画各篇章信息的列表</param>
public record struct ComicDetail(
    string Cid,
    string Title,
    string Subtitle,
    string Introduction,
    [property: JsonPropertyName("cover")] string CoverUri,
    [property: JsonPropertyName("updateTime")] long UpdateTimestamp,
    string Direction,
    int Type,
    IReadOnlyDictionary<string, string>? ReadConfig,
    IEnumerable<string> Authors,
    IEnumerable<string> Keywords,
    IEnumerable<EpisodeInfo> Episodes);
