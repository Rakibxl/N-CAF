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


  defaultBindingsList = [
    { value: "1", label: "type here" },
    { value: "Celibe/Nubile - Unmarried Maiden", label: "Celibe/Nubile - Unmarried Maiden" },
    { value: "Coniugato/a - Married To", label: "Coniugato/a - Married To" },
    { value: "unito/a civilmente - joined civilly", label: "unito/a civilmente - joined civilly" },
    { value: "separata legalmente - legally separated", label: "separata legalmente - legally separated" },
    { value: "sciolto/a legalmente - legally dissolved", label: "sciolto/a legalmente - legally dissolved" },
    { value: "sciolto/a da unione civile-dissolved from civil union - civil union", label: "sciolto/a da unione civile-dissolved from civil union - civil union" },
    { value: "divorziato/a - divorced to", label: "divorziato/a - divorced to" },
    { value: "vedovo/a - widower", label: "vedovo/a - widower" },
    { value: "abbandonato/a - abandoned", label: "abbandonato/a - abandoned" },
    { value: "parte superstite dell'unione civile- surviving part of the civil union", label: "parte superstite dell'unione civile- surviving part of the civil union" },
  ];

  selectedCity = { value: "1", label: "type here" };


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
