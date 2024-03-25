using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Example.Model.Skeletons
{
    public abstract class JobPlaneSkeleton
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }

        public JobPlaneSkeleton() { }

        public JobPlaneSkeleton(JobPlaneSkeleton skeleton) 
        {
            Id = skeleton.Id;
            Name = skeleton.Name;
            Description = skeleton.Description;
            StartDateUtc = skeleton.StartDateUtc;
            EndDateUtc = skeleton.EndDateUtc;
        }

    }
}
