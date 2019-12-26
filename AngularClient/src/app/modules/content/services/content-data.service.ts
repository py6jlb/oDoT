import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class ContentDataService {
    configPath = `assets/${environment.configName}`
    
    constructor(private http: HttpClient) { }  
}