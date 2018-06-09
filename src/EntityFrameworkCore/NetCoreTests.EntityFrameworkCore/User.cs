using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreTests.EntityFrameworkCore
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Image ProfileImage { get; set; }

        public User()
        {
            ProfileImage = new Image();
        }
    }
}
