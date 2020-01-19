export interface ICardModel{
    id: string;
    name: string;
    createDateTime: number;
    deadLineDateTime: number;
    startPanicDateTime: number;
    panicIntervalInMiliseconds: number;
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
    createDateTime: number;
    notUserComment: boolean;
}

export interface ISettingsModel{
    id: string;
    deadlineTimeSpanInMiliseconds: number;
    panicTimeSpanInMiliseconds: number;
    startPanicForTimeSpanInMiliseconds: number;
}

export interface IKeyValuePair<T, V>{
    key: T,
    value: V
}