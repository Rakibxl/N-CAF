import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../Entity/Response/api-response';

@Injectable({
  providedIn: 'root'
})
export class OfferInfoService {

  public baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log("baseUrl: ", baseUrl);
    this.baseUrl = baseUrl + 'api/';
  }

  getMyOffer() {
    return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/GetMyOffer');
  }
}
