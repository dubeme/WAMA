using Microsoft.EntityFrameworkCore;
using WAMA.Core.Models;
using Xunit;

namespace WAMAcut.Services
{
    public class CheckInServiceTests
    {
        [Fact]
        public void GetLoginCredentialTest()
        {
            var builder = new DbContextOptionsBuilder<WamaDbContext>();
            builder.UseInMemoryDatabase();

            var dbCTX = new WamaDbContext(builder.Options);
        }
    }
}