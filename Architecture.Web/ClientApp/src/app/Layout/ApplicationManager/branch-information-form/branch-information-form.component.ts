import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { RoleService } from '../../../Shared/Services/Users/role.service';
import { BranchService } from '../../../Shared/Services/Users/branch.service';
import { UserService } from '../../../Shared/Services/Users/user.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { Guid } from 'guid-typescript';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-branch-information-form',
  templateUrl: './branch-information-form.component.html',
  styleUrls: ['./branch-information-form.component.css']
})
export class BranchInformationFormComponent implements OnInit {
  branchForm: FormGroup;
  branchInfoId: number;

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private router: Router, private commonService: CommonService, private userService: UserService, private roleService: RoleService, private branchService: BranchService, private alertService: AlertService) {
    this.initForm();
    let bId: any = this.route.snapshot.paramMap.get('id') || 0;
    this.branchInfoId = parseInt(bId);
  }

  ngOnInit() {
    this.loadBranchInfo();
  }

  backBtnClick() {
    this.router.navigate(["/manager/branch-info"]);
  }

  initForm() {
    this.branchForm = this.fb.group({
      branchInfoId: [null],
      branchLocation: [null, Validators.required],
      address: [null, Validators.required],
      city: [null, Validators.required],
      contactPerson: [null, Validators.required],
      contactNumber: [null, Validators.required],
      agreementStart: [null, Validators.required],
      numberOfUser: [null],
      isLocked: [false],
      note: [null],
      createdBy: [null],
      // created: [null],
      modifiedBy: [null],
      // modified: [null]
    });
  }

  loadBranchInfo() {
    if (!(this.branchInfoId > 0)) {
      this, this.branchForm.reset();
      return;
    }
    this.branchService.getBranchInfo(this.branchInfoId).subscribe(res => {
      if (res && res.data.branchInfoId) {
        res.data.agreementStart = this.commonService.getFormatedDateToSave(res.data.agreementStart);
        this.branchForm.patchValue(res.data);
      }
    }, (error: any) => {
      this.commonService.stopLoading();
      console.log(error)
    });
  }

  getModel() {
    let formData = this.branchForm.value;
    formData.branchInfoId = formData.branchInfoId || 0;
    return formData;
  }

  save() {
    let model = this.getModel();
    this.branchService.createOrUpdate(model).subscribe(res => {
      if (res && res.data) {
        this.alertService.tosterSuccess('Branch saved successfully');
        this.branchForm.patchValue({ id: res.data });
        this.router.navigate(["/manager/branch-info"]);
      }
    }, (err: any) => {
      console.log(err);
      if (err.error && err.error.message) {
        // this.alertService.tosterDanger(err.error.message);
      }
    });
  }
}
