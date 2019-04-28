using CalcTest.Service.ViewModels;
using System.Threading.Tasks;

namespace CalcTest.Service.Interfaces
{
    public interface IJurosCompostosService
    {
        Task<JurosCompostosResultViewModel> Calcular(JurosCompostosViewModel vm);
    }
}
