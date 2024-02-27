using TerraHistoricus.Api.Models.Episode;
using TerraHistoricus.Api.Models.Pages;
using TerraHistoricus.Api.Services;

namespace TerraHistoricus.Api.Test;

public class EpisodeAndPageServiceTest
{
    [Fact]
    public async void GetEpisodeDetail()
    {
        EpisodeDetail defaultEpisodeDetail = default;

        // 6253 - 123罗德岛！？
        // 6337 - 「U-official」篇
        EpisodeDetail result = await EpisodeAndPageService.GetEpisodeDetailAsync("6253", "6337");

        Assert.NotEqual(defaultEpisodeDetail, result);
    }

    [Fact]
    public async void GetPageDetail()
    {
        PageDetail defaultPageDetail = default;

        // 6253 - 123罗德岛！？
        // 7401 - 「深靛」篇

        PageDetail result = await EpisodeAndPageService.GetPageDetailAsync("6253", "7401", 1);

        Assert.NotEqual(defaultPageDetail, result);
    }
}
