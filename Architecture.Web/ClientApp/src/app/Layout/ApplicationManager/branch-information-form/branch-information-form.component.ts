import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { RoleService } from '../../../Shared/Services/Users/role.service';
import { BranchService } from '../../../Shared/Services/Users/branch.service';
import { UserService } from '../../../Shared/Services/Users/user.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-branch-information-form',
  templateUrl: './branch-information-form.component.html',
  styleUrls: ['./branch-information-form.component.css']
})
export class BranchInformationFormComponent implements OnInit {
  branchForm: FormGroup;

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private router: Router, private userService: UserService, private roleService: RoleService, private branchService: BranchService, private alertService: AlertService) {
    this.initForm();
  }

  ngOnInit() {
  }

  backBtnClick() {
    this.router.navigate(["/manager/branch-info"]);
  }

  initForm() {
    this.branchForm = this.fb.group({
      branchId: [null],
      branchLocation: [null, Validators.required],
      address: [null, Validators.required],
      city: [null, Validators.required],
      contactPerson: [null, Validators.required],
      contactNumber: [null, Validators.required],
      agreementStart: [null, Validators.required],
      numberOfUser: [null],
      isLocked: [null],
      note: [null]
    });
  }

  getModel() {
    let formData = this.branchForm.value;
    formData.branchId = formData.branchId || 0;
    return formData;
  }

  save() {
    let model = this.getModel();
    this.branchService.createOrUpdate(model).subscribe(res => {
      if (res && res.data) {
        this.alertService.tosterSuccess('Branch saved successfully');
        this.branchForm.patchValue({ id: res.data });
      }
    }, (err: any) => {
      console.log(err);
      if (err.error && err.error.message) {
        this.alertService.tosterDanger(err.error.message);
      }
    });
  }
}
