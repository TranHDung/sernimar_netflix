using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.ApiMedia.Dto
{
    public class SuggestVideoModel
    {
        public Media ThemeVideo { get; set; }
        public List<Media> ForYouVideos { get; set; }
        public List<Media> NewVideos { get; set; }
        public List<Media> ActionAndFictionVideos { get; set; }
        public List<Media> LoveAndComedyVideos { get; set; }
        public List<Media> HistoryAndHororVideos { get; set; }
        public List<Media> OtherVideos { get; set; }
    }
}
