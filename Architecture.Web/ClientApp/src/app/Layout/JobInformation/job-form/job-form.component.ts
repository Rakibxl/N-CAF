import { Component, OnInit } from '@angular/core';
import { NgSelectModule, NgOption } from '@ng-select/ng-select';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';
@Component({
  selector: 'app-job-form',
  templateUrl: './job-form.component.html',
  styleUrls: ['./job-form.component.css']
})
export class JobFormComponent implements OnInit {

    constructor(private dropdownService: DropdownService) { }
    public sectionName = [];
    async ngOnInit() {
        this.sectionName = await this.dropdownService.getSectionName();
        console.log("this.sectionName", this.sectionName);
    }

    selectedSectionIds: string[];

    public onSubmit() {

    }

}
