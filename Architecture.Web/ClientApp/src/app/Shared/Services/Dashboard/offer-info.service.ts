import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../Entity/Response/api-response';
import { OfferInfo } from '../../Entity/Dashboard/Offer-Info';

@Injectable({
  providedIn: 'root'
})
export class OfferInfoService {

  public baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log("baseUrl: ", baseUrl);
    this.baseUrl = baseUrl + 'api/';
  }

  public getMyOffer() {
    return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/GetMyOffer');
    }

    public getMyOfferByProfileId(profileId: number) {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/GetMyOffer');
    }

    public submitOffer(data: OfferInfo) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/OfferInfo/CreateOrUpdate', data);
    }
    public getCurrentStatus(id) {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/GetCurrentOffer/' + id);
    }

    public getMyProgressOffer() {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/GetMyProgressOffer');
    }

    //#region operator
    public getOperatorProgressOffer() {
         return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/OperatorProgressOffer');
    }

    public getOperatorCompletedOffer() {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/OperatorCompletedOffer');
    }

    public getOperatorPendingOffer() {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/OperatorPendingOffer');
    }
   //#endr operator end
   
    //#region Client
    public getClientProgressOffer() {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/ClientProgressOffer');
    }

    public getClientCompletedOffer() {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/ClientCompletedOffer');
    }
   //#endr operator end
}
