using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SS.Template.Application.Commands
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        protected abstract Task Handle(TCommand command, CancellationToken cancellationToken);

        async Task IRequestHandler<TCommand>.Handle(TCommand request, CancellationToken cancellationToken)
        {
            await Handle(request, cancellationToken);
            return;
        }
    }
}
