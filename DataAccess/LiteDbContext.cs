using System;
using DataAccess.Entities;
using LiteDB;

namespace DataAccess{
    public class LiteDbContext{
        public readonly LiteDatabase Context;
        public readonly BsonMapper Mapper;
        public LiteCollection<Card> Cards;
        public LiteCollection<CardComment> CardComments;
        public LiteCollection<GlobalUserParameters> GlobalUsersParameters;
        public LiteCollection<CardContent> CardContents;



        public LiteDbContext(string connectionString)
        {
            try
            {
                Mapper = GetMapper();
                Context = new LiteDatabase(connectionString, Mapper);                
                Cards = Context.GetCollection<Card>("cards");
                CardComments = Context.GetCollection<CardComment>("card_comments");
                GlobalUsersParameters = Context.GetCollection<GlobalUserParameters>("global_users_parametrs");
                CardContents = Context.GetCollection<CardContent>("card_contents");

            }
            catch (Exception ex)
            {
                throw new Exception("Неудалось создать или подключиться к файлу базы данных", ex);
            }
        }

        private BsonMapper GetMapper(){
            var mapper = BsonMapper.Global;
            mapper.Entity<Card>()
                .Id(x=>x.Id)
                .DbRef(x=>x.CardComments, "card_comments")
                .DbRef(x=>x.Content, "card_contents");
            mapper.Entity<GlobalUserParameters>().Id(x=>x.Id);
            mapper.Entity<CardComment>().Id(x=>x.Id);
            mapper.Entity<CardContent>().Id(x=>x.Id);
            return mapper;
        }



    }
}