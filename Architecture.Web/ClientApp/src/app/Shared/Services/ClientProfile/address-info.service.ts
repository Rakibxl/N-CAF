import { Injectable, Inject } from '@angular/core';
import { profAddressInfo } from '../../Entity/ClientProfile/profAddressInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AddressInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveAddressInfo(data: profAddressInfo) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/AddressInfo/CreateOrUpdate', data);
    }
    public getAddressInfo(profileId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/AddressInfo/Profile/${profileId}`);
    }

    public getAddressById(profileId: number, addressInfoId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/AddressInfo/GetById/${profileId}/${addressInfoId}`);
    }

}
