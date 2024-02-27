using TerraHistoricus.Api.Models.Pages;

namespace TerraHistoricus.Api.Models.Episode;

/// <summary>
/// 提供篇章详细信息的结构
/// </summary>
/// <param name="Title">篇章标题</param>
/// <param name="ShortTitle">篇章短标题</param>
/// <param name="Type">篇章类型</param>
/// <param name="Likes">篇章的点赞数</param>
/// <param name="PageInfos">篇章各页面信息的列表</param>
public record struct EpisodeDetail(
    string Title,
    string ShortTitle,
    int Likes,
    int Type,
    IReadOnlyList<PageInfo> PageInfos);