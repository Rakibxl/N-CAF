import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from '../../../Shared/Services/Users/user.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { BranchService } from '../../../Shared/Services/Users/branch.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-application-user-form',
  templateUrl: './application-user-form.component.html',
  styleUrls: ['./application-user-form.component.css']
})
export class ApplicationUserFormComponent implements OnInit {
  appUserForm: FormGroup;
  userGuid: any;
  branchList: any[] = [];

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private branchService: BranchService, private router: Router, private userService: UserService, private alertService: AlertService) {
    this.initForm();
    this.userGuid = this.route.snapshot.params.id || "";
  }

  public backBtnClick() {
    this.router.navigate(["/manager/user-info"]);
    return false;
  }

  ngOnInit() {
    this.loadBranchList();
    this.getUser();
  }

  initForm() {
    this.appUserForm = this.fb.group({
      id: [null],
      name: [null, Validators.required],
      surName: [null, Validators.required],
      email: [null, Validators.required],
      phoneNumber: [null, Validators.required],
      password: [null],
      confirmPassword: [null],
      appUserTypeId: [null, Validators.required],
      branchInfoId: [null],
      createdBy: [null],
      modifiedBy: [null]
    });
  }

  loadBranchList() {
    this.branchService.getBranchList().subscribe((res) => {
      this.alertService.fnLoading(false);
      if (res && res.data && res.data.length) {
        this.branchList = res.data;
      }
    }, err => {
      this.alertService.tosterDanger(err);
    });
  }

  getUser() {
    if (this.userGuid && Guid.isGuid(this.userGuid)) {
      this.alertService.fnLoading(true);
      this.userService.getUser(this.userGuid).subscribe((res) => {
        if (res && res.data && res.data.id) {
          this.appUserForm.patchValue(res.data);
          // this.user = res.data as User;
          // console.log(this.user);
          // let role = this.enumUserTypes.filter(a => a.id == this.user.userRoleName)[0];
          // this.user.userRoleDisplayName = (role) ? role.label : "";
        }
      });
    } else {
      this.appUserForm.reset();
    }
  }

  getModel() {
    let formData = this.appUserForm.value;
    formData.id = formData.id || Guid.EMPTY;
    return formData;
  }

  save() {
    let formData = this.appUserForm.value;
    if (!formData.id && formData.password != formData.confirmPassword) {
      this.alertService.tosterDanger('Password not matched!!');
      return;
    }
    formData.id = formData.id || Guid.EMPTY;
    this.userService.createOrUpdateAppUser(formData).subscribe(res => {
      if (res && res.data && res.data.id) {
        this.alertService.tosterSuccess('User saved successfully');
        this.appUserForm.patchValue({ id: res.data.id });
        this.router.navigate(['/manager/user-info']);
      }
    }, (error: any) => {
      console.log(error);
      this.alertService.tosterDanger(error);
    });
  }
}
