using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Domain.Entities
{
    public class Parcel : Entity
    {
        private Parcel()
        {

        }

        public int ManagerId { get; private set; }
        public Manager Manager { get;  private set; }
        public int VineyardId { get; private set; }
        public Vineyard Vineyard { get; private set; }
        public int GrapeId { get; private set; }
        public Grape Grape { get; private set; }
        public YearPlanted YearPlanted { get; private set; }
        public Area Area { get; private set; }
    }
}
