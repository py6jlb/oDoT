using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace DataAccess.Repositories.Abstractions{
    public interface ICardCommentRepository
    {
        CardComment GetCommentById(Guid commentId);
        CardComment AddComment(CardComment newCardComment);
        IEnumerable<CardComment> AddComments(IEnumerable<CardComment> newCardComment);
    }
}