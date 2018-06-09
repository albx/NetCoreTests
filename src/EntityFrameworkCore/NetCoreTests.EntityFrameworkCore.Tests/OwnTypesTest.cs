using NetCoreTests.EntityFrameworkCore.Data;
using NetCoreTests.EntityFrameworkCore.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace NetCoreTests.EntityFrameworkCore.Tests
{
    public class OwnTypesTest : IClassFixture<TestContextFixture>
    {
        private TestContextFixture _fixture;

        private TestContext _context;

        public OwnTypesTest(TestContextFixture fixture)
        {
            _fixture = fixture;
            _context = fixture.Context;
        }

        [Fact]
        public void Add_User_Should_Increment_Users_Number()
        {
            var usersCount = _context.Users.Count();

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = "User 2"
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            var newUsersCount = _context.Users.Count();

            Assert.Equal(usersCount + 1, newUsersCount);
        }
    }
}
