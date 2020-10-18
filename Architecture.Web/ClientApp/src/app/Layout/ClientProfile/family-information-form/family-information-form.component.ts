import { Component, OnInit } from '@angular/core';
import { ProfFamilyInfo } from '../../../Shared/Entity/ClientProfile/profFamilyInfo';

@Component({
  selector: 'app-family-information-form',
  templateUrl: './family-information-form.component.html',
  styleUrls: ['./family-information-form.component.css']
})
export class FamilyInformationFormComponent implements OnInit {
    public familyInfoForm = new ProfFamilyInfo();
  constructor() { }

  ngOnInit() {
  }

    public onSubmit() {
        console.table(this.familyInfoForm);
    }

    public fnBackToList() {

    }
}
