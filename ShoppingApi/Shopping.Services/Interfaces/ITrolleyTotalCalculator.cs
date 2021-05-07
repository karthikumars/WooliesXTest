using Shopping.Models;
using System.Threading.Tasks;

namespace Shopping.Services.Interfaces
{
    public interface ITrolleyTotalCalculator
    {
        Task<decimal> Calculate(CalculateTrolleyTotalRequest request);
    }
}