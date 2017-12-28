using NetCoreTests.EntityFrameworkCore.Data;
using NetCoreTests.EntityFrameworkCore.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NetCoreTests.EntityFrameworkCore.Tests
{
    public class BackingFieldsTest : IClassFixture<TestContextFixture>
    {
        private TestContextFixture _fixture;

        private TestContext _context;

        public BackingFieldsTest(TestContextFixture fixture)
        {
            _fixture = fixture;
            _context = fixture.Context;
        }
    }
}
