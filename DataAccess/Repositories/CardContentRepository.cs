using System;
using System.Collections.Generic;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using LiteDB;

namespace DataAccess.Repositories{
    public class CardContentRepository : ICardContentRepository
    {
        private readonly LiteDbContext _context;
        public CardContentRepository(LiteDbContext context) => _context = context;

        public CardContent AddContent(CardContent newCardContent)
        {
            var id = _context.CardContents.Insert(newCardContent);
            var data = _context.CardContents.FindById(id);
            return data;
        }

        public CardContent GetContentById(Guid contentId)
        {
            var data = _context.CardContents.FindById(new BsonValue(contentId));
            return data;
        }

        public CardContent UpdateContent(CardContent CardContent)
        {
            throw new NotImplementedException();
        }
    }
}