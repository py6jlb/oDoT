import { CardContentModel } from './caed-content.model';
import { CardCommentModel } from './card-comment.model';
import { ICardModel } from '../@types/tasks';

export class CardModel{
    id: string;
    name: string;
    createDateTime: Date;
    deadLineDateTime : Date;
    startPanicDateTime : Date;
    panicIntervalInMiliseconds: number;
    defferalCount: number;
    status: number;
    priority: number;
    content: CardContentModel;
    cardComments: CardCommentModel[];

    constructor(data: ICardModel){
        this.id = data.id;
        this.name = data.name;
        this.createDateTime = new Date(data.createDateTime);
        this.deadLineDateTime = data.deadLineDateTime != null ? new Date(data.deadLineDateTime) : null;
        this.startPanicDateTime = data.startPanicDateTime != null ? new Date(data.startPanicDateTime) : null;
        this.panicIntervalInMiliseconds = data.panicIntervalInMiliseconds;
        this.defferalCount = data.defferalCount;
        this.status = data.status;
        this.priority = data.priority;
        this.content = data.content!= null ? new CardContentModel(data.content) : null;
        this.cardComments = data.cardComments != null ?  data.cardComments.map(x=> new CardCommentModel(x)) : [];
    }
}