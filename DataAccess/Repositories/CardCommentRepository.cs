using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using LiteDB;

namespace DataAccess.Repositories{
    public class CardCommentRepository : ICardCommentRepository
    {
        private readonly LiteDbContext _context;
        public CardCommentRepository(LiteDbContext context) => _context = context;

        public CardComment AddComment(CardComment newCardComment)
        {
            var id = _context.CardComments.Insert(newCardComment);
            var data = _context.CardComments.FindById(id);
            return data;
        }

        public IEnumerable<CardComment> AddComments(IEnumerable<CardComment> newCardComment)
        {
            var ids = new List<BsonValue>();
            var comments = newCardComment.Select(x=> new CardComment{
                Id = Guid.NewGuid(),
                CreateDateTime = x.CreateDateTime,
                NotUserComment = x.NotUserComment,
                Text = x.Text
            });
            foreach (var comment in comments)
            {
                var id = _context.CardComments.Insert(comment);
                ids.Add(id);
            }
            //var ids = comments.Select(x=>new BsonValue(x.Id));
            //var count = _context.CardComments.InsertBulk(comments);
            var data = _context.CardComments.Find(Query.In("_id", new BsonArray(ids)));
            return data;
        }

        public CardComment GetCommentById(Guid commentId)
        {
            var data = _context.CardComments.FindById(new BsonValue(commentId));
            return data;
        }
    }
}