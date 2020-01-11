import { ISettingsModel } from '../@types/tasks';

export class SettingsModel{
    id: string;
    deadlineTimeSpanInMiliseconds: number;
    panicTimeSpanInMiliseconds: number;
    startPanicForTimeSpanInMiliseconds: number;

    constructor(data: ISettingsModel){
        this.id = data.id;
        this.deadlineTimeSpanInMiliseconds= data.deadlineTimeSpanInMiliseconds;
        this.panicTimeSpanInMiliseconds= data.panicTimeSpanInMiliseconds;
        this.startPanicForTimeSpanInMiliseconds= data.startPanicForTimeSpanInMiliseconds;
    }
}