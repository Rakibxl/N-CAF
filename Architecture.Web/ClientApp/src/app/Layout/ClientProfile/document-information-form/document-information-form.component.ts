import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profDocumentInfo } from '../../../Shared/Entity/ClientProfile/profDocumentInfo';
import { DocumentInfoService } from '../../../Shared/Services/ClientProfile/document-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';

@Component({
  selector: 'app-document-information-form',
  templateUrl: './document-information-form.component.html',
  styleUrls: ['./document-information-form.component.css']
})
export class DocumentInformationFormComponent implements OnInit {

    public documentInfoForm = new profDocumentInfo();

    constructor(private documentInfoService: DocumentInfoService, private alertService: AlertService, private router: Router, private route: ActivatedRoute) { }
    private profileId: number;
    private documentInfoId: number;

    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.documentInfoId = +this.route.snapshot.paramMap.get("id") || 0;

        console.log("this.profileId:", this.profileId, "this.documentInfoId", this.documentInfoId);
        if (this.profileId != 0 && this.documentInfoId != 0) {
            this.getDocument()
        }
    }

    public onSubmit() {
        debugger;
        console.table(this.documentInfoForm);
        this.documentInfoForm.profileId = this.profileId;

        this.documentInfoService.saveDocumentInfo(this.documentInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getDocument() {
        debugger;
        this.documentInfoService.getDocumentById(this.profileId, this.documentInfoId).subscribe(
            (success: APIResponse) => {
                this.documentInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/client-profile/document-info/${this.profileId}`]);
        return false;
    }

}
