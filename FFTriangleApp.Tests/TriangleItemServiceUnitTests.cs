using Services;
using Xunit;
using Data;
using Moq;
using System.IO;
using System.Linq;
using Model;
using System.Collections.Generic;

namespace FFTriangleApp.Tests
{
    public class TriangleItemServiceUnitTests
    {
        private const string FilePath = "data.txt";

        [Fact(DisplayName = "CalculateCellData test")]
        public void CalculateCellDataIntegrationTest()
        {
            var triangleItemRepositoryMock = new Mock<ITriangleRepository>();
            triangleItemRepositoryMock.Setup(_ => _.GetAll()).Returns(File.Exists(FilePath) ? File.ReadAllLines(FilePath) : new string[0] );

            var triangleItemService = new TriangleService(triangleItemRepositoryMock.Object, new CellService());

            var cellData = triangleItemService.CalculateCellData();

            var firstNode = cellData.FirstOrDefault(i => i.X == 0 && i.Y == 0);

            Assert.Equal(16, firstNode?.Path?.Sum());
        }
    }
}
