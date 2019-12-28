import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from 'src/app/shared/services/config.service';

@Injectable()
export class ContentDataService {    
    constructor(private http: HttpClient, private config: ConfigService) { }  

    public getCard(){
        return [];
    }
}