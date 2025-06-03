using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.WebServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Controllers
{
    public class CardController
    {
        public static Response<List<Card>> GetAllCards()
        {
            CardWebService cardWS = new CardWebService();
            String jsonResponse = cardWS.GetAllCards();

            return Json.Decode<Response<List<Card>>>(jsonResponse);
        }

        public static Response<List<Card>> GetAllCardsBySearchFilter(string search)
        {
            CardWebService cardWS = new CardWebService();
            String jsonResponse = cardWS.GetAllCardsBySearchFilter(search);

            return Json.Decode<Response<List<Card>>>(jsonResponse);
        }

        public static Response<Card> DeleteCardById(string id)
        {
            int cardId = int.Parse(id);
            CardWebService cardWS = new CardWebService();
            String jsonResponse = cardWS.DeleteCardById(cardId);

            return Json.Decode<Response<Card>>(jsonResponse);
        }

        public static Response<Card> CreateCard(string name, string price, string description, string type, string foil, bool isUpdate = false, string id = null)
        {
            bool isNumericCardPrice = decimal.TryParse(price, out decimal result);
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(foil))
            {
                return new Response<Card>
                {
                    Message = "All fields must be filled!",
                    Success = false,
                };
            }

            if(name.Length < 5 || name.Length > 50)
            {
                return new Response<Card>
                {
                    Message = "Card name must be between 5 and 50 characters long!",
                    Success = false,
                };
            }

            if(!isValidCardName(name))
            {
                return new Response<Card>
                {
                    Message = "Card name must only contain alphabet and white space!",
                    Success = false,
                };
            }

            if(!isNumericCardPrice)
            {
                return new Response<Card>
                {
                    Message = "Price must be a number!",
                    Success = false,
                };
            }

            decimal cardPrice = Decimal.Parse(price, CultureInfo.InvariantCulture);

            if(cardPrice < 10000)
            {
                return new Response<Card>
                {
                    Message = "Card Price must be greater or equal than 10000",
                    Success = false,
                };
            }

            if(description.Length >= 100)
            {
                return new Response<Card>
                {
                    Message = "Card description must be 100 characters at max",
                    Success = false,
                };
            }

            if(!type.Equals("Spell") && !type.Equals("Monster"))
            {
                return new Response<Card>
                {
                    Message = "You must choose the type between spell and monster!",
                    Success = false,
                };
            }

            if(!foil.Equals("yes") && !foil.Equals("no"))
            {
                return new Response<Card>
                {
                    Message = "You must choose the foil between yes and no!",
                    Success = false,
                };
            }

            CardWebService cardWS = new CardWebService();

            if (!isUpdate)
            {
                
                String jsonResponse = cardWS.CreateCard(name, cardPrice, description, type, foil);

                return Json.Decode<Response<Card>>(jsonResponse);
            }

            else
            {
                String jsonResponse = cardWS.UpdateCard(id, name, cardPrice, description, type, foil);

                return Json.Decode<Response<Card>>(jsonResponse);
            }

        }

        private static bool isValidCardName(string name)
        {
            foreach (char n in name)
            {
                if(!char.IsLetter(n) && !char.IsWhiteSpace(n))
                {
                    return false;
                }
            }
            return true;
        }

        public static Response<Card> GetCardById(string id)
        {
            int cardId = int.Parse(id);
            CardWebService cardWS = new CardWebService();
            String jsonResponse = cardWS.GetCardById(cardId);

            return Json.Decode<Response<Card>>(jsonResponse);
        }

    }
}