using System.Threading.Tasks;

namespace GrainInterfaces
{
    public interface IHelloAsync : Orleans.IGrainWithStringKey
    {
        Task StartAsync();
    }
}