import { Injectable, Inject } from '@angular/core';
import { profDocumentInfo } from '../../Entity/ClientProfile/profDocumentInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DocumentInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public saveDocumentInfo(data: any) {
       
        return this.http.post<APIResponse>(this.baseUrl + 'v1/DocumentInfo/document/save', data);
    }
    public getDocumentInfo(profileId: number) {
       
        return this.http.get<APIResponse>(this.baseUrl + `v1/DocumentInfo/Profile/${profileId}`);
    }

    public getDocumentById(profileId: number, addressInfoId: number) {
       
        return this.http.get<APIResponse>(this.baseUrl + `v1/DocumentInfo/GetById/${profileId}/${addressInfoId}`);
    }

}
