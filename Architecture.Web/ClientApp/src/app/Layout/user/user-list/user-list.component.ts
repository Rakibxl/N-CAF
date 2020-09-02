import { Component, OnInit, OnDestroy, ElementRef, ViewChild, ChangeDetectorRef, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router, Event } from '@angular/router';
import { merge, fromEvent, Subscription, of } from 'rxjs';
import { tap, debounceTime, distinctUntilChanged, take, delay, finalize } from 'rxjs/operators';
import { UserQuery, User } from 'src/app/Shared/Entity/Users/user';
import { UserService } from 'src/app/Shared/Services/Users/user.service';
import { CommonService } from 'src/app/Shared/Services/Common/common.service';
import { IPTableSetting } from 'src/app/Shared/Modules/p-table';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { EventEmitter } from 'events';
import { EnumUserRoleDisplayName } from 'src/app/Shared/Enums/user-role';
import { MapObject } from 'src/app/Shared/Enums/map-object';

@Component({
	selector: 'app-user-list',
	templateUrl: './user-list.component.html',
	styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit, OnDestroy {

	query: UserQuery;
	PAGE_SIZE: number;
	users: User[];

	// Subscriptions
	private subscriptions: Subscription[] = [];
	enumUserTypes:MapObject[] = EnumUserRoleDisplayName.EnumUserRoleTypeDisplayName;

	constructor(
		private router: Router,
		private userService: UserService,
		private alertService: AlertService,
		private commonService: CommonService) {
		this.PAGE_SIZE = commonService.PAGE_SIZE;
	}

	ngOnInit() {
		// First Load
		of(undefined).pipe(take(1), delay(1000)).subscribe(() => {
			this.loadUsersPage();
		});
	}

	ngOnDestroy() {
		this.subscriptions.forEach(el => el.unsubscribe());
	}

	loadUsersPage() {
		this.searchConfiguration();
		this.alertService.fnLoading(true);
		const usersSubscription = this.userService.getExceptAppUsers(this.query)
			.pipe(finalize(() => { this.alertService.fnLoading(false); }))
			.subscribe(
				(res) => {
					this.users = res.data.items;
					this.users.forEach((x) => {
						x.userViewDetailBtn = "View User";

						let role = this.enumUserTypes.filter(a => a.id == x.userRoleName)[0];
						x.userRoleDisplayName = (role) ? role.label : "";
					});
				},
				(error) => {
					console.log(error);
				});
		this.subscriptions.push(usersSubscription);
	}

	searchConfiguration() {
		this.query = new UserQuery({
			page: 1,
			pageSize: this.PAGE_SIZE,
			sortBy: 'fullName',
			isSortAscending: true,
			fullName: '',
			userName: '',
			email: '',
		});
	}

	toggleActiveInactive(id) {
		const actInSubscription = this.userService.activeInactive(id).subscribe(res => {
			this.loadUsersPage();
		});
		this.subscriptions.push(actInSubscription);
	}

	viewUser(id) {
		console.log(`view ${id}`);
	}

	editUser(id) {
		this.router.navigate(['/users/edit', id]);
	}

	newUser() {
		this.router.navigate(['/users/new']);
	}

	deleteUser(id) {
		console.log(`delete ${id}`);
		this.alertService.confirm("Are you sure want to delete this user?",
			() => {
				this.alertService.fnLoading(true);
				const deleteSubscription = this.userService.delete(id)
					.pipe(finalize(() => { this.alertService.fnLoading(false); }))
					.subscribe((res: any) => {
						console.log('res from del func', res);
						this.alertService.tosterSuccess("User has been deleted successfully.");
						this.loadUsersPage();
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
		tableID: "users-table",
		tableClass: "table table-border ",
		tableName: 'Users List',
		tableRowIDInternalName: "id",
		tableColDef: [
			{ headerName: 'Full Name', width: '20%', internalName: 'fullName', sort: true, type: "" },
			{ headerName: 'Email', width: '20%', internalName: 'email', sort: true, type: "" },
			{ headerName: 'Phone Number ', width: '15%', internalName: 'phoneNumber', sort: false, type: "" },
			{ headerName: 'Gender', width: '15%', internalName: 'gender', sort: true, type: "" },
			{ headerName: 'Role Name', width: '15%', internalName: 'userRoleDisplayName', sort: true, type: "" },
			{ headerName: 'Details', width: '15%', internalName: 'userViewDetailBtn', sort: false, type: "button", onClick: 'true', innerBtnIcon: "fa fa-user" }

		],
		enabledSearch: true,
		enabledSerialNo: true,
		pageSize: 10,
		enabledPagination: true,
		//enabledAutoScrolled:true,
		enabledDeleteBtn: true,
		enabledEditBtn: true,
		enabledCellClick: true,
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
		newRecordButtonText: 'New User'
	};

	public fnCustomTrigger(event) {
		console.log("custom  click: ", event);

		if (event.action == "new-record") {
			this.newUser();
		}
		else if (event.action == "edit-item") {
			this.editUser(event.record.id);
		}
		else if (event.action == "delete-item") {
			this.deleteUser(event.record.id);
		}
	}

	public fnViewUser(event: any) {
		console.log(event);
		let id = event.record.id;
		this.router.navigate([`/users/details/${id}`]);
	}

}
