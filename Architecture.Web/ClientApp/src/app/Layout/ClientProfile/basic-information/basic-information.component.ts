import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { ClientProfileService } from '../../../Shared/Services/ClientProfile/client-profile.service';


@Component({
  selector: 'app-basic-information',
  templateUrl: './basic-information.component.html',
  styleUrls: ['./basic-information.component.css']
})
export class BasicInformationComponent implements OnInit {
  basicInfoForm: FormGroup;

  constructor(private fb: FormBuilder, private clientProfileService: ClientProfileService,
    private alertService: AlertService, private router: Router) {
    this.initForm();
  }

  ngOnInit() {

  }

  initForm() {
    this.basicInfoForm = this.fb.group({
      profileId: [0],
      name: [null, Validators.required],
      surName: [null, Validators.required],
      dateOfBirth: [null, Validators.required],
      taxCode: [null, Validators.required],
      taxCodeStartDate: [null],
      taxCodeEndDate: [null],
      phoneNumber: [null, Validators.required],
      genderId: [null],
      maritalStatusId: [null],
      email: [null, Validators.required],
      postalElectronicCertificate: [null],
      cityOfBirth: [null],
      stateOfBirth: [null],
      birthStateCode: [null],
      nationalityId: [null],
      citizenStateCode: [null],
      eyesColorId: [null],
      height: [null],
      zipCode: [null],
      motiveTypeId: [null],
      cityOfResidence: [null],
      stateOfResidence: [null],
      occupationTypeId: [null],
      occupationPositionId: [null],
      hasUnEmployedCertificate: [null],
      unEmployedCertificateIssuesDate: [null],
      hasAnyUnEmployedFacility: [null],
      contractTypeId: [null],
      yearlyIncome: [null],
      isRentHouse: [null],
      howManyHouseRent: [null],
      isHouseOwner: [null],
      houseCountryName: [null],
      houseCityName: [null],
      hasVehicle: [null],
      carSerialNumber: [null],
      carNumberPlate: [null],
      hasVehicleInsurance: [null],
      isCompanyOwner: [null],
      hasWorker: [null],
      digitalVatCode: [null],
      hasAppliedForCitizenship: [null],
      requestTypeOfApplicant: [null],
      applicationFor: [null],
      branchId: [null]
    });
  }

  save() {
    let formData = this.basicInfoForm.value;

    this.clientProfileService.saveBasicInfo(formData).subscribe(res => {
      console.log(res)
    });
  }
}
