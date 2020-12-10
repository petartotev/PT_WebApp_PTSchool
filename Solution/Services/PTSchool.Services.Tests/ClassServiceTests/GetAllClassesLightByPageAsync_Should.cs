using NUnit.Framework;
using PTSchool.Data;
using PTSchool.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PTSchool.Services.Tests.ClassServiceTests
{
    public class GetAllClassesLightByPageAsync_Should
    {
        [Test]
        public async Task ReturnCorrectCollectionClassesLightServiceModelsByPage_When_ClassesExistInDb()
        {
            // Arrange
            var options = Utils.GetOptions(nameof(ReturnCorrectCollectionClassesLightServiceModelsByPage_When_ClassesExistInDb));

            Teacher teacher1 = Utils.CreateMockTeacher();
            Class class1 = Utils.CreateMockClass(teacher1.Id);

            using (var arrangeContext = new PTSchoolDbContext(options))
            {
                arrangeContext.Teachers.Add(teacher1);
                arrangeContext.Classes.Add(class1);
                await arrangeContext.SaveChangesAsync();
            }

            // Act
            using (var actContext = new PTSchoolDbContext(options))
            {
                ClassService sut = new ClassService(actContext, Utils.Mapper);
                var result = await sut.GetAllClassesLightByPageAsync();

                // Assert
                Assert.AreEqual(1, result.Count());
            }
        }
    }
}
