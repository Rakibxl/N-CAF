import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { ClientProfileService } from '../../../Shared/Services/ClientProfile/client-profile.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { AuthService } from '../../../Shared/Services/Users/auth.service';
import { IAuthUser } from '../../../Shared/Entity/Users/auth';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';


@Component({
  selector: 'app-basic-information',
  templateUrl: './basic-information.component.html',
  styleUrls: ['./basic-information.component.css']
})
export class BasicInformationComponent implements OnInit {
  basicInfoForm: FormGroup;
  user: IAuthUser;
    profileId: any;
    public gender = [];

    constructor(private fb: FormBuilder, private route: ActivatedRoute, private clientProfileService: ClientProfileService, private authService: AuthService,
        private alertService: AlertService, private router: Router, private commonService: CommonService, private dropdownService :DropdownService) {
    this.authService.currentUser.subscribe(user => this.user = user);
    this.initForm();
    this.profileId = this.route.snapshot.paramMap.get('profId') || 0;
    this.profileId = parseInt(this.profileId);
    this.clientProfileService.profileId = this.profileId;
    //this.profileId = this.route.snapshot.queryParamMap.get("profId") || 0;
  }

  async ngOnInit() {
      this.loadBasicInfo();      
      this.gender = await this.dropdownService.getGender() || [];
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
      hasUnEmployedCertificate: [false, Validators.required],
      unEmployedCertificateIssuesDate: [null],
      hasAnyUnEmployedFacility: [null],
      contractTypeId: [null],
      yearlyIncome: [null, Validators.required],
      isRentHouse: [false, Validators.required],
      howManyHouseRent: [null],
      isHouseOwner: [false, Validators.required],
      houseCountryName: [null],
      houseCityName: [null],
      hasVehicle: [false, Validators.required],
      carSerialNumber: [null],
      carNumberPlate: [null],
      hasVehicleInsurance: [null],
      isCompanyOwner: [false, Validators.required],
      hasWorker: [null],
      digitalVatCode: [null],
      hasAppliedForCitizenship: [false, Validators.required],
      requestTypeOfApplicant: [null],
      isPregnant: [false, Validators.required],
      expectedBabyBirthDate: [null],
      applicationFor: [null],
      branchId: [null],
      refId: [null],
      createdBy: [null],
      // created: [null],
      modifiedBy: [null],
      // modified: [null]
    });
  }

  backBtnClick() {
    this.router.navigate(["/client-profile/client-list"]);
  }

  loadBasicInfo() {
    if (!(this.profileId > 0)) {
      return;
    }
    this.clientProfileService.getBasicInfo(this.profileId).subscribe(res => {
      if (res && res.data.profileId) {
        res.data.dateOfBirth = this.commonService.getFormatedDateToSave(res.data.dateOfBirth);
        res.data.taxCodeStartDate = this.commonService.getFormatedDateToSave(res.data.taxCodeStartDate);
        res.data.taxCodeEndDate = this.commonService.getFormatedDateToSave(res.data.taxCodeEndDate);
        res.data.expectedBabyBirthDate = this.commonService.getFormatedDateToSave(res.data.expectedBabyBirthDate);
        res.data.unEmployedCertificateIssuesDate = this.commonService.getFormatedDateToSave(res.data.unEmployedCertificateIssuesDate);
        this.basicInfoForm.patchValue(res.data);
      }
    }, (error: any) => {
      this.commonService.stopLoading();
      console.log(error)
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
    formData.isPregnant = this.getBoolValue(formData.isPregnant);
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
      if (res && res.data && res.data.profileId) {
        this.alertService.tosterSuccess('Basic Info saved successfully');
        this.basicInfoForm.patchValue({ profileId: res.data.profileId });
        setTimeout(() => {
          this.router.navigate([`/client-profile/client-list`]);
        }, 200);
      }
    }, (error: any) => {
      console.log(error);
      this.alertService.tosterDanger(error);
    });
  }
}