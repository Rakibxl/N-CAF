import { Component, OnInit, OnDestroy } from '@angular/core';
import { SaveUser, User } from 'src/app/Shared/Entity/Users/user';
import { KeyValuePair } from 'src/app/Shared/Entity/Common/key-value-pair';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { RoleService } from 'src/app/Shared/Services/Users/role.service';
import { UserService } from 'src/app/Shared/Services/Users/user.service';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { finalize } from 'rxjs/operators';
import { Guid } from 'guid-typescript';

@Component({
	selector: 'app-user-form',
	templateUrl: './user-form.component.html',
	styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit, OnDestroy {
	// Public properties
	user: User;
	userForm: FormGroup;
// 	hasFormErrors: boolean = false;
// 	errors: any[];
	userRoles: KeyValuePair[];
	divisions: KeyValuePair[];
// 	// Private properties
	private subscriptions: Subscription[] = [];


	constructor(private activatedRoute: ActivatedRoute,
		private router: Router,
		private userFB: FormBuilder,
		private roleService: RoleService,
		private alertService: AlertService,
		private userService: UserService) { }

	ngOnInit() {
		this.loadUserRoles();
		
		this.alertService.fnLoading(true);
		const routeSubscription = this.activatedRoute.params.subscribe(params => {
			const id = params['id'];
			if (id && Guid.isGuid(id)) {

				this.alertService.fnLoading(true);
				this.userService.getUser(id)
					.pipe(finalize(() => this.alertService.fnLoading(false)))
					.subscribe(res => {
						if (res) {
							this.user = res.data as User;
							// this.oldUser = Object.assign({}, this.user);
							this.initUser();
						}
					});
			} else {
				this.user = new User();
				this.user.clear();
				// this.oldUser = Object.assign({}, this.user);
				this.initUser();
			}
		});
		this.subscriptions.push(routeSubscription);
	}

 	ngOnDestroy() {
		this.subscriptions.forEach(sb => sb.unsubscribe());
	}

	initUser() {
		this.createForm();
	}

// 	resetErrors() {
// 		this.hasFormErrors = false;
// 		this.errors = [];
// 	}

	loadUserRoles() {
		this.alertService.fnLoading(true);
		const roleSubscription = this.roleService.getRoleSelect()
			.pipe(finalize(() => this.alertService.fnLoading(false)))
			.subscribe(res => {
				this.userRoles = res.data;
			},
			error => {
				this.throwError(error);
			});
		this.subscriptions.push(roleSubscription);
	}

	createForm() {
		this.userForm = this.userFB.group({
			// userName: [this.user.userName, Validators.required],
			fullName: [this.user.fullName, [Validators.required, Validators.pattern(/^(?!\s+$).+/)]],
			email: [this.user.email, [Validators.required, Validators.email]],
			phoneNumber: [this.user.phoneNumber, [Validators.required, Validators.pattern(/^(01[0-9]{9})$/)]],
			address: [this.user.address],
			gender: [this.user.gender],
			dateOfBirth: [],
			userRoleId: [this.user.userRoleId, Validators.required],
		});

		if(this.user.dateOfBirth) {
			const dateStr = new Date(this.user.dateOfBirth);
			this.userForm.controls.dateOfBirth.setValue({
				year: dateStr.getFullYear(),
				month: dateStr.getMonth()+1,
				day: dateStr.getDate()
			});
		}
	} 
	
	get ufControls() { return this.userForm.controls; }

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
		const controls = this.userForm.controls;
		
		if (this.userForm.invalid) {
			Object.keys(controls).forEach(controlName =>
				controls[controlName].markAsTouched()
			);

			// this.hasFormErrors = true;
			// this.selectedTab = 0;
			return;
		}

		const editedUser = this.prepareUser();

		if (editedUser.id && Guid.isGuid(editedUser.id)) {
			this.updateUser(editedUser);
		}
		else {
			this.createUser(editedUser);
		}
	}

	prepareUser(): SaveUser {
		const controls = this.userForm.controls;
		const _user = new SaveUser();
		_user.clear();
		_user.id = this.user.id;
		// _user.userName = controls['userName'].value;
		_user.email = controls['email'].value;
		_user.fullName = controls['fullName'].value;
		_user.gender = controls['gender'].value;
		_user.address = controls['address'].value;
		_user.phoneNumber = controls['phoneNumber'].value;
		_user.userRoleId = controls['userRoleId'].value;
		const date = controls['dateOfBirth'].value;
		if(date && date.year && date.month && date.day) {
			_user.dateOfBirth = new Date(date.year,date.month-1,date.day);
		}
		
		return _user;
	}

	createUser(_user: SaveUser) {
		this.alertService.fnLoading(true);
		const createSubscription = this.userService.create(_user)
			.pipe(finalize(() => this.alertService.fnLoading(false)))
			.subscribe(res => {
				this.alertService.tosterSuccess(`New user successfully has been added.`);
				this.goBack();
			},
			error => {
				this.throwError(error);
			});
		this.subscriptions.push(createSubscription);
	}

	updateUser(_user: SaveUser) {
		this.alertService.fnLoading(true);
		const updateSubscription = this.userService.update(_user)
			.pipe(finalize(() => this.alertService.fnLoading(false)))
			.subscribe(res => {
				this.alertService.tosterSuccess(`User successfully has been saved.`);
				this.goBack();
			},
			error => {
				this.throwError(error);
			});
		this.subscriptions.push(updateSubscription);
	}

	getComponentTitle() {
		let result = 'Create user';
		if (!this.user || !this.user.id) {
			return result;
		}

		result = `Edit user - ${this.user.fullName}`;
		return result;
	}
	
	goBack() {
		this.router.navigate([`/users`], { relativeTo: this.activatedRoute });
	}

	stringToInt(value): number {
		return Number.parseInt(value);
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
        } else {
            // this.alertService.tosterDanger(errorDetails.error.message);
        }
    }
}

