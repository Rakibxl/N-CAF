import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';
import { GeneratePdfService } from '../services/generate-pdf.service';

@Component({
  selector: 'app-complete-offer-pdf',
  templateUrl: './complete-offer-pdf.component.html',
  styleUrls: ['./complete-offer-pdf.component.css']
})
export class CompleteOfferPdfComponent implements OnInit {
    pdfSrc: any;
    profileId: number;
    jobId: number;
    offerInfoId: number;

    constructor(private alertService: AlertService, private sanitizer: DomSanitizer,
        private generatePdfService: GeneratePdfService,
        private offerInfoService: OfferInfoService,
        private activateRoute: ActivatedRoute,) { }

    ngOnInit() {
        this.activateRoute.paramMap.subscribe(res => {
            this.profileId = Number(res.get('profileId'));
            this.jobId = Number(res.get('jobId'));
            this.offerInfoId = Number(res.get('offerId'));
            this.getGeneratePDF();
        })
  }
    getSanitizedUrl(url) {
        return this.sanitizer.bypassSecurityTrustResourceUrl(url);
    }

    getGeneratePDF() {
        this.generatePdfService.getGeneratePDF(this.profileId, this.offerInfoId).subscribe(res => {
            console.log("pdf response:", res);
            if (res && res.data) {
                this.pdfSrc = this.getSanitizedUrl(this.generatePdfService.baseUrl + res.data);
            }
        });
    }

    public fnUpdateOffer() {
        this.alertService.tosterSuccess("Offer information with Pdf updated successfully.");
    }

    public fnBackToOfferPage() {

    }

    public fnSubmittedOffer() {
        this.fnRequestToChangeStatus("SubmittedOffer");
    }

    public fnDocumentsRequired() {
        this.fnRequestToChangeStatus("DocumentsRequired");
    }

    public fnCompletedOffer() {
        this.fnRequestToChangeStatus("CompletedOffer");
    }

    public async fnRequestToChangeStatus(status: any) {
        await (await this.offerInfoService.operatorOfferStatusChange(this.profileId, this.offerInfoId, status)).subscribe(async (res: APIResponse) => {
            this.alertService.tosterSuccess("Your request has been updated.");
        }, error => {
            console.log("Error ", error);
        });
    }
    onLoad(pdfData) {
        console.log('pdfData: ', pdfData);
    }
}
