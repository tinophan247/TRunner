using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRunner.Domain.Models.Request
{
    public class CreateWorkoutSummaryRequest : BaseModel
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public int Time { get; set; }

        public double Distance { get; set; }

        public double AvgSpeed { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int UserRoleId { get; set; } = 2;

        public int SportId { get; set; }

        public int ViewPermissionTypeId { get; set; } = 1;

        public IList<ImageInfo> Images { get; set; }

        public IList<DetailRecordNotDevice> DetailRecordsNotDevice { get; set; }
    }

    public class DetailRecordNotDevice
    {
        public string CreatedDate { get; set; }
        public double Distance { get; set; }
        public double Speed { get; set; }

    }
}
