﻿using TerraHistoricus.Api.Services;
using TerraHistoricus.Api.Models.Comic;
using TerraHistoricus.Api.Models.Episode;
using TerraHistoricus.Api.Models.Pages;

namespace TerraHistoricus.Api.Test;

public class OneStopTest
{
    // [Fact]
    public async void OneStop()
    {
        using StreamWriter writer = File.CreateText(@"E:\Temp\泰拉记事社.txt");

        PageInfo defaultPageInfo = default;
        PageDetail defaultPageDetail = default;
        IEnumerable<ComicInfo> allComics = await ComicService.GetAllComicAsync();

        foreach (ComicInfo comicInfo in allComics)
        {
            ComicDetail comicDetail = await ComicService.GetComicDetailAsync(comicInfo.Cid);
            writer.WriteLine(comicDetail);

            foreach (EpisodeInfo episodeInfo in comicDetail.Episodes)
            {
                EpisodeDetail episodeDetail = await EpisodeAndPageService.GetEpisodeDetailAsync(comicDetail.Cid, episodeInfo.Cid);
                writer.WriteLine($"    {episodeDetail}");

                for (int i = 0; i < episodeDetail.PageInfos.Count; i++)
                {
                    PageInfo pageInfo = episodeDetail.PageInfos[i];
                    Assert.NotEqual(defaultPageInfo, pageInfo);
                    writer.WriteLine($"        {pageInfo}");

                    int pageNumber = i + 1;
                    PageDetail pageDetail = await EpisodeAndPageService.GetPageDetailAsync(comicDetail.Cid, episodeInfo.Cid, pageNumber);
                    Assert.NotEqual(defaultPageDetail, pageDetail);

                    writer.WriteLine($"        {pageDetail}");
                }
            }
        }
    }
}