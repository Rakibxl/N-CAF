import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IAuthUser } from '../../../Shared/Entity/Users/auth';
import { AlertService } from '../../../Shared/Modules/alert/alert.service';
import { ClientProfileService } from '../../../Shared/Services/ClientProfile/client-profile.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { DropdownService } from '../../../Shared/Services/Common/dropdown.service';
import { AuthService } from '../../../Shared/Services/Users/auth.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

    changePasswordForm: FormGroup;
    user: IAuthUser;
    profileId: any;
    public gender = [];
    public maritalStatus = [];
    public nationality = [];
    public eyeColor = [];
    public motiveType = [];

    constructor(private fb: FormBuilder, private route: ActivatedRoute, private authService: AuthService,
        private alertService: AlertService, private router: Router, private commonService: CommonService) {
        this.authService.currentUser.subscribe(user => this.user = user);
        this.initForm();
    }

    async ngOnInit() {
       
    }

    initForm() {
        this.changePasswordForm = this.fb.group({
            profileId: [0],
            oldPassword: [null, Validators.required],
            newPassword: [null, Validators.required],
            confirmPassword: [null, Validators.required],
        });
    }

    backBtnClick() {
        this.router.navigate(["/client-profile/client-list"]);
    }


    getModel() {
        let formData = this.changePasswordForm.value;
        formData.profileId = formData.profileId || 0;
        return formData;
    }

    getBoolValue(val) {
        if (val && (val == 'Yes' || val == '1' || val == 1 || val == true)) {
            return true;
        }
        return false;
    }

    save() {
        //let model = this.getModel();
        //this.clientProfileService.createOrUpdateBasicInfo(model).subscribe(res => {
        //    if (res && res.data && res.data.profileId) {
        //        this.alertService.tosterSuccess('Basic Info saved successfully');
        //        this.basicInfoForm.patchValue({ profileId: res.data.profileId });
        //        setTimeout(() => {
        //            this.router.navigate([`/client-profile/client-list`]);
        //        }, 200);
        //    }
        //}, (error: any) => {
        //    console.log(error);
        //    this.alertService.tosterDanger(error);
        //});
    }

}
