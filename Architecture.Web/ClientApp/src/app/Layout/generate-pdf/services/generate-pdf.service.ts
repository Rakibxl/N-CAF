import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';


@Injectable({
  providedIn: 'root'
})
export class GeneratePdfService {
  baseUrl: string;
  generatePDFEndPoint: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.generatePDFEndPoint = this.baseUrl + 'api/' + 'PDFGenerator/get-pdf';
  }

  public generatePDF() {
    return this.http.get<APIResponse>(`${this.generatePDFEndPoint}`);
    }

    public getGeneratePDF(profileId: number, offerInfoId: number): Promise<APIResponse> {
        return this.http.get<APIResponse>(`${this.baseUrl}api/PDFGenerator/GetGeneratedOfferPDF/${profileId}/${offerInfoId}`).toPromise();
  }
}
