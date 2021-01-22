import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { RoleService } from '../../../Shared/Services/Users/role.service';
import { UserRoleService } from '../../../Shared/Services/Users/user-role.service';
import { UserService } from '../../../Shared/Services/Users/user.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-application-user-role-mapping-form',
  templateUrl: './application-user-role-mapping-form.component.html',
  styleUrls: ['./application-user-role-mapping-form.component.css']
})
export class ApplicationUserRoleMappingFormComponent implements OnInit {
  roleMappingForm: FormGroup;
  roleMappingId: Guid;
  userList: any[] = [];
  roleList: any[] = [];

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private router: Router, private userService: UserService, private roleService: RoleService, private userRoleService: UserRoleService, private alertService: AlertService) {
    this.initForm();
    this.roleMappingId = this.route.snapshot.params.id || "";
  }

  ngOnInit() {
    this.getUsers();
    this.getRoles();
    // this.getRole();
  }

  backBtnClick() {
    this.router.navigate(["/manager/user-role-mapping"]);
  }

  initForm() {
    this.roleMappingForm = this.fb.group({
      // id: [null],
      userId: [null, Validators.required],
      role: [null, Validators.required],
      // status: [null, Validators.required]
    });
  }

  getUsers() {
    this.userService.getUsers().subscribe((res) => {
      this.alertService.fnLoading(false);
      if (res && res.data && res.data.items.length) {
        this.userList = res.data.items; //.filter(ex => ex.branchInfoId);

        this.userList.map(ex => {
          ex.name = ex.surName ? (ex.name + ' ' + ex.surName) : ex.name;
          return ex;
        });
      }
    }, err => {
      this.alertService.tosterDanger(err);
    });
  }

  getRoles() {
    this.roleService.getRoles().subscribe((res) => {
      this.alertService.fnLoading(false);
      if (res && res.data && res.data.items.length) {
        this.roleList = res.data.items;
      }
    }, err => {
      this.alertService.tosterDanger(err);
    });
  }

  // getRole() {
  //   if (this.roleMappingId && Guid.isGuid(this.roleMappingId)) {
  //     this.alertService.fnLoading(true);
  //     this.roleService.getRole(this.roleMappingId).subscribe((res) => {
  //       if (res && res.data && res.data.id) {
  //         this.roleMappingForm.patchValue(res.data);
  //       }
  //     });
  //   } else {
  //     this.roleMappingForm.reset();
  //   }
  // }

  getModel() {
    let formData = this.roleMappingForm.value;
    formData.userId = formData.userId;
    return formData;
  }

  save() {
    let model = this.getModel();
    this.userRoleService.createUserRole(model).subscribe(res => {
      if (res && res.data) {
        this.alertService.tosterSuccess('User role saved successfully');
        this.roleMappingForm.patchValue({ id: res.data });
      }
    }, (err: any) => {
      console.log(err);
      if (err.error && err.error.message) {
        this.alertService.tosterDanger(err.error.message);
      }
    });
  }
}