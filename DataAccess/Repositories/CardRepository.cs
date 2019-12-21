using System;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;

namespace DataAccess.Repositories{
    public class CardRepository : ICardRepository
    {
        private readonly LiteDbContext _context;

        public CardRepository(LiteDbContext context) => _context = context;

        public Card AddCard(Card newCard)
        {
            var id = _context.Cards.Insert(newCard);
            var data = _context.Cards.IncludeAll().FindById(id);
            return data;
        }

        public Card GetCardById(Guid id)
        {
            var data = _context.Cards.IncludeAll().FindById(id);
           return data;
        }

        public IEnumerable<Card> GetCards()
        {
           var data = _context.Cards.IncludeAll().FindAll();
           return data;
        }
    }
}