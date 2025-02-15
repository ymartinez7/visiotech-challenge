using Visiotech.VineyardManagementService.Domain.Abstractions;

namespace Visiotech.VineyardManagementService.Domain.Entities
{
    public sealed class Vineyard : Entity
    {
        private Vineyard() 
        { }

        public string Name { get; private set; }
        public Parcel Parcel { get; private set; }
    }
}
