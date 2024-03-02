using TerraHistoricus.Api.Models.Info;
using TerraHistoricus.Api.Services;

namespace TerraHistoricus.Api.Test;

public class InfoServiceTest
{
    [Fact]
    public async void GetRecommendComicInfo()
    {
        RecommendComicInfo defaultRecommendComicInfo = default;
        RecommendComicInfo result = await InfoService.GetRecommendComicAsync();
        Assert.NotEqual(defaultRecommendComicInfo, result);
    }

    [Fact]
    public async void GetRecentUpdateList()
    {
        EpisodeUpdateInfo defaultEpisodeUpdateInfo = default;
        IEnumerable<EpisodeUpdateInfo> result = await InfoService.GetRecentUpdateEpisodeAsync();

        Assert.NotEmpty(result);

        foreach (EpisodeUpdateInfo item in result)
        {
            Assert.NotEqual(defaultEpisodeUpdateInfo, item);
        }
    }
}
