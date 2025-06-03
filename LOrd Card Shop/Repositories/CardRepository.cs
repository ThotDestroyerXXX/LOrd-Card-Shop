using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
    public class CardRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<Card> GetAllCards()
        {
            return db.Card.ToList();
        }

        public static List<Card> GetAllCardsBySearchFilter(string searchFilter)
        {
            return db.Card.Where(card => card.CardName.Contains(searchFilter)).ToList();
        }

        public static Card FindCardById(int id)
        {
            return db.Card.Find(id);
        }

        public static Card DeleteCardById(int id)
        {
            Card card = db.Card.Find(id);

            if(card != null)
            {
                db.Card.Remove(card);
                db.SaveChanges();
                return card;
            }
            return null;
        }

        public static void CreateCard(Card card)
        {
            db.Card.Add(card);
            db.SaveChanges();
        }

        public static void UpdateCard(int id, string name, decimal price, string description, string type, string foil)
        {
            Card card = db.Card.Find(id);
            if(card != null)
            {
                card.CardName = name;
                card.CardPrice = price;
                card.CardDesc = description;
                card.CardType = type;
                card.isFoil = (foil == "yes");
                db.SaveChanges();
            }
        }
    }
}