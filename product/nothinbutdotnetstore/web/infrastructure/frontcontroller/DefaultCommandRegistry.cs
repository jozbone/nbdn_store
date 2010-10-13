using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public RequestCommand get_the_command_that_can_process(Request request)
        {
            return all_commands.FirstOrDefault(x => x.can_handle(request)) ?? new MissingRequestCommand();
        }
    }
}