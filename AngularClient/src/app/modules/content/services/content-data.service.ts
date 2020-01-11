import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigService } from 'src/app/shared/services/config.service';
import { ISettingsModel, IKeyValuePair, ICardModel } from '../@types/tasks';
import { SettingsModel } from '../models/settings-model';
import { forkJoin } from 'rxjs';

@Injectable()
export class ContentDataService {    
    public baseUrl: string;
    public statuses: IKeyValuePair<number, string>[] = [];
    public priority: IKeyValuePair<number, string>[] = [];

    constructor(private http: HttpClient, private config: ConfigService) { 
        this.config.loadConfig().subscribe(x=>{
            this.baseUrl = x.baseUrl;
            this.preloadData().subscribe(z=>{
                this.statuses = z[0];
                this.priority = z[1];
            });
        });        
    }  

    public getCard(){
        return [];
    }

    public getStatuses(){
        var result = this.http.get<IKeyValuePair<number, string>[]>(`${this.baseUrl}/Settings/Statuses`)
        return result;
    }

    public getPriority(){
        var result = this.http.get<IKeyValuePair<number, string>[]>(`${this.baseUrl}/Settings/Priority`)
        return result;
    }

    private preloadData(){
        const actionArray = forkJoin([this.getStatuses(), this.getPriority()]);
        return actionArray;
    }

    public getSettings(){
        var result = this.http.get<ISettingsModel>(`${this.baseUrl}/Settings`)
        return result;
    }

    public saveSettings(data:SettingsModel){
        var result = this.http.post(`${this.baseUrl}/Settings`, data)
        return result;
    }

    public addNewTask(data: any){
        console.log(data)        
        var result = this.http.post(`${this.baseUrl}/Cards/Post`, data)
        return result;
    }
}