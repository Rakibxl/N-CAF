import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { UserService } from '../../../Shared/Services/Users/user.service';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { BranchService } from '../../../Shared/Services/Users/branch.service';
import { Guid } from 'guid-typescript';
import { DropdownService } from 'src/app/Shared/Services/Common/dropdown.service';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { NewKeywordComponent } from './new-keyword/new-keyword.component';

@Component({
  selector: 'app-application-user-form',
  templateUrl: './application-user-form.component.html',
  styleUrls: ['./application-user-form.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ApplicationUserFormComponent implements OnInit {
  appUserForm: FormGroup;
  userGuid: any;
  branchList: any[] = [];
  keywords: any[] = [];

  constructor(private fb: FormBuilder, private route: ActivatedRoute, private branchService: BranchService, private router: Router,
    private userService: UserService, private alertService: AlertService, private dropdownService: DropdownService,
    private modalService: NgbModal) {
    this.initForm();
    this.userGuid = this.route.snapshot.params.id || "";
  }

  public backBtnClick() {
    this.router.navigate(["/manager/user-info"]);
    return false;
  }

  async ngOnInit() {
    this.loadBranchList();
    this.getUser();

    this.keywords = await this.dropdownService.getOperatorKeyword() || [];
    console.log(this.keywords)
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
      operatorBranches: [null],
      operatorKeywordIds: [null],
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
          if (res.data.operatorKeywordIds && res.data.operatorKeywordIds.length > 2) {
            res.data.operatorKeywordIds = JSON.parse(res.data.operatorKeywordIds);

            setTimeout(() => {
              res.data.operatorKeywordIds.forEach(ex => {
                let key = this.keywords.filter(dd => dd.operatorKeywordName == ex);
                if (key.length == 0) {
                  this.keywords.push({ operatorKeywordName: ex });
                }
              });
              this.appUserForm.patchValue(res.data);
              this.keywords = [...this.keywords];
            }, 500);
          } else {
            this.appUserForm.patchValue(res.data);
          }
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

  createNew(id?) {
    let ngbModalOptions: NgbModalOptions = {
      backdrop: "static",
      keyboard: false,
      size: "lg",
    };
    const modalRef = this.modalService.open(
      NewKeywordComponent,
      ngbModalOptions
    );
    modalRef.componentInstance.operatorKeywords = this.keywords;

    modalRef.result.then(
      (result) => {
        console.log(result);
        if (!(result == 'Close click' || result == 'Cross click')) {
          // let maxId = Math.max(...this.keywords.map(o => o.operatorKeywordId), 0);
          // result.operatorKeywordId = ++maxId;
          this.keywords.push(result);
          this.keywords = [...this.keywords];
          let formData = this.appUserForm.value;
          formData.operatorKeywordIds.push(result.operatorKeywordName);
          this.appUserForm.patchValue({ operatorKeywordIds: formData.operatorKeywordIds });
        }
      },
      (reason) => {
        console.log(reason);
      });
  }

  save() {
    let formData = this.appUserForm.value;
    if (!formData.id && formData.password != formData.confirmPassword) {
      this.alertService.tosterDanger('Password not matched!!');
      return;
    }
    formData.id = formData.id || Guid.EMPTY;
    formData.branchInfoId = formData.appUserTypeId == 2 ? formData.branchInfoId : null;
    let keywords = [];
    if (formData.operatorKeywordIds) {
      this.keywords.forEach(ex => {
        if (formData.operatorKeywordIds.indexOf(ex.operatorKeywordName) >= 0) {
          keywords.push(ex.operatorKeywordName);
        }
      });
    }
    formData.operatorKeywordIds = JSON.stringify(keywords) || '';
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
