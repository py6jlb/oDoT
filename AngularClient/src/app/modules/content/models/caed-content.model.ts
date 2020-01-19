import { ICardContentModel } from 'src/app/modules/content/@types/tasks';

export class CardContentModel{
    id: string;
    text: string;

    constructor(data: ICardContentModel){
        this.id = data.id;
        this.text = data.text;
    }
}