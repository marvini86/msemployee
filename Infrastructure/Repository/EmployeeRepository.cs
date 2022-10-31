

using MsEmployee.Domain.Entity;
using MsEmployee.Infrastrucuture.Base;
using MsEmployee.Infrastrucuture.Base.MongoDb;

namespace MsEmployee.Infrastrucuture.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IMongoContext context) : base(context)
        {
        }
    }
}
