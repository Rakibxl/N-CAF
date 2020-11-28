import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { RoleService } from '../../../Shared/Services/Users/role.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-application-user-role-form',
  templateUrl: './application-user-role-form.component.html',
  styleUrls: ['./application-user-role-form.component.css']
})
export class ApplicationUserRoleFormComponent implements OnInit {
  roleForm: FormGroup;
  roleId: Guid;

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private router: Router, private roleService: RoleService, private alertService: AlertService) {
    this.initForm();
    this.roleId = this.route.snapshot.params.id || "";
  }

  ngOnInit() {
    this.getRole();
  }

  backBtnClick() {
    this.router.navigate(["/manager/user-role"]);
  }

  initForm() {
    this.roleForm = this.fb.group({
      id: [null],
      name: [null, Validators.required],
      status: [null, Validators.required]
    });
  }

  getRole() {
    if (this.roleId && Guid.isGuid(this.roleId)) {
      this.alertService.fnLoading(true);
      this.roleService.getRole(this.roleId).subscribe((res) => {
        if (res && res.data && res.data.id) {
          this.roleForm.patchValue(res.data);
        }
      });
    } else {
      this.roleForm.reset();
    }
  }

  getModel() {
    let formData = this.roleForm.value;
    formData.id = formData.id || Guid.EMPTY;
    return formData;
  }

  save() {
    let model = this.getModel();
    this.roleService.createOrUpdateRole(model).subscribe(res => {
      if (res && res.data) {
        this.alertService.tosterSuccess('Role saved successfully');
        this.roleForm.patchValue({ id: res.data });
      }
    }, (error: any) => {
      console.log(error);
      this.alertService.tosterDanger(error);
    });
  }
}
