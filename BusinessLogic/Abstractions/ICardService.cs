using System.Collections.Generic;
using BusinessLogic.DTO;

namespace BusinessLogic.Abstraction{
    public interface ICardService{
        CardDto AddCard(CardDto newCard);
        CardDto UpdateCard(CardDto newCard);
        bool DeleteCard(string guid);
        bool CloseCard(string guid);
        CardDto GetCardById(string guid);
        IEnumerable<CardDto> GetCards();
        IEnumerable<CardDto> GetCardsByStatus(int status);
        CardCommentDto AddCardComment(CardCommentDto newCardComment);
        IEnumerable<CardCommentDto> AddCardComments(IEnumerable<CardCommentDto> newCardComments);
        CardContentDto AddCardContent(CardContentDto newCardContent);

    }
}