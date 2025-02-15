using Visiotech.VineyardManagementService.Domain.Abstractions;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Domain.Entities
{
    public sealed class Manager : Entity
    {
        private Manager()
        { 
        }

        public TaxNumber TaxNumber { get; private set; }
        public string Name { get; private set; }
        public Parcel Parcel { get; private set; }
    }
}
