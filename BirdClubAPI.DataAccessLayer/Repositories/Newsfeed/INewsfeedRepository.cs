﻿using BirdClubAPI.Domain.DTOs.Response.Blog;
using BirdClubAPI.Domain.DTOs.Response.Newsfeed;
using BirdClubAPI.Domain.Entities;

namespace BirdClubAPI.DataAccessLayer.Repositories.Newsfeed
{
    public interface INewsfeedRepository
    {
        List<NewsfeedResponseModel> GetNewsfeeds(int limit, int page, int size);
        Domain.Entities.Newsfeed? Create(Domain.Entities.Newsfeed newsfeed);
        BlogDetailResponseModel? GetBlogs(int id);
    }
}
