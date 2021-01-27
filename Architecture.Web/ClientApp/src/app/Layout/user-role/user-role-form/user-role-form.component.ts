import { Component, OnInit, Inject, OnDestroy, Input, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { each, some, find } from 'lodash';
import { Subscription, pipe } from 'rxjs';
import { SaveUserRole, UserRole } from 'src/app/Shared/Entity/Users/role';
import { ISaveRolePermission, RolePermissionsData } from '../shared/user-role-permission-data';
import { RoleService } from 'src/app/Shared/Services/Users/role.service';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-user-role-form',
  templateUrl: './user-role-form.component.html',
  styleUrls: ['./user-role-form.component.css']
})
export class UserRoleFormComponent implements OnInit, OnDestroy, AfterViewInit {
  // Public properties
  userRole: SaveUserRole;
  @Input() userRoleId: any;
  // hasFormErrors: boolean = false;
  // errors: any[];
  // viewLoading: boolean = false;
  // loadingAfterSubmit: boolean = false;
  rolePermissions: ISaveRolePermission[];
  // Private properties
  private subscriptions: Subscription[] = [];

  constructor(
    private rolePermissionsData: RolePermissionsData,
    private alertService: AlertService,
    public activeModal: NgbActiveModal,
    private cdr: ChangeDetectorRef,
    private roleService: RoleService) {
    this.userRole = new UserRole();
    this.userRole.clear();
  }

  ngOnInit() {
    setTimeout(() => {
      this.loadInitData();
      if (this.userRoleId) {
        const roleSubscriptions = this.roleService.getRole(this.userRoleId).subscribe(res => {
          this.userRole = res.data as SaveUserRole;
          this.loadRolePermissions();
        });
        this.subscriptions.push(roleSubscriptions);
      } else {
        this.userRole = new UserRole();
        this.userRole.clear();
      }
    }, 100);
  }

  ngAfterViewInit() {
    this.cdr.detectChanges();
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sb => sb.unsubscribe());
  }

  loadInitData() {
    this.rolePermissions = [];
    this.rolePermissions = this.rolePermissionsData.items;
    this.resetRolePermissions();
  }

  loadRolePermissions() {
    if (!this.rolePermissions || this.rolePermissions.length === 0 || !this.userRole.permissions || this.userRole.permissions.length === 0) {
      return;
    }

    this.rolePermissions.forEach(root => {
      let isRootSelect = true;
      root._children.forEach(child => {
        if (this.userRole.permissions.some(per => per == child.name)) child.isSelected = true;
        if (!child.isSelected) isRootSelect = false;
      });
      root.isSelected = isRootSelect;
    });
  }

  resetRolePermissions() {
    if (!this.rolePermissions || this.rolePermissions.length === 0) {
      return;
    }

    this.rolePermissions.forEach(root => {
      root.isSelected = false;
      root._children.forEach(child => {
        child.isSelected = false;
      });
    });
  }

  preparePermissions(): string[] {
    const result = [];
    each(this.rolePermissions, (_root: ISaveRolePermission) => {
      each(_root._children, (_child: ISaveRolePermission) => {
        if (_child.isSelected) {
          result.push(_child.name);
        }
      });
    });
    return result;
  }

  prepareRole(): SaveUserRole {
    const _role = new SaveUserRole();
    _role.clear();
    _role.id = this.userRole.id;
    _role.name = this.userRole.name;
    _role.permissions = this.preparePermissions();
    _role.isDeleted = this.userRole.isDeleted;
    _role.isActive = this.userRole.isActive;
    return _role;
  }

  onSubmit() {
    // this.resetErrors();
    // this.loadingAfterSubmit = false;
    // this.viewLoading = false;

    if (!this.isRoleNameValid()) {
      // this.hasFormErrors = true;
      // this.errors.push('Oh snap! Invalid role name.');
      return;
    }

    const editedRole = this.prepareRole();
    if (editedRole.id) {
      this.updateRole(editedRole);
    } else {
      this.createRole(editedRole);
    }
  }

  updateRole(_role: SaveUserRole) {
    // this.resetErrors();
    // this.loadingAfterSubmit = true;
    // this.viewLoading = true;
    this.alertService.fnLoading(true);
    const updateSubscription = this.roleService.update(_role)
      .pipe(finalize(() => { this.alertService.fnLoading(false); }))
      .subscribe(() => {
        // this.viewLoading = false;
        // this.dialogRef.close({_role, isEdit: true}); 
        this.activeModal.close(`Role successfully has been saved.`);
        this.alertService.titleTosterSuccess(`Role successfully has been saved.`);
      },
        error => {
          this.throwError(error);
        });
    this.subscriptions.push(updateSubscription);
  }

  createRole(_role: SaveUserRole) {
    // this.resetErrors();
    // this.loadingAfterSubmit = true;
    // this.viewLoading = true;

    this.alertService.fnLoading(true);
    const createSubscription = this.roleService.create(_role)
      .pipe(finalize(() => { this.alertService.fnLoading(false); }))
      .subscribe(res => {
        if (!res) {
          return;
        }

        // this.viewLoading = false;
        // this.dialogRef.close({_role, isEdit: false});
        this.activeModal.close(`Role successfully has been added.`);
        this.alertService.titleTosterSuccess(`Role successfully has been added.`);
      },
        error => {
          this.throwError(error);
        });
    this.subscriptions.push(createSubscription);
  }

  // resetErrors() {
  // 	this.hasFormErrors = false;
  // 	this.errors = [];
  // }

  isSelectedChanged($event, permission: ISaveRolePermission) {
    if ((!permission._children || permission._children.length === 0) && permission.isSelected) {
      const _root = find(this.rolePermissions, (item: ISaveRolePermission) => item.id === permission.parentId);
      // if (_root && !_root.isSelected) {
      //   _root.isSelected = true;
      // }
      if (_root && _root._children && !some(_root._children, (item: ISaveRolePermission) => !item.isSelected)) {
        _root.isSelected = true;
      }
      else {
        _root.isSelected = false;
      }
      return;
    }

    if ((!permission._children || permission._children.length === 0) && !permission.isSelected) {
      const _root = find(this.rolePermissions, (item: ISaveRolePermission) => item.id === permission.parentId);
      // if (_root && _root.isSelected) {
      //   if (!some(_root._children, (item: ISaveRolePermission) => item.isSelected === true)) {
      //     _root.isSelected = false;
      //   }
      // }
      if (_root) _root.isSelected = false;
      return;
    }

    if (permission._children.length > 0 && permission.isSelected) {
      each(permission._children, (item: ISaveRolePermission) => item.isSelected = true);
      return;
    }

    if (permission._children.length > 0 && !permission.isSelected) {
      each(permission._children, (item: ISaveRolePermission) => {
        item.isSelected = false;
      });
      return;
    }
  }

  getRoleName(): string {
    if (this.userRole && this.userRole.id) {
      return `Edit role '${this.userRole.name}'`;
    }
    return 'New role';
  }

  isRoleNameValid(): boolean {
    return (this.userRole && this.userRole.name.trim() && this.userRole.name.trim().length > 0);
  }

  // onAlertClose($event) {
  // 	this.resetErrors();
  // }

  private throwError(errorDetails: any) {
    // this.alertService.fnLoading(false);
    console.log("error", errorDetails);
    let errList = errorDetails.error.errors;
    if (errList.length) {
      console.log("error", errList, errList[0].errorList[0]);
      // this.alertService.tosterDanger(errList[0].errorList[0]);
    } else {
      // this.alertService.tosterDanger(errorDetails.error.message);
    }
  }
}
