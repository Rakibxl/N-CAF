import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { ClientProfileService } from '../../../Shared/Services/ClientProfile/client-profile.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';


@Component({
  selector: 'app-basic-information',
  templateUrl: './basic-information.component.html',
  styleUrls: ['./basic-information.component.css']
})
export class BasicInformationComponent implements OnInit {
  basicInfoForm: FormGroup;

  // defaultBindingsList = [
  //   { value: "1", label: "type here" },
  //   { value: "Celibe/Nubile - Unmarried Maiden", label: "Celibe/Nubile - Unmarried Maiden" },
  //   { value: "Coniugato/a - Married To", label: "Coniugato/a - Married To" },
  //   { value: "unito/a civilmente - joined civilly", label: "unito/a civilmente - joined civilly" },
  //   { value: "separata legalmente - legally separated", label: "separata legalmente - legally separated" },
  //   { value: "sciolto/a legalmente - legally dissolved", label: "sciolto/a legalmente - legally dissolved" },
  //   { value: "sciolto/a da unione civile-dissolved from civil union - civil union", label: "sciolto/a da unione civile-dissolved from civil union - civil union" },
  //   { value: "divorziato/a - divorced to", label: "divorziato/a - divorced to" },
  //   { value: "vedovo/a - widower", label: "vedovo/a - widower" },
  //   { value: "abbandonato/a - abandoned", label: "abbandonato/a - abandoned" },
  //   { value: "parte superstite dell'unione civile- surviving part of the civil union", label: "parte superstite dell'unione civile- surviving part of the civil union" },
  // ];
  // selectedCity = { value: "1", label: "type here" };

  constructor(private fb: FormBuilder, private clientProfileService: ClientProfileService,
    private alertService: AlertService, private router: Router, private commonService: CommonService) {
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
      selectedCity: [null],
      email: [null, Validators.required],
      postalElectronicCertificate: [null],
      cityOfBirth: [null],
      stateOfBirth: [null],
      birthStateCode: [null],
      nationalityId: [null],
      citizenStateCode: [null],
      eyeColorId: [null],
      height: [null, Validators.required],
      zipCode: [null],
      motiveTypeId: [null],
      cityOfResidence: [null],
      stateOfResidence: [null],
      occupationTypeId: [null],
      occupationPositionId: [null],
      hasUnEmployedCertificate: [null, Validators.required],
      unEmployedCertificateIssuesDate: [null],
      hasAnyUnEmployedFacility: [null, Validators.required],
      contractTypeId: [null],
      yearlyIncome: [null, Validators.required],
      isRentHouse: [null, Validators.required],
      howManyHouseRent: [null],
      isHouseOwner: [null, Validators.required],
      houseCountryName: [null],
      houseCityName: [null],
      hasVehicle: [null, Validators.required],
      carSerialNumber: [null],
      carNumberPlate: [null],
      hasVehicleInsurance: [null, Validators.required],
      isCompanyOwner: [null, Validators.required],
      hasWorker: [null, Validators.required],
      digitalVatCode: [null],
      hasAppliedForCitizenship: [null, Validators.required],
      requestTypeOfApplicant: [null],
      applicationFor: [null],
      branchId: [null]
    });
  }

  getModel() {
    let formData = this.basicInfoForm.value;
    formData.profileId = formData.profileId || 0;
    formData.hasAnyUnEmployedFacility = this.getBoolValue(formData.hasAnyUnEmployedFacility);
    formData.hasUnEmployedCertificate = this.getBoolValue(formData.hasUnEmployedCertificate);
    formData.hasAppliedForCitizenship = this.getBoolValue(formData.hasAppliedForCitizenship);
    formData.hasVehicle = this.getBoolValue(formData.hasVehicle);
    formData.hasVehicleInsurance = this.getBoolValue(formData.hasVehicleInsurance);
    formData.hasWorker = this.getBoolValue(formData.hasWorker);
    formData.isCompanyOwner = this.getBoolValue(formData.isCompanyOwner);
    formData.isHouseOwner = this.getBoolValue(formData.isHouseOwner);
    formData.isRentHouse = this.getBoolValue(formData.isRentHouse);
    return formData;
  }

  getBoolValue(val) {
    if (val && (val == 'Yes' || val == '1' || val == 1 || val == true)) {
      return true;
    }
    return false;
  }

  save() {
    let model = this.getModel();     
    this.clientProfileService.createOrUpdateBasicInfo(model).subscribe(res => {
      console.log(res)
    }, (error: any) => {
      this.commonService.stopLoading();
      console.log(error)
    });
  }
}