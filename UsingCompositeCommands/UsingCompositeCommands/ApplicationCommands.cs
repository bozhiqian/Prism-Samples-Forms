using Prism.Commands;

namespace UsingCompositeCommands
{
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand SaveCommand { get; } = new CompositeCommand();

        public CompositeCommand ResetCommand { get; } = new CompositeCommand();
    }
}