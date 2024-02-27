using TerraHistoricus.Api.Models.Comic;
using TerraHistoricus.Api.Services;

namespace TerraHistoricus.Api.Test;

public class ComicServiceTest
{
    [Fact]
    public async void GetAllComics()
    {
        ComicInfo defaultComicInfo = default;

        IEnumerable<ComicInfo> comicInfos = await ComicService.GetAllComicAsync();

        Assert.NotEmpty(comicInfos);
        foreach (ComicInfo item in comicInfos)
        {
            Assert.NotEqual(defaultComicInfo, item);
        }
    }
}