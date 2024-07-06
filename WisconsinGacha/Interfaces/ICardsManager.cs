using WisconsinGacha.Models;

namespace WisconsinGacha.Interfaces
{
    public interface ICardsManager
    {
        Task<List<Card>> GetCardsAsync();
        Task<Card> GetCardAsync(int id);
        Task<bool> CreateCardAsync(Card card);
        Task<bool> UpdateCardAsync(Card card);
        Task<bool> DeleteCardAsync(int id);
    }
}