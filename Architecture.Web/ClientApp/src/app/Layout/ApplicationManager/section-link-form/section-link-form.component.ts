import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SectionLink } from '../../../Shared/Entity/Users/SectionLink';
import { SectionLinkService } from '../../../Shared/Services/Users/section-link.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { APIResponse } from '../../../Shared/Entity/Response/api-response';
@Component({
  selector: 'app-section-link-form',
  templateUrl: './section-link-form.component.html',
  styleUrls: ['./section-link-form.component.css']
})
export class SectionLinkFormComponent implements OnInit {
    public sectionInfoForm = new SectionLink();

    constructor(private sectionLinkService: SectionLinkService, private alertService: AlertService, private router: Router, private route: ActivatedRoute) { }
    private sectionLinkId: number;
    ngOnInit() {
        this.sectionLinkId = +this.route.snapshot.paramMap.get("id") || 0;
        if (this.sectionLinkId != 0) {
            this.getSection()
        }

    }

    public onSubmit() {
        console.table(this.sectionInfoForm);

        this.sectionLinkService.saveSectionLinkInfo(this.sectionInfoForm).subscribe(
            (success: any) => {
                console.log("success:", success);
                this.alertService.tosterSuccess("Information saved successfully.");
                setTimeout(() => {
                    this.router.navigate([`/manager/section-link`]);
                }, 200);
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public getSection() {
        this.sectionLinkService.getSectionLinkById(this.sectionLinkId).subscribe(
            (success: APIResponse) => {
                this.sectionInfoForm = success.data
            },
            (error: any) => {
                this.alertService.tosterWarning(error.message);
                console.log("error", error);
            });

    }

    public fnBackToList() {
        this.router.navigate([`/manager/section-link`]);
        return false;
    }

}
