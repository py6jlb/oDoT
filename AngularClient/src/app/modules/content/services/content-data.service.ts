import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigService } from 'src/app/shared/services/config.service';
import { ISettingsModel, IKeyValuePair, ICardModel, ICardContentModel, ICardCommentModel } from '../@types/tasks';
import { SettingsModel } from '../models/settings-model';
import { forkJoin } from 'rxjs';
import { CardModel } from '../models/card.model';
import { TaskStatusEnum } from 'src/app/shared/enums/taskStatusEnum';

@Injectable()
export class ContentDataService {    
    public statuses: IKeyValuePair<number, string>[] = [];
    public priority: IKeyValuePair<number, string>[] = [];

    constructor(private http: HttpClient, private configService: ConfigService) { 
        this.preloadData().subscribe(z=>{
            this.statuses = z[0];
            this.priority = z[1];
        });      
    }  

    public getStatuses(){
        var result = this.http.get<IKeyValuePair<number, string>[]>(`${this.configService.config.baseUrl}/api/Settings/Statuses`)
        return result;
    }

    public getPriority(){
        var result = this.http.get<IKeyValuePair<number, string>[]>(`${this.configService.config.baseUrl}/api/Settings/Priority`)
        return result;
    }

    private preloadData(){
        const actionArray = forkJoin([this.getStatuses(), this.getPriority()]);
        return actionArray;
    }

    public getSettings(){
        var result = this.http.get<ISettingsModel>(`${this.configService.config.baseUrl}/api/Settings`)
        return result;
    }

    public saveSettings(data:SettingsModel){
        var result = this.http.post(`${this.configService.config.baseUrl}/api/Settings`, data)
        return result;
    }

    public addNewTask(data: ICardModel){
        var result = this.http.post<ICardModel>(`${this.configService.config.baseUrl}/api/Cards`, data)
        return result;
    }

    public getTasksByStatus(status: number){
        var result = this.http.get<ICardModel[]>(`${this.configService.config.baseUrl}/api/cards/${status}`)       
        return result;
    }

    public deleteTask(id: string){
        var result = this.http.delete<boolean>(`${this.configService.config.baseUrl}/api/cards/${id}`)       
        return result;
    }

    public closeTask(data: CardModel){
        const content = data.content != null ? {id: data.content.id, text: data.content.text} as ICardContentModel : null
        const comments = data.cardComments != null && data.cardComments.length === 0 ?
            data.cardComments.map(x=>{
                return {
                    id: x.id,
                    text: x.text,
                    createDateTime: x.createDateTime.getTime(),
                    notUserComment: x.notUserComment
                } as ICardCommentModel
            }) : [];

        const model = {
            id: data.id,
            name: data.name,
            createDateTime: Date.now(),
            deadLineDateTime: data.deadLineDateTime.getTime(),
            startPanicDateTime: data.startPanicDateTime.getTime(),
            panicIntervalInMiliseconds: data.panicIntervalInMiliseconds,
            defferalCount: 0,
            status: TaskStatusEnum.Close,
            priority: data.priority,
            content: content,
            cardComments: comments
          } as ICardModel

        var result = this.http.put<boolean>(`${this.configService.config.baseUrl}/api/cards`, model)
        return result;
    }
}