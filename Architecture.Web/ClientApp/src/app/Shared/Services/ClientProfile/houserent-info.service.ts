import { Injectable, Inject } from '@angular/core';
import { profHouseRentInfo } from '../../Entity/ClientProfile/profHouseRentInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HouseRentInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveHouseRentInfo(data: profHouseRentInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/HouseRentInfo/CreateOrUpdate', data);
    }
    public getHouseRentInfo(profileId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/HouseRentInfo/Profile/${profileId}`);
    }
}
