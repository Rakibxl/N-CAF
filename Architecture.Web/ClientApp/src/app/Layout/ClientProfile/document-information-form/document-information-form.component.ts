import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { profDocumentInfo } from '../../../Shared/Entity/ClientProfile/profDocumentInfo';
import { DocumentInfoService } from '../../../Shared/Services/ClientProfile/document-info.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';


@Component({
  selector: 'app-document-information-form',
  templateUrl: './document-information-form.component.html',
  styleUrls: ['./document-information-form.component.css']
})
export class DocumentInformationFormComponent implements OnInit {

    public documentInfoForm = new profDocumentInfo();
    fileToUpload: File = null;
    constructor(private documentInfoService: DocumentInfoService, private alertService: AlertService, private commonService: CommonService, private router: Router, private route: ActivatedRoute, private dropdownService: DropdownService) { }
    private profileId: number;
    private documentInfoId: number;
    public documentTypeDropdown: any[] = [];

    async ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        this.documentInfoId = +this.route.snapshot.paramMap.get("id") || 0;
        this.documentTypeDropdown = await this.dropdownService.getDocumentType() || [];
        console.log("this.profileId:", this.profileId, "this.documentInfoId", this.documentInfoId);
        if (this.profileId != 0 && this.documentInfoId != 0) {
            this.getDocument()
        }
    }

    public onSubmit() {
        console.table(this.documentInfoForm);
        this.documentInfoForm.profileId = this.profileId;

        this.documentInfoService.saveDocumentInfo(this.getFromData(this.documentInfoForm)).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/client-profile/document-info/${this.profileId}`]);
                }, 200);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getDocument() {
        this.documentInfoService.getDocumentById(this.profileId, this.documentInfoId).subscribe(
            (success: APIResponse) => {
     
                success.data.issuedDate = this.commonService.getDateToSetForm(success.data.issuedDate);
                success.data.expiryDate = this.commonService.getDateToSetForm(success.data.expiryDate);
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
    public handleFileInput(files: FileList) {
        this.fileToUpload = files.item(0);
    }

    getFromData(model: any) {
        const formData = new FormData();
        formData.append('model', JSON.stringify(model));
        formData.append('doc', this.fileToUpload);
        return formData;
    }

}
