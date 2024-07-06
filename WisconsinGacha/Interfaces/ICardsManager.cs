using WisconsinGacha.Models;

namespace WisconsinGacha.Interfaces
{
    public interface ICardsManager
    {
        Task<bool> CreateCardAsync(Card card);
        Task<List<Card>> GetCardsAsync();
        Task<bool> DeleteCardAsync(int id);
        Task<Card> GetCardAsync(int id);
        Task<bool> UpdateCardAsync(Card card);
    }
}