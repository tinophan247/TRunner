using MediatR;
using TRunner.Application.Interfaces.Repositories;
using TRunner.Domain.Entities;

namespace TRunner.Application.Commands.UserCommands
{
    public class UpdateUser
    {
        public record Command(
        User data
        ) : IRequest<int>;

        internal class Handler : IRequestHandler<Command, int>
        {
            private IUserRepository _userRepository;

            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                //handle request command to update user information
                var result = await _userRepository.UpdateUser(command.data);
                return result;
            }
        }
    }
}
