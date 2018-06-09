using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreTests.EntityFrameworkCore
{
    public class Image
    {
        public string MimeType { get; set; }

        public byte[] Data { get; set; }
    }
}
