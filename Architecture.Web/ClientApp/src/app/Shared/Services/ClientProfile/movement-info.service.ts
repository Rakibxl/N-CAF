import { Injectable, Inject } from '@angular/core';
import { profMovementInfo } from '../../Entity/ClientProfile/profMovementInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MovementInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveMovementInfo(data: profMovementInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/MovementInfo/CreateOrUpdate', data);
    }
    public getMovementInfo(profileId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/MovementInfo/Profile/${profileId}`);
    }
    public getMovementById(profileId: number, movementInfoId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/MovementInfo/GetById/${profileId}/${movementInfoId}`);
    }
}
