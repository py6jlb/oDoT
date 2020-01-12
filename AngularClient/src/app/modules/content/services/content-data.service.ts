import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigService } from 'src/app/shared/services/config.service';
import { ISettingsModel, IKeyValuePair, ICardModel } from '../@types/tasks';
import { SettingsModel } from '../models/settings-model';
import { forkJoin } from 'rxjs';

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
        var result = this.http.get<IKeyValuePair<number, string>[]>(`${this.configService.config.baseUrl}/Settings/Statuses`)
        return result;
    }

    public getPriority(){
        var result = this.http.get<IKeyValuePair<number, string>[]>(`${this.configService.config.baseUrl}/Settings/Priority`)
        return result;
    }

    private preloadData(){
        const actionArray = forkJoin([this.getStatuses(), this.getPriority()]);
        return actionArray;
    }

    public getSettings(){
        var result = this.http.get<ISettingsModel>(`${this.configService.config.baseUrl}/Settings`)
        return result;
    }

    public saveSettings(data:SettingsModel){
        var result = this.http.post(`${this.configService.config.baseUrl}/Settings`, data)
        return result;
    }

    public addNewTask(data: any){
        console.log(data)        
        var result = this.http.post<ICardModel>(`${this.configService.config.baseUrl}/Cards/Post`, data)
        return result;
    }

    public getTasksByStatus(status: number){
        var result = this.http.get<ICardModel[]>(`${this.configService.config.baseUrl}/Cards/GetByStatus?status=${status}`)       
        return result;
    }

    public deleteTask(id: string){
        console.log(id);
        var result = this.http.get<boolean>(`${this.configService.config.baseUrl}/Cards/DeleteCard?id=${id}`)       
        return result;
    }

    public closeTask(id: string){
        console.log(id);
        var result = this.http.get<boolean>(`${this.configService.config.baseUrl}/Cards/CloseCard?id=${id}`)       
        return result;
    }
}