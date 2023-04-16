using System.Threading.Tasks;

namespace MedicalSystem.Contracts.Services
{
    public interface IApplicationHostService
    {
        Task StartAsync();

        Task StopAsync();
    }
}
