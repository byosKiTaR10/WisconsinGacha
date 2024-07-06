using Microsoft.AspNetCore.Mvc;
using WisconsinGacha.Interfaces;
using WisconsinGacha.Models;

namespace WisconsinGacha.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardsManager cardsManager;

        public CardsController(ICardsManager cardsManager)
        {
            this.cardsManager = cardsManager;
        }

        [HttpGet]
        public string GetCards()
        {
            List<Card> cards = cardsManager.GetCardsAsync().Result;
            string result = "{\n";
            foreach (Card card in cards)
            {
                result +=
                    "    {\n" +
                    "        'Id': " + card.Id + ",\n"
                    + "        'Name': " + card.Name + ",\n"
                    + "        'Image': " + card.Image + ",\n"
                    + "        'Anime': " + card.Anime + ",\n"
                    + "        'Rarity': " + card.Rarity + "\n"
                    + "    },\n";
            }
            result = result.Substring(0, result.Length - 2);
            result += "\n}";
            return result;
        }

        [HttpGet("{id}")]
        public string GetCard(int id) 
        {
            string result = "";
            var card = cardsManager.GetCardAsync(id).Result;
            if (card == null)
            {
                result = "Specified Id does not match any existing card";
            }
            else
            {
                result =
                    "{\n" +
                    "    'Id': " + card.Id + ",\n"
                    + "    'Name': " + card.Name + ",\n"
                    + "    'Image': " + card.Image + ",\n"
                    + "    'Anime': " + card.Anime + ",\n"
                    + "    'Rarity': " + card.Rarity + "\n}";
            }
            
            return result;
        }

        [HttpPost]
        public string CreateCard([FromBody]Card card)
        {
            bool cardCreated = cardsManager.CreateCardAsync(card).Result;
            string result = "";
            if (cardCreated)
            {
                result = "Card was created successfully.";
            }
            else
            {
                result = "Card could not be created, check if it already exists.";
            }
            return result;
        }

        [HttpPut]
        public string UpdateCard([FromBody]Card card)
        {
            string result = "";
            if (cardsManager.UpdateCardAsync(card).Result)
            {
                result = "Card has been updated successfully.";

            } else
            {
                result = "Card could not be updated.";
            }
            return result;
        }

        [HttpDelete("{id}")]
        public string DeleteCard(int id) 
        {
            bool isCardDeleted = cardsManager.DeleteCardAsync(id).Result;
            string result = "";
            if (isCardDeleted)
            {
                result = "Card was deleted successfully";
            }
            else
            {
                result = "Card could not be deleted";
            }
            return result;
        }
    }
}
