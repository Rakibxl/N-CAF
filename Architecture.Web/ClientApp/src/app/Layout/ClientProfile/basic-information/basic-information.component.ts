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

  constructor(private fb: FormBuilder, private clientProfileService: ClientProfileService, private alertService: AlertService, private router: Router) {
    this.initForm();
  }

  ngOnInit() {

  }

  initForm() {
    this.basicInfoForm = this.fb.group({
      profileId: [0],
      name: ['', Validators.required],
      surName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      taxCode: ['', Validators.required],
      taxCodeStartDate: [''],
      taxCodeEndDate: [''],
      phoneNumber: ['', Validators.required],
      genderId: [''],
      maritalStatusId: [''],
      email: ['', Validators.required],
      postalElectronicCertificate: [''],
      cityOfBirth: [''],
      stateOfBirth: [''],
      birthStateCode: [''],
      nationalityId: [''],
      citizenStateCode: [''],
      eyesColorId: [''],
      height: [''],
      zipCode: [''],
      motiveTypeId: [''],
      cityOfResidence: [''],
      stateOfResidence: [''],
      occupationTypeId: [''],
      occupationPositionId: [''],
      hasUnEmployedCertificate: [''],
      unEmployedCertificateIssuesDate: [''],
      hasAnyUnEmployedFacility: [''],
      contractTypeId: [''],
      yearlyIncome: [''],

      isRentHouse: [''],
      howManyHouseRent: [''],
      isHouseOwner: [''],
      houseCountryName: [''],
      houseCityName: [''],
      hasVehicle: [''],
      carSerialNumber: [''],
      carNumberPlate: [''],
      hasVehicleInsurance: [''],
      isCompanyOwner: [''],
      hasWorker: [''],
      digitalVatCode: [''],
      hasAppliedForCitizenship: [''],
      requestTypeOfApplicant: [''],
      applicationFor: [''],
      branchId: ['']
    });
  }

  save() {
    let formData = this.basicInfoForm.value;
    formData.profileId = formData.profileId ? formData.profileId : 1;
    formData.genderId = formData.genderId ? parseInt(formData.genderId) : null;
    formData.maritalStatusId = formData.maritalStatusId ? parseInt(formData.maritalStatusId) : null;
    formData.taxCodeStartDate = formData.taxCodeStartDate ? formData.UnEmployedCertificateIssuesDate : null;
    formData.nationalityId = formData.nationalityId ? parseInt(formData.nationalityId) : null;
    formData.motiveTypeId = formData.motiveTypeId ? parseInt(formData.motiveTypeId) : null;
    formData.occupationTypeId = formData.occupationTypeId ? parseInt(formData.occupationTypeId) : null;
    formData.occupationPositionId = formData.occupationPositionId ? parseInt(formData.occupationPositionId) : null;
    formData.unEmployedCertificateIssuesDate = formData.unEmployedCertificateIssuesDate ? formData.unEmployedCertificateIssuesDate : null;
    formData.contractTypeId = formData.contractTypeId ? parseInt(formData.contractTypeId) : null;
    formData.howManyHouseRent = formData.howManyHouseRent ? parseInt(formData.howManyHouseRent) : null;
    formData.branchId = formData.branchId ? parseInt(formData.branchId) : null;
    formData.height = formData.height ? parseFloat(formData.height) : 0;
    formData.hasUnEmployedCertificate = formData.hasUnEmployedCertificate > 1 ? true : false;
    formData.hasAnyUnEmployedFacility = formData.hasAnyUnEmployedFacility > 1 ? true : false;
    formData.taxCodeEndDate = formData.taxCodeEndDate ? parseInt(formData.taxCodeEndDate) : null;
    formData.yearlyIncome = formData.yearlyIncome ? parseFloat(formData.yearlyIncome) : 0;
    formData.isRentHouse = formData.isRentHouse > 1 ? true : false;
    formData.isHouseOwner = formData.isHouseOwner > 1 ? true : false;
    formData.hasVehicle = formData.hasVehicle > 1 ? true : false;
    formData.hasVehicleInsurance = formData.hasVehicleInsurance > 1 ? true : false;
    formData.isCompanyOwner = formData.isCompanyOwner > 1 ? true : false;
    formData.hasWorker = formData.hasWorker > 1 ? true : false;
    formData.hasAppliedForCitizenship = formData.hasAppliedForCitizenship > 1 ? true : false;

    this.clientProfileService.saveBasicInfo(formData).subscribe(res => {
      console.log(res)
    });
  }
}
