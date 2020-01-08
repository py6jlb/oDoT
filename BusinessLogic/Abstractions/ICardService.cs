using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Abstraction{
    public interface ICardService{
        CardDto AddCard(CardDto newCard);
        CardDto GetCardById(string guid);
        IEnumerable<CardDto> GetCards();
        CardCommentDto AddCardComment(CardCommentDto newCardComment);
        IEnumerable<CardCommentDto> AddCardComments(IEnumerable<CardCommentDto> newCardComments);
        CardContentDto AddCardContent(CardContentDto newCardContent);

    }
}