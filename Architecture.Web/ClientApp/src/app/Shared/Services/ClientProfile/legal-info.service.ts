import { Injectable, Inject } from '@angular/core';
import { profLegalInfo } from '../../Entity/ClientProfile/profLegalInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LegalInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveLegalInfo(data: profLegalInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/LegalInfo/CreateOrUpdate', data);
    }
    public getLegalInfo(profileId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/LegalInfo/Profile/${profileId}`);
    }
}
