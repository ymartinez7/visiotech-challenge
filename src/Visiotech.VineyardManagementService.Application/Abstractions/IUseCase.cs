namespace Visiotech.VineyardManagementService.Application.Abstractions
{
    public interface IUseCase<in TUseCaseInput> where TUseCaseInput : IUseCaseInput
    {
        Task Execute(TUseCaseInput input);
    }
}