using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Medias
{
    public class MediaStat
    {
        public int ToDayView { get; set; }
        public int YesterdayView { get; set; }
        public List<MediaAndView> MediaViews { get; set; }
    }
    public class MediaAndView
    {
        public Media Media { get; set; }
        public int ViewCount { get; set; }
    }
}
