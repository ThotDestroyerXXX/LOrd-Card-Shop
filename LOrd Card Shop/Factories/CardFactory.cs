using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factories
{
    public class CardFactory
    {
        public static Card CreateCard(string name, decimal price, string description, string type, string foil)
        {
            Card newCard = new Card();
            newCard.CardName = name;
            newCard.CardPrice = price;
            newCard.CardDesc = description;
            newCard.CardType = type;
            newCard.isFoil = (foil.Equals("yes"));

            return newCard;
        }
    }
}