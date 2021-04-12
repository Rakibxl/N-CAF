import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../Entity/Response/api-response';
import { OfferInfo } from '../../Entity/Dashboard/Offer-Info';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OfferInfoService {

  public baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log("baseUrl: ", baseUrl);
    this.baseUrl = baseUrl + 'api/';
    }

  public static subjectToReloadComponent = new Subject<any>();

    public getMyOffer(profileId: number) {
      return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/GetMyOffer/' + profileId);
    }

    public getMyOfferByProfileId(profileId: number) {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/GetMyOffer/' + profileId);
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

    public async operatorOfferAcceptRequest(offerInfoId) {
        return await this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/OperatorOfferAcceptRequest/' + offerInfoId);
    }
    public async operatorOfferRevertRequest(offerInfoId) {
        return await this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/OperatorOfferRevertRequest/' + offerInfoId);
    }

    public async operatorOfferStatusChange(profileId: number, offerInfoId: number, status) {
        return await this.http.get<APIResponse>(this.baseUrl + `v1/OfferInfo/OperatorOfferStatusChange?profileId=${profileId}&offerInfoId=${offerInfoId}&status=${status}`);
    }
   //#endr operator end
   
    //#region Client
    public getClientProgressOffer(profileId:number) {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/ClientProgressOffer/' + profileId);
    }

    public getClientCompletedOffer(profileId: number) {
        return this.http.get<APIResponse>(this.baseUrl + 'v1/OfferInfo/ClientCompletedOffer/' + profileId);
    }
   //#endr operator end
}
