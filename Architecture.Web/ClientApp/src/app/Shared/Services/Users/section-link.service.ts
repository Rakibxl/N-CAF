import { Injectable, Inject } from '@angular/core';
import { SectionLink } from '../../Entity/Users/SectionLink';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SectionLinkService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        debugger;    
        this.baseUrl = baseUrl + 'api/';
    }

    public saveSectionLinkInfo(data: SectionLink) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/SectionLinkInfo/CreateOrUpdate', data);
    }
    public getSectionLinkInfo() {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/SectionLinkInfo/GetQuestion`);
    }

    public getSectionLinkById(sectionlinkId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/SectionLinkInfo/GetById/${sectionlinkId}`);
    }
    
}
