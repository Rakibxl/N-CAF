import { Injectable, Inject } from '@angular/core';
import { profAssetInfo } from '../../Entity/ClientProfile/profAssetInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AssetInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveAssetInfo(data: profAssetInfo) {
       
        return this.http.post<APIResponse>(this.baseUrl + 'v1/AssetInfo/CreateOrUpdate', data);
    }
    public getAssetInfo(profileId: number) {
       
        return this.http.get<APIResponse>(this.baseUrl + `v1/AssetInfo/Profile/${profileId}`);
    }

    public getAssetById(profileId: number, assetInfoId: number) {
       
        return this.http.get<APIResponse>(this.baseUrl + `v1/AssetInfo/GetById/${profileId}/${assetInfoId}`);
    }
}
