
using Moq;
using MsEmployee.Infrastrucuture.Base.MongoDb;
using MsEmployee.Infrastrucuture.Repository;


namespace MsEmployee.Test
{
    public class EmployeeRepositoryUnitTest
    {
        private readonly Mock<IMongoContext> context;


        public EmployeeRepositoryUnitTest()
        {
            context = new Mock<IMongoContext>();
        }


        [Fact]
        public async Task Test_Handler()
        {
            var repository = new EmployeeRepository(context.Object);

            Assert.NotNull(repository);
        }

    

    }
}
