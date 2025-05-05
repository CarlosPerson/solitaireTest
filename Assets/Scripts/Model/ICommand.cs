namespace SolitaireTest.Assets.Scripts.Model
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
