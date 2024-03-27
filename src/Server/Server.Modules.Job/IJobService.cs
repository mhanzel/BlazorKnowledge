using Core.Modules.Job;

namespace Server.Modules.Job
{
    public interface IJobService
    {
        public GetCustomersResult GetCustomers(GetCustomersQuery query)
        {
            return new GetCustomersResult();
        }
    }
}