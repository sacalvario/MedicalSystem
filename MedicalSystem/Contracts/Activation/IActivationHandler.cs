using System.Threading.Tasks;

namespace MedicalSystem.Contracts.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle();

        Task HandleAsync();
    }
}
