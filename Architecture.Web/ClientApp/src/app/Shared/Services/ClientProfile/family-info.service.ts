import { Injectable, Inject } from '@angular/core';
import { ProfFamilyInfo } from '../../Entity/ClientProfile/profFamilyInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FamilyInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveFamilyInfo(data: ProfFamilyInfo) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/FamilyInfo/CreateOrUpdate', data);
    }
}
