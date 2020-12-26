import { Injectable, Inject } from '@angular/core';
import { JobInfo } from '../../Entity/Users/JobInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class JobInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        debugger;    
        this.baseUrl = baseUrl + 'api/';
    }

    public saveJobInfo(data: JobInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/JobInfo/CreateOrUpdate', data);
    }
    public getJobInfo() {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/JobInfo/GetJob`);
    }

    public getJobById(jobInfoId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/JobInfo/GetById/${jobInfoId}`);
    }
    
}
