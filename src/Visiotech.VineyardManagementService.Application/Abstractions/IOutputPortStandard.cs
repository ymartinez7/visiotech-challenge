namespace Visiotech.VineyardManagementService.Application.Abstractions
{
    public interface IOutputPortStandard<in TUseCaseOutput>
        where TUseCaseOutput : IUseCaseOutput
    {
        void StandardHandle(TUseCaseOutput response);
    }
}
