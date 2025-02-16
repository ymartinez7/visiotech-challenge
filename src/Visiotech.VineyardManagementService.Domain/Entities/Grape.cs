using Visiotech.VineyardManagementService.Domain.Abstractions;

namespace Visiotech.VineyardManagementService.Domain.Entities
{
    public sealed class Grape : Entity
    {
        public Grape()
        {
        }

        public string Name { get; set; }

        public ICollection<Parcel> Parcels { get; set; } = [];
    }
}
