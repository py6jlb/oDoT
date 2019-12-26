export interface ICardModel{
    id: string;
    name: string;
    createDateTimeInMiliseconds: number;
    deadLineDateTimeInMiliseconds: number;
    startPanicDateTimeInMiliseconds: number;
    panicIntervalInMiliseconds: number;
    doNotDisturbInMiliseconds: number;
    defferalCount: number;
    status: number;
    priority: number;
    content: ICardContentModel;
    cardComments: ICardCommentModel[];
}

export interface ICardContentModel{
    id: string;
    text: string;
}

export interface ICardCommentModel{
    id: string;
    text: string;
    createDateTimeInMiliseconds: number;
    notUserComment: boolean;
}