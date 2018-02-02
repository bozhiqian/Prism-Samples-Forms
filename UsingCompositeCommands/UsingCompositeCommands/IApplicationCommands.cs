using Prism.Commands;

namespace UsingCompositeCommands
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveCommand { get; }
        CompositeCommand ResetCommand { get; }
    }
}