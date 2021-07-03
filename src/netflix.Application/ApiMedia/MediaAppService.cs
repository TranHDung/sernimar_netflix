using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netflix.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using netflix.ApiMedia.Dto;
using System.Net.Http;
using HtmlAgilityPack;

namespace netflix.ApiGenre
{
    public class MediaAppService : ApplicationService, IMediaAppService
    {
        private readonly IRepository<Media> _mediaRepository;
        private readonly IRepository<Entities.Action> _actionRepo;
        public MediaAppService(IRepository<Media> mediaRepository, IRepository<Entities.Action> actionRepo)
        {
            _mediaRepository = mediaRepository;
            _actionRepo = actionRepo;
        }
        public async Task<int> Add(Media entity)
        {
            entity.CreatedDate = DateTime.Now;
            int result = 0;
            try
            {
                result = await _mediaRepository.InsertAndGetIdAsync(entity);
            }
            catch(Exception ex)
            {
                var x = ex;
            }
            return result;
        }

        public async Task Delete(int mediaId)
        {
            var media = _mediaRepository.FirstOrDefault(m => m.Id == mediaId);
            await _mediaRepository.DeleteAsync(media);
        }

        public async Task<List<Media>> GetAll()
        {
            var entities = await _mediaRepository.GetAllListAsync();
            return entities;
        }

        public async Task<List<Media>> Search(MediaSearchDto search)
        {
            var query = _mediaRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(q => q.Name.Contains(search.Name));
            }
            if (search.GenreId > 0)
            {
                query = query.Where(q => q.GenreId == search.GenreId);
            }
            if (search.FromCreatedDate != null)
            {
                query = query.Where(q => q.CreatedDate >= search.FromCreatedDate);
            }
            if (search.ToCreatedDate != null)
            {
                query = query.Where(q => q.CreatedDate <= search.ToCreatedDate);
            }

            return query.ToList();
        }

        public async Task<bool> UploadMedia(IFormFile file, int mediaId)
        {
            if (file != null && file.Length > 0)
            {
                try
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\video", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    var media = _mediaRepository.FirstOrDefault(m => m.Id == mediaId);
                    if (media == null)
                    {
                        return false;
                    }
                    media.FilePath = filePath;
                    _mediaRepository.Update(media);
                    return true;
                }
                catch(Exception ex)
                {
                    var z = 1;
                }
            }
            return false;
        }

        public async Task<IMDBInfo> GetInfoFromIMDB(string IMDBLink)
        {
            var httpClient = new HttpClient();

            var html = await httpClient.GetStringAsync(IMDBLink);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var rating = doc.QuerySelector(".AggregateRatingButton__RatingScore-sc-1ll29m0-1")?.InnerText;
            var description = doc.QuerySelector(".GenresAndPlot__TextContainerBreakpointL-cum89p-4")?.InnerText;
            var name = doc.QuerySelector(".TitleHeader__TitleText-sc-1wu6n3d-0")?.InnerText;
            return new IMDBInfo 
            {
                Rating = double.Parse(rating),
                Description = description,
                Name = name
            };
        }

        public async Task Update(Media media)
        {
            var entity = await _mediaRepository.FirstOrDefaultAsync(f => f.Id == media.Id);
            entity.GenreId = media.GenreId;
            entity.IBDMLink = media.IBDMLink;
            entity.ImdbRating = media.ImdbRating;
            entity.Name = media.Name;
            entity.RawName = media.RawName;
            entity.FilePath = media.FilePath;
            entity.Type = media.Type;
            entity.Description = media.Description;
            await _mediaRepository.UpdateAsync(entity);
        }

        public async Task<SuggestVideoModel> GetSuggestMediaByProfileId(int profileId)
        {
            var res = new SuggestVideoModel();
            var allVid = await _mediaRepository.GetAllListAsync();

            // cac the loai
            res.NewVideos = allVid.OrderByDescending(v => v.CreatedDate).Take(6).ToList();
            res.ActionAndFictionVideos = allVid.Where(v => v.GenreId == 3 || v.GenreId == 4).ToList();
            res.HistoryAndHororVideos = allVid.Where(v => v.GenreId == 1 || v.GenreId == 8).ToList();
            res.LoveAndComedyVideos = allVid.Where(v => v.GenreId == 2 || v.GenreId == 7).ToList();
            res.OtherVideos = allVid.Where(v => v.GenreId != 2 || v.GenreId != 7 || v.GenreId != 3 || v.GenreId != 4 || v.GenreId != 1 || v.GenreId != 8).Take(10).ToList();

            //var r= await _actionRepo.GetAllListAsync();
            
            //var lastViewMedia = r.Where(i => i.ProfileId == profileId).OrderBy(r => r.CreatedDate).FirstOrDefault();
            
            //if (lastViewMedia is null) // nguoi dung chua xem video nao
            //{
            //    res.ThemeVideo = res.NewVideos[0];
            //    res.ForYouVideos = res.NewVideos;
            //}
            //else //
            //{
            //    var videos = allVid.Where(v => v.GenreId == lastViewMedia.Media.GenreId).Take(6).ToList();
            //    res.ForYouVideos = videos;
            //    res.ThemeVideo = videos.FirstOrDefault();
            //}

            return res;
        }
    }
}
