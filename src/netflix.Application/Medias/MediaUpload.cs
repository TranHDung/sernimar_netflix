using Microsoft.AspNetCore.Http;
using netflix.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Medias
{
    public class MediaUpload: Media
    {
        public IFormFile File; // full path of file
    }
}
