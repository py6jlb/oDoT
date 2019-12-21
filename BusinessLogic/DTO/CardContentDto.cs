using DataAccess.Entities;

namespace BusinessLogic.DTO
{
    public class CardContentDto
    {
        public CardContentDto(){}
        public CardContentDto(CardContent newCardContent){
            Id = newCardContent.Id.ToString();
            Text = newCardContent.Text;
        }

        public string Id { get; set; }
        public string Text { get; set; }
    }
}