import { Injectable, Inject } from '@angular/core';
import { profWorkerInfo } from '../../Entity/ClientProfile/profWorkerInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class WorkerInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveWorkerInfo(data: profWorkerInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/WorkerInfo/CreateOrUpdate', data);
    }
    public getWorkerInfo(profileId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/WorkerInfo/Profile/${profileId}`);
    }

    public getWorkerById(profileId: number, workerInfoId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/WorkerInfo/GetById/${profileId}/${workerInfoId}`);
    }
}
