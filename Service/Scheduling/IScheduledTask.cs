using System.Threading;
using System.Threading.Tasks;

namespace FixerMovie.Service
{
    public interface IScheduledTask
    {
        string Schedule { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}