using Microsoft.EntityFrameworkCore;
using Moq;
using WAMA.Core.Models;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Provider;
using WAMA.Core.Services;
using Xunit;

namespace WAMAcut.Services
{
    public class CheckInServiceTests
    {
        private static IDbContextProvider GetDbContextProvider()
        {
            var mockLoginCredentialSet = new Mock<DbSet<LogInCredential>>();

            var mockDbCtx = new Mock<WamaDbContext>();
            mockDbCtx.Setup(d => d.LogInCredentials).Returns(mockLoginCredentialSet.Object);

            var mockDbCtxProvider = new Mock<IDbContextProvider>();
            mockDbCtxProvider.Setup(dbCtxProvider => dbCtxProvider.GetWamaDbContext()).Returns(mockDbCtx.Object);

            mockLoginCredentialSet.Verify(m => m.Add(It.IsAny<LogInCredential>()), Times.Once());
            mockDbCtx.Verify(ctx => ctx.SaveChanges(), Times.Once());

            return mockDbCtxProvider.Object;
        }

        [Fact]
        public void GetLoginCredentialTest()
        {
            var mockLoginCredentialSet = new Mock<DbSet<LogInCredential>>();

            var mockDbCtx = new Mock<WamaDbContext>();
            mockDbCtx.Setup(d => d.LogInCredentials).Returns(mockLoginCredentialSet.Object);

            var mockDbCtxProvider = new Mock<IDbContextProvider>();
            mockDbCtxProvider.Setup(dbCtxProvider => dbCtxProvider.GetWamaDbContext()).Returns(mockDbCtx.Object);

            var service = new CheckInService(mockDbCtxProvider.Object);
            service.GetLogInCredential("");

            mockLoginCredentialSet.Verify(m => m.Add(It.IsAny<LogInCredential>()), Times.Once());
            mockDbCtx.Verify(ctx => ctx.SaveChanges(), Times.Once());
        }
    }
}