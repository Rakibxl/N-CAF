import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { OfferInfo } from '../../../Shared/Entity/Dashboard/Offer-Info';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';
import { GeneratePdfService } from '../../generate-pdf/services/generate-pdf.service';

@Component({
  selector: 'app-generate-pdf',
  templateUrl: './generate-pdf.component.html',
  styleUrls: ['./generate-pdf.component.css']
})
export class GeneratePdfComponent implements OnInit {
  pdfSrc: any;
    private profileId: number;
    private offerInfoId: number;
    private jobId: number;

    constructor(private alertService: AlertService, private sanitizer: DomSanitizer,
        private generatePdfService: GeneratePdfService,
        private offerInfoService: OfferInfoService,
        private activateRoute: ActivatedRoute
    ) { }

    ngOnInit() {
        this.activateRoute.paramMap.subscribe(res => {
            this.profileId = Number(res.get('profileId'));
            this.jobId = Number(res.get('jobId'));
            this.offerInfoId = Number(res.get('offerId'));
        })
    this.generatePDF();
  }

  getSanitizedUrl(url) {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

  generatePDF() {
    this.generatePdfService.generatePDF().subscribe(res => {
      if (res && res.data) {
        this.pdfSrc = this.getSanitizedUrl(this.generatePdfService.baseUrl + 'Generated PDF/' + res.data);
      }
    });
  }

  onLoad(pdfData) {
      console.log('pdfData: ', pdfData);
    }

    public fnSubmitOffer() {
        let offerInfo = new OfferInfo();
        offerInfo.JobId = this.jobId;
        offerInfo.ProfileId = this.profileId;
        offerInfo.OfferStatusId = 1;
        this.offerInfoService.submitOffer(offerInfo).subscribe((res) => {
            console.log("Response:: ", res);
        },
            (error) => {
                console.log("Error: ", error);
            });
        alert("ready to submit..");
    }

    public fnBackToOfferPage() {

    }
}
