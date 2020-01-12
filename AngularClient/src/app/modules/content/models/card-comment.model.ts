import { ICardCommentModel } from 'src/app/modules/content/@types/tasks';

export class CardCommentModel{
    id: string;
    text: string;
    createDateTime: Date;
    notUserComment: boolean;

    constructor(data: ICardCommentModel){
        this.id = data.id;
        this.text = data.text;
        this.notUserComment = data.notUserComment,
        this.createDateTime = new Date(data.createDateTime);
    }
}