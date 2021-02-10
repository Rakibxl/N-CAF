import { Component, OnInit, OnDestroy, ElementRef, ViewChild, ChangeDetectorRef, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { merge, fromEvent, Subscription, of } from 'rxjs';
import { tap, debounceTime, distinctUntilChanged, take, delay, finalize } from 'rxjs/operators';
import { CommonService } from 'src/app/Shared/Services/Common/common.service';
import { IPTableSetting } from 'src/app/Shared/Modules/p-table';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { UserRoleQuery, UserRole } from 'src/app/Shared/Entity/Users/role';
import { RoleService } from 'src/app/Shared/Services/Users/role.service';
import { NgbModalOptions, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserRoleFormComponent } from '../user-role-form/user-role-form.component';
import { AuthService } from 'src/app/Shared/Services/Users/auth.service';

@Component({
	selector: 'app-user-role-list',
	templateUrl: './user-role-list.component.html',
	styleUrls: ['./user-role-list.component.css']
})
export class UserRoleListComponent implements OnInit, OnDestroy {

	query: UserRoleQuery;
	PAGE_SIZE: number;
	userroles: UserRole[];

	// Subscriptions
	private subscriptions: Subscription[] = [];

	constructor(
		private router: Router,
		private roleService: RoleService,
		private modalService: NgbModal,
		private alertService: AlertService,
		private authService: AuthService,
		private commonService: CommonService) {
		this.PAGE_SIZE = commonService.PAGE_SIZE;
	}

	ngOnInit() {
		// First Load
		of(undefined).pipe(take(1), delay(1000)).subscribe(() => {
			this.loadUserRolesPage();
		});
		this.ptableSettings.enabledRecordCreateBtn = this.authService.currentUserValue.appUserTypeId == 1 ? true : false;
		this.ptableSettings.enabledEditDeleteBtn = this.authService.currentUserValue.appUserTypeId == 1 ? true : false;
		this.ptableSettings.enabledEditBtn = this.authService.currentUserValue.appUserTypeId == 1 ? true : false;
		this.ptableSettings.enabledDeleteBtn = this.authService.currentUserValue.appUserTypeId == 1 ? true : false;
	}

	ngOnDestroy() {
		this.subscriptions.forEach(el => el.unsubscribe());
	}

	loadUserRolesPage() {
		this.searchConfiguration();
		this.alertService.fnLoading(true);
		const rolesSubscription = this.roleService.getRoles(this.query)
			.pipe(finalize(() => { this.alertService.fnLoading(false); }))
			.subscribe(
				(res) => {
					this.userroles = res.data;
				},
				(error) => {
					console.log(error);
				});
		this.subscriptions.push(rolesSubscription);
	}

	searchConfiguration() {
		this.query = new UserRoleQuery({
			page: 1,
			pageSize: this.PAGE_SIZE,
			sortBy: 'name',
			isSortAscending: true,
			name: '',
		});
	}

	toggleActiveInactive(id) {
		const actInSubscription = this.roleService.activeInactive(id).subscribe(res => {
			this.loadUserRolesPage();
		});
		this.subscriptions.push(actInSubscription);
	}

	viewUserRole(id) {
		console.log(`view ${id}`);
	}

	editUserRole(id) {
		// this.router.navigate(['/roles/edit', id]);
		this.openUserRoleModal(id);
	}

	newUserRole() {
		// this.router.navigate(['/roles/new']);
		this.openUserRoleModal(null);
	}

	deleteUserRole(id) {
		console.log(`delete ${id}`);
		this.alertService.confirm("Are you sure want to delete this role?",
			() => {
				this.alertService.fnLoading(true);
				const deleteSubscription = this.roleService.delete(id)
					.pipe(finalize(() => { this.alertService.fnLoading(false); }))
					.subscribe((res: any) => {
						console.log('res from del func', res);
						this.alertService.tosterSuccess("Role has been deleted successfully.");
						this.loadUserRolesPage();
					},
						(error) => {
							console.log(error);
						});
				this.subscriptions.push(deleteSubscription);
			},
			() => {
			});
	}

	public ptableSettings: IPTableSetting = {
		tableID: "roles-table",
		tableClass: "table table-border ",
		tableName: 'Roles List',
		tableRowIDInternalName: "id",
		tableColDef: [
			{ headerName: 'Role Id', width: '40%', internalName: 'id', sort: true, type: "" },
			{ headerName: 'Role Name', width: '50%', internalName: 'name', sort: true, type: "" },
		],
		enabledSearch: true,
		enabledSerialNo: true,
		pageSize: 10,
		enabledPagination: true,
		//enabledAutoScrolled:true,
		enabledDeleteBtn: true,
		enabledEditBtn: true,
		// enabledCellClick: true,
		enabledColumnFilter: true,
		// enabledDataLength:true,
		// enabledColumnResize:true,
		// enabledReflow:true,
		// enabledPdfDownload:true,
		// enabledExcelDownload:true,
		// enabledPrint:true,
		// enabledColumnSetting:true,
		enabledRecordCreateBtn: true,
		// enabledTotal:true,
		newRecordButtonText: 'New Role'
	};

	public fnCustomTrigger(event) {
		console.log("custom  click: ", event);

		if (event.action == "new-record") {
			this.newUserRole();
		}
		else if (event.action == "edit-item") {
			this.editUserRole(event.record.id);
		}
		else if (event.action == "delete-item") {
			this.deleteUserRole(event.record.id);
		}
	}

	openUserRoleModal(id?) {
		let ngbModalOptions: NgbModalOptions = {
			backdrop: "static",
			keyboard: false,
			size: "lg",
		};
		const modalRef = this.modalService.open(
			UserRoleFormComponent,
			ngbModalOptions
		);
		modalRef.componentInstance.userRoleId = id;

		modalRef.result.then(
			(result) => {
				console.log(result);
				if (!(result == 'Close click' || result == 'Cross click'))
					this.loadUserRolesPage();
			},
			(reason) => {
				console.log(reason);
			});
	}
}
