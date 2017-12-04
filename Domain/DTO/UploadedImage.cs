using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UploadedImage
    {
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
