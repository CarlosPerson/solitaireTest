using SolitaireTest.Assets.Scripts.Model;

namespace SolitaireTest.Assets.Scripts.Model
{
    public interface ICard
    {
        string Rank { get; }
        string Suit { get; }
        IPile CurrentPile { get; set; }
        string Name { get; }
    }
}