using Visiotech.VineyardManagementService.Domain.Abstractions;

namespace Visiotech.VineyardManagementService.Domain.Entities
{
    public sealed class Vineyard : Entity
    {
        public Vineyard() 
        { }

        public string Name { get; set; }
        public ICollection<Parcel> Parcels { get; set; } = [];
    }
}
