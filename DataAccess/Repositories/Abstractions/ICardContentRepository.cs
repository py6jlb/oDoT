using System;
using DataAccess.Entities;

namespace DataAccess.Repositories.Abstractions{
    public interface ICardContentRepository
    {
        CardContent GetContentById(Guid contentId);
        CardContent AddContent(CardContent newCardContent);
        CardContent UpdateContent(CardContent CardContent);
    }
}