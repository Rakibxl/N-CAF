import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { OfferInfo } from '../../../Shared/Entity/Dashboard/Offer-Info';
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
    public profileId: number;
   public jobId: number;
    public offerInfoId: number;
    public offerInfo: OfferInfo = new OfferInfo();
    public fileToUpload: File = null;
    @ViewChild('content', { static: true }) modalContent: ElementRef;

    constructor(private alertService: AlertService, private sanitizer: DomSanitizer,
        private generatePdfService: GeneratePdfService,
        private offerInfoService: OfferInfoService,
        private activateRoute: ActivatedRoute, private modalService: NgbModal,
        private router: Router
    ) { }

    ngOnInit() {
        this.activateRoute.paramMap.subscribe(res => {
            this.profileId = Number(res.get('profileId'));
            this.jobId = Number(res.get('jobId'));
            this.offerInfoId = Number(res.get('offerId'))||0;

            this.getOfferInfo();
            this.getGeneratePDF();
        })
  }
    getSanitizedUrl(url) {
        return this.sanitizer.bypassSecurityTrustResourceUrl(url);
    }

   public async getGeneratePDF() {
        await this.generatePdfService.getGeneratePDF(this.profileId, this.offerInfoId).then(res => {
            console.log("pdf response:", res);
            if (res && res.data) {
                this.pdfSrc = this.getSanitizedUrl(this.generatePdfService.baseUrl + res.data);
            }
        });
    }

    public async getOfferInfo() {
        if (this.offerInfoId == 0) {
            return false;
        }

        this.offerInfoService.getOfferById(this.offerInfoId).then(res => {
            this.offerInfo = res.data || new OfferInfo();
            console.log("this.offerInfo::", this.offerInfo);
        });
    }

    public fnUpdateOffer() {
        this.alertService.tosterSuccess("Offer information with Pdf updated successfully.");
    }

    public fnBackToOfferPage() {
        this.router.navigate([`/dashboard`]);
    }

    public fnSubmittedOffer() {
        this.fnRequestToChangeStatus("SubmittedOffer");
    }

    public fnDocumentsRequired() {
        this.fnRequestToChangeStatus("DocumentsRequired");
    }

    public fnCompletedOffer() {
        this.modalService.open(this.modalContent, {
            size: 'lg'
        });
        //this.fnRequestToChangeStatus("CompletedOffer");
    }

    public async fnCompleteTheOffer() {
        if (this.fileToUpload == null) {
            this.alertService.tosterWarning("Please select receipt documents and try again.");
            return false;
        }
        const formData = new FormData();
        formData.append('file', this.fileToUpload, this.fileToUpload.name);
        await this.offerInfoService.operatorOfferCompleted(this.profileId, this.offerInfoId, formData).then(res => {
            this.modalService.dismissAll();
            this.getOfferInfo();
            this.alertService.tosterSuccess("Completed the offer process");
        });

    }

    public async fnRequestToChangeStatus(status: any) {
        await this.offerInfoService.operatorOfferStatusChange(this.profileId, this.offerInfoId, status).then((res: APIResponse) => {
            this.alertService.tosterSuccess("Your request has been applied.");
        },
            (e) => { }        );
    }
    onLoad(pdfData) {
        console.log('pdfData: ', pdfData);
    }

    public handleFileInput(files: FileList) {
        this.fileToUpload = files.item(0);
    }
}
