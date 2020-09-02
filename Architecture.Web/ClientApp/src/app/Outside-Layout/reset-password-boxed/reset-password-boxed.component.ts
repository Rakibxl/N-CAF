import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { AuthService } from 'src/app/Shared/Services/Users/auth.service';
import { finalize } from 'rxjs/operators';
import { MustMatch } from 'src/app/Shared/Directive/must-match.validator';
import { ResetPassword } from 'src/app/Shared/Entity/Users/auth';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-reset-password-boxed',
  templateUrl: './reset-password-boxed.component.html',
  styles: []
})
export class ResetPasswordBoxedComponent implements OnInit, OnDestroy {
	// Public properties
	// resetPass: ResetPassword;
    resetPassForm: FormGroup;
    errorMessage: string;
	isLoading: boolean = false;
	confirmPasswordTextType: boolean = false;
	newPasswordTextType: boolean = false;
	paramUserId: string;
	paramToken: string;
// 	hasFormErrors: boolean = false;
// 	errors: any[];
// 	// Private properties
	private subscriptions: Subscription[] = [];


	constructor(private activatedRoute: ActivatedRoute,
		private router: Router,
		private resetPassFB: FormBuilder,
		private alertService: AlertService,
		private authService: AuthService) { }

	ngOnInit() {
		this.alertService.fnLoading(true);
		const routeSubscription = this.activatedRoute.queryParams.subscribe(params => {
			const userId = params['userId'];
			const token = params['token'];
			if (userId && Guid.isGuid(userId)) {
				this.paramUserId = userId;
				this.paramToken = token;
			}
		});
		this.subscriptions.push(routeSubscription);
    	this.initresetPassword();
	}

 	ngOnDestroy() {
		this.subscriptions.forEach(sb => sb.unsubscribe());
	}

	initresetPassword() {
		this.createForm();
	}

// 	resetErrors() {
// 		this.hasFormErrors = false;
// 		this.errors = [];
// 	}

	createForm() {
		this.resetPassForm = this.resetPassFB.group({
			newPassword: ['', [Validators.required]],
			confirmPassword: ['', [Validators.required]],
		},
		{
			validator: MustMatch('newPassword', 'confirmPassword')
		});
	} 
	
	get ufControls() { return this.resetPassForm.controls; }

// 	resetAll() {
// 		this.user = Object.assign({}, this.oldUser);
// 		this.createForm();
// 		this.resetErrors();
// 		this.userForm.markAsPristine();
// 		this.userForm.markAsUntouched();
// 		this.userForm.updateValueAndValidity();
// 	}

	onSubmit() {
		// this.resetErrors();
		const controls = this.resetPassForm.controls;
		
		if (this.resetPassForm.invalid) {
			Object.keys(controls).forEach(controlName =>
				controls[controlName].markAsTouched()
			);

			// this.hasFormErrors = true;
			// this.selectedTab = 0;
			return;
		}

		const resetPass = this.prepareResetPassword();
    	this.resetPassword(resetPass);
	}

	prepareResetPassword(): ResetPassword {
		const controls = this.resetPassForm.controls;
		const _resetPassword = new ResetPassword();
		_resetPassword.clear();
		
		_resetPassword.userId = this.paramUserId;
		_resetPassword.token = this.paramToken;
		_resetPassword.newPassword = controls['newPassword'].value;
		
		return _resetPassword;
	}

	resetPassword(resetPass: ResetPassword) {
    this.alertService.fnLoading(true);
    this.isLoading = true;
		const createSubscription = this.authService.resetPassword(resetPass)
			.pipe(finalize(() => {this.alertService.fnLoading(false); this.isLoading = false;}))
			.subscribe(res => {
				// this.alertService.tosterSuccess(`New user successfully has been added.`);
				this.goResetPasswordConfirmation();
			},
			error => {
				this.throwError(error);
			});
		this.subscriptions.push(createSubscription);
	}
	
	goResetPasswordConfirmation() {
		this.router.navigate([`/auth/reset-password-confirmation`], { relativeTo: this.activatedRoute });
	}
    
    toggleNewPasswordTextType(){
        this.newPasswordTextType = !this.newPasswordTextType;
    }
    
    toggleConfirmPasswordTextType(){
        this.confirmPasswordTextType = !this.confirmPasswordTextType;
    }

// 	onAlertClose($event) {
// 		this.resetErrors();
// 	}

    private throwError(errorDetails: any) {
        // this.alertService.fnLoading(false);
        console.log("error", errorDetails);
        let errList = errorDetails.error.errors;
        if (errList.length) {
            console.log("error", errList, errList[0].errorList[0]);
            // this.alertService.tosterDanger(errList[0].errorList[0]);
            this.errorMessage = errList[0].errorList[0];
        } else {
            // this.alertService.tosterDanger(errorDetails.error.message);
            this.errorMessage = errorDetails.error.message;
        }
    }
}
