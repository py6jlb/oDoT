using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories.Abstractions{
    public interface ICardRepository
    {
        IEnumerable<Card> GetCards();
        Card GetCardById(Guid id);
        Card AddCard(Card newCard);
    }
}