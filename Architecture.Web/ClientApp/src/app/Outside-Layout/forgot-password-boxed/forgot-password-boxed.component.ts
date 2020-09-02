import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { AuthService } from 'src/app/Shared/Services/Users/auth.service';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-forgot-password-boxed',
  templateUrl: './forgot-password-boxed.component.html',
  styles: []
})
export class ForgotPasswordBoxedComponent implements OnInit, OnDestroy {
	// Public properties
	// login: LoginUser;
    forgotPassForm: FormGroup;
    errorMessage: string;
    isLoading: boolean = false;
// 	hasFormErrors: boolean = false;
// 	errors: any[];
// 	// Private properties
	private subscriptions: Subscription[] = [];


	constructor(private activatedRoute: ActivatedRoute,
		private router: Router,
		private forgotPassFB: FormBuilder,
		private alertService: AlertService,
		private authService: AuthService) { }

	ngOnInit() {
    this.initforgotPassword();
	}

 	ngOnDestroy() {
		this.subscriptions.forEach(sb => sb.unsubscribe());
	}

	initforgotPassword() {
		this.createForm();
	}

// 	resetErrors() {
// 		this.hasFormErrors = false;
// 		this.errors = [];
// 	}

	createForm() {
		this.forgotPassForm = this.forgotPassFB.group({
			email: ['', [Validators.required, Validators.email]],
		});
	} 
	
	get ufControls() { return this.forgotPassForm.controls; }

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
		const controls = this.forgotPassForm.controls;
		
		if (this.forgotPassForm.invalid) {
			Object.keys(controls).forEach(controlName =>
				controls[controlName].markAsTouched()
			);

			// this.hasFormErrors = true;
			// this.selectedTab = 0;
			return;
		}

		const forgotPass = this.prepareForgotPassword();
    this.forgotPassword(forgotPass);
	}

	prepareForgotPassword(): string {
		const controls = this.forgotPassForm.controls;
		const forgotPassword = controls['email'].value;
		return forgotPassword;
	}

	forgotPassword(forgotPass: string) {
    this.alertService.fnLoading(true);
    this.isLoading = true;
		const createSubscription = this.authService.forgotPassword(forgotPass)
			.pipe(finalize(() => {this.alertService.fnLoading(false); this.isLoading = false;}))
			.subscribe(res => {
				// this.alertService.tosterSuccess(`New user successfully has been added.`);
				this.goForgotPasswordConfirmation();
			},
			error => {
				this.throwError(error);
			});
		this.subscriptions.push(createSubscription);
	}
	
	goForgotPasswordConfirmation() {
		this.router.navigate([`/auth/forgot-password-confirmation`], { relativeTo: this.activatedRoute });
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
