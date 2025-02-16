using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Domain.Entities
{
    public sealed class Manager : Entity
    {
        public Manager()
        { 
        }

        public TaxNumber TaxNumber { get; set; }
        public string Name { get; set; }
        public ICollection<Parcel> Parcels { get; set; } = [];
    }
}
