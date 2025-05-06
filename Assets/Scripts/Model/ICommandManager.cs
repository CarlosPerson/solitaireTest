using SolitaireTest.Assets.Scripts.Model;

public interface ICommandManager
{
    void ExecuteCommand(ICommand command);
    void UndoLastCommand();
}