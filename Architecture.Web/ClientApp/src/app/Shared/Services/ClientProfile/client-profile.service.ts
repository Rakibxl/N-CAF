import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../Entity/Response/api-response';


@Injectable({
  providedIn: 'root'
})
export class ClientProfileService {
  public baseUrl: string;
  public basicInfoEndpoint: string;
  profileId: number = 0;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/';
    this.basicInfoEndpoint = this.baseUrl + 'v1/BasicInfo';
  }

  getBasicInfoList() {
    let url = this.basicInfoEndpoint + "/GetBasicInfos";
    return this.http.get<APIResponse>(`${url}`);
  }

  getBasicInfo(profileId) {
    let url = this.basicInfoEndpoint + "/GetBasicInfo?profileId=" + profileId;
    return this.http.get<APIResponse>(`${url}`);
    }
    getBasicInfoByEmailId(emailId) {
        let url = this.basicInfoEndpoint + "/GetBasicInfo?EmailId=" + emailId;
        return this.http.get<APIResponse>(`${url}`);
    }

  getCurrentUserBasicInfo() {
    let url = this.basicInfoEndpoint + "/GetCurrentUserBasicInfo";
    return this.http.get<APIResponse>(`${url}`);
  }

  createOrUpdateBasicInfo(data) {
    let url = this.basicInfoEndpoint + "/CreateOrUpdate";
    return this.http.post<APIResponse>(`${url}`, data);
  }
}
