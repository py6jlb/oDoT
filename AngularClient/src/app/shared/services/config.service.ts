import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

export interface IConfiguration{
    baseUrl: string
}

@Injectable()
export class ConfigService {
    public config: IConfiguration;

    constructor(private http: HttpClient) { 
        this.http.get<IConfiguration>(environment.configPath).subscribe(x=> this.config = x);
    }
}