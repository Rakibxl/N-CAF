import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../Entity/Response/api-response';


@Injectable({
  providedIn: 'root'
})
export class ClientProfileService {
  public baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + 'api/';
  }

  saveBasicInfo(data) {
    return this.http.post<APIResponse>(this.baseUrl + 'ClientProfile/save-basic-info', data);
    // return this.http.post(this.baseUrl + 'v1/dashboard', data);
  }
}
