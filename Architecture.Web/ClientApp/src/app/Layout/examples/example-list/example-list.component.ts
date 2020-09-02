import { Component, OnInit, OnDestroy } from '@angular/core';
import { IPTableSetting } from 'src/app/Shared/Modules/p-table';
import { finalize, take, delay } from 'rxjs/operators';
import { Subscription, of } from 'rxjs';
import { Router } from '@angular/router';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { CommonService } from 'src/app/Shared/Services/Common/common.service';
import { ExampleService } from 'src/app/Shared/Services/Examples/examples.service';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { Example, ExampleQuery } from 'src/app/Shared/Entity/Examples/example';

@Component({
	selector: 'app-example-list',
	templateUrl: './example-list.component.html',
	styleUrls: ['./example-list.component.css']
})
export class ExampleListComponent implements OnInit, OnDestroy {

	query: ExampleQuery;
	PAGE_SIZE: number;
	examples: Example[];

	// Subscriptions
	private subscriptions: Subscription[] = [];

	constructor(
		private router: Router,
		private alertService: AlertService,
		private exampleService: ExampleService,
		private modalService: NgbModal,
		private commonService: CommonService) {
		this.PAGE_SIZE = 5000;//commonService.PAGE_SIZE;
	}

	ngOnInit() {
		of(undefined).pipe(take(1), delay(1000)).subscribe(() => {
			this.loadExamplesPage();
		});
	}

	ngOnDestroy() {
		this.subscriptions.forEach(el => el.unsubscribe());
	}

	loadExamplesPage() {
		this.searchConfiguration();
		this.alertService.fnLoading(true);
		const exampleSubscription = this.exampleService.getExamples(this.query)
			.pipe(finalize(() => { this.alertService.fnLoading(false); }))
			.subscribe(
				(res) => {
					console.log("res.data", res.data);
					this.examples = res.data.items;
					this.examples.forEach(obj => {
						obj.isActiveText = obj.isActive ? 'YES' : 'NO';
					});
				},
				(error) => {
					console.log(error);
				});
		this.subscriptions.push(exampleSubscription);
	}

	searchConfiguration() {
		this.query = new ExampleQuery({
			page: 1,
			pageSize: this.PAGE_SIZE,
			sortBy: 'name',
			isSortAscending: true,
			name: '',
		});
	}

	toggleActiveInactive(id) {
		const actInSubscription = this.exampleService.activeInactive(id).subscribe(res => {
			this.loadExamplesPage();
		});
		this.subscriptions.push(actInSubscription);
	}

	editExample(id) {
		this.router.navigate(['/examples/edit', id]);
	}

	newExample() {
		this.router.navigate(['/examples/new']);
	}

	deleteExample(id) {
		this.alertService.confirm("Are you sure want to delete this Example?",
			() => {
				this.alertService.fnLoading(true);
				const deleteSubscription = this.exampleService.delete(id)
					.pipe(finalize(() => { this.alertService.fnLoading(false); }))
					.subscribe((res: any) => {
						console.log('res from del func', res);
						this.alertService.tosterSuccess("Example has been deleted successfully.");
						this.loadExamplesPage();
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
		tableID: "example-table",
		tableClass: "table table-border ",
		tableName: 'Example List',
		tableRowIDInternalName: "id",
		tableColDef: [
			{ headerName: 'Name', width: '30%', internalName: 'name', sort: true, type: "" },
			{ headerName: 'Description', width: '40%', internalName: 'description', sort: false, type: "" },
			{ headerName: 'Sequence', width: '15%', internalName: 'sequence', sort: true, type: "" },
			{ headerName: 'Active', width: '15%', internalName: 'isActiveText', sort: true, type: "" },
		],
		enabledSearch: true,
		enabledSerialNo: true,
		pageSize: 10,
		enabledPagination: true,
		enabledDeleteBtn: true,
		enabledEditBtn: true,
		enabledColumnFilter: true,
		enabledRadioBtn: false,
		enabledRecordCreateBtn: true,
		newRecordButtonText: 'New Example'
	};

	public fnCustomTrigger(event) {
		console.log("custom  click: ", event);

		if (event.action == "new-record") {
			this.newExample();
		}
		else if (event.action == "edit-item") {
			this.editExample(event.record.id);
		}
		else if (event.action == "delete-item") {
			this.deleteExample(event.record.id);
		}
	}
}
