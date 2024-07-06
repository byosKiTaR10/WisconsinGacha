using Microsoft.EntityFrameworkCore;
using WisconsinGacha.Interfaces;
using WisconsinGacha.Models;

namespace WisconsinGacha.Database
{
    public class CardsManager : ICardsManager
    {
        private readonly AppDbContext context;

        public CardsManager(AppDbContext context)
        {
            this.context = context;
        }
        
        public async Task<List<Card>> GetCardsAsync()
        {
            return await context.Cards.ToListAsync();
        }

        public async Task<Card> GetCardAsync(int id) 
        {
            var card = await context.Cards.FindAsync(id);
            return card;
        }

        public async Task<bool> CreateCardAsync(Card card)
        {
            bool isNewCard = false;
            if (context.Cards.FindAsync(card.Id).Result == null && context.Cards.FirstOrDefaultAsync(x => x.Name.ToLower() == card.Name.ToLower()).Result == null)
            {
                context.Cards.Add(card);
                await context.SaveChangesAsync();
                isNewCard = true;
            }
            return isNewCard;
        }

        public async Task<bool> UpdateCardAsync(Card card)
        {
            var existingCard = await context.Cards.FindAsync(card.Id);

            if (existingCard != null)
            {
                existingCard.Name = card.Name;
                existingCard.Image = card.Image;
                existingCard.Anime = card.Anime;
                existingCard.Rarity = card.Rarity;
            }
            var recordsAffected = await context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public async Task<bool> DeleteCardAsync(int id)
        {
            bool isCardDeleted = false;

            var card = await context.Cards.FindAsync(id);

            if (card != null)
            {
                context.Cards.Remove(card);
                await context.SaveChangesAsync();
                isCardDeleted = true;
            }
            return isCardDeleted;
        }

    }
}
