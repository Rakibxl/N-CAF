import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../Entity/Response/api-response';


@Injectable({
  providedIn: 'root'
})
export class ClientProfileService {
  public baseUrl: string;
  public basicInfoEndpoint: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/';
    this.basicInfoEndpoint = this.baseUrl + 'v1/BasicInfo';
  }

  createOrUpdateBasicInfo(data) {
    return this.http.post<APIResponse>(`${this.basicInfoEndpoint}`, data);
  }
}
