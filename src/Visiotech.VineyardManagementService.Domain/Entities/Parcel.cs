using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Domain.Entities
{
    public class Parcel : Entity
    {
        public Parcel()
        {

        }

        public int ManagerId { get; set; }
        public Manager Manager { get;  set; }
        public int VineyardId { get; set; }
        public Vineyard Vineyard { get; set; }
        public int GrapeId { get; set; }
        public Grape Grape { get; set; }
        public YearPlanted YearPlanted { get; set; }
        public Area Area { get; set; }
    }
}
