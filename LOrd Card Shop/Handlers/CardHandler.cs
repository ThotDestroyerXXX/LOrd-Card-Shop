using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Handlers
{
    public class CardHandler
    {
        public static Response<List<Card>> GetAllCards()
        {
            List<Card> cards = CardRepository.GetAllCards();

            if(cards == null || cards.Count <= 0)
            {
                return new Response<List<Card>>
                {
                    Message = "No Cards yet",
                    Success = false,
                };
            }

            else
            {
                return new Response<List<Card>>
                {
                    Message = "Cards found",
                    Success = true,
                    Payload = cards,
                };
            }
        }

        public static Response<List<Card>> GetAllCardsBySearchFilter(string search)
        {
            List<Card> cards = CardRepository.GetAllCardsBySearchFilter(search);

            if (cards == null || cards.Count <= 0)
            {
                return new Response<List<Card>>
                {
                    Message = "No Cards with name " + search + " found",
                    Success = false,
                };
            }

            else
            {
                return new Response<List<Card>>
                {
                    Message = "Cards found",
                    Success = true,
                    Payload = cards,
                };
            }
        }

        public static Response<Card> DeleteCardById(int id)
        {
            
            Card deletedCard = CardRepository.DeleteCardById(id);
            if(deletedCard == null)
            {
                return new Response<Card>
                {
                    Message = "Card not found!",
                    Success = false,
                };
            }
            else
            {
                return new Response<Card>
                {
                    Message = "Card deleted successfully",
                    Success = true,
                    Payload = deletedCard,
                };
            }
        }

        public static Response<Card> CreateCard(string name, decimal price, string description, string type, string foil)
        {
            Card newCard = CardFactory.CreateCard(name, price, description, type, foil);

            CardRepository.CreateCard(newCard);

            return new Response<Card>
            {
                Message = "Card created successfully!",
                Success = true,
                Payload = newCard,
            };
        }

        public static Response<Card> UpdateCard(string id, string name, decimal price, string description, string type, string foil)
        {
            int cardId = int.Parse(id);
            Card card = CardRepository.FindCardById(cardId);
            if(card != null)
            {
                CardRepository.UpdateCard(cardId, name, price, description, type, foil);

                return new Response<Card>
                {
                    Message = "Card Updated Successfully!",
                    Success = true,
                    Payload = card,
                };
            }

            else
            {
                return new Response<Card>
                {
                    Message = "Card not found!",
                    Success = false,
                };
            }
        }

        public static Response<Card> GetCardById(int id)
        {
            Card card = CardRepository.FindCardById(id);
            if(card != null)
            {
                return new Response<Card>
                {
                    Message = "Card retrieved successfully!",
                    Success = true,
                    Payload = card,
                };
            }
            else
            {
                return new Response<Card>
                {
                    Message = "Card not found!",
                    Success = false,
                };
            }
        }
    }
}