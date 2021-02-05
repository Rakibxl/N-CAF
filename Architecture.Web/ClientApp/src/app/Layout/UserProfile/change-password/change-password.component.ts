import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
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
            userId: [null],
            oldPassword: [null, Validators.required],
            newPassword: [null, Validators.required],
            confirmPassword: [null, Validators.required],
            token: [null]

        }, { validator: this.passwordConfirming });
    }

    backBtnClick() {
        this.router.navigate(["/client-profile/client-list"]);
        return false;
    }


    getModel() {
        let formData = this.changePasswordForm.value;
        formData.userId = this.user.id;
        return formData;
    }
    passwordConfirming(c: AbstractControl): { invalid: boolean } {
        if (c.get('newPassword').value !== c.get('confirmPassword').value) {
            return { invalid: true };
        }
    }
    getBoolValue(val) {
        if (val && (val == 'Yes' || val == '1' || val == 1 || val == true)) {
            return true;
        }
        return false;
    }

    save() {
        let model = this.getModel();
        this.authService.changePassword(model).subscribe(res => {
            this.authService.logout();
            this.router.navigate(['/auth/login']);
        }, (error: any) => {
            console.log(error);
            this.alertService.tosterDanger(error);
        });
    }

}
