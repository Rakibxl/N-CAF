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

  getDashboardData() {
    return this.http.get<APIResponse>(this.baseUrl + 'v1/dashboard');
  }
}
