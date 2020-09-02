import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { ExampleService } from 'src/app/Shared/Services/Examples/examples.service';
import { AlertService } from 'src/app/Shared/Modules/alert/alert.service';
import { Guid } from 'guid-typescript';
import { finalize } from 'rxjs/operators';
import { Example, SaveExample } from 'src/app/Shared/Entity/Examples/example';

@Component({
	selector: 'app-example-form',
	templateUrl: './example-form.component.html',
	styleUrls: ['./example-form.component.css']
})
export class ExampleFormComponent implements OnInit, OnDestroy {

	example: Example;
	exampleForm: FormGroup;
	imageFile: File;

	private subscriptions: Subscription[] = [];


	constructor(private activatedRoute: ActivatedRoute,
		private router: Router,
		private exampleFB: FormBuilder,
		private alertService: AlertService,
		private exampleService: ExampleService) { }

	ngOnInit() {

		// this.alertService.fnLoading(true);
		const routeSubscription = this.activatedRoute.params.subscribe(params => {
			const id = params['id'];
			console.log(id);
			if (id) {

				this.alertService.fnLoading(true);
				this.exampleService.getExample(id)
					.pipe(finalize(() => this.alertService.fnLoading(false)))
					.subscribe(res => {
						if (res) {
							this.example = res.data as Example;
							this.initExamples();
						}
					});
			} else {
				this.example = new Example();
				this.example.clear();
				this.initExamples();
			}
		});
		this.subscriptions.push(routeSubscription);
	}

	ngOnDestroy() {
		this.subscriptions.forEach(sb => sb.unsubscribe());
	}

	initExamples() {
		this.createForm();
	}

	createForm() {
		this.exampleForm = this.exampleFB.group({
			name: [this.example.name, [Validators.required, Validators.pattern(/^(?!\s+$).+/)]],
			description: [this.example.description],
			sequence: [this.example.sequence, [Validators.required, Validators.pattern(/^[0-9]+$/)]],
			isActive: [this.example.isActive]
		});
	}

	get formControls() { return this.exampleForm.controls; }

	onSubmit() {

		const controls = this.exampleForm.controls;

		if (this.exampleForm.invalid) {
			Object.keys(controls).forEach(controlName =>
				controls[controlName].markAsTouched()
			);
			return;
		}

		const editedExamples = this.prepareExamples();
		if (editedExamples.id) {
			this.updateExamples(editedExamples);
		}
		else {
			this.createExamples(editedExamples);
		}
	}

	prepareExamples(): SaveExample {
		const controls = this.exampleForm.controls;

		const _example = new SaveExample();
		_example.clear();
		_example.id = this.example.id;
		_example.name = controls['name'].value;
		_example.description = controls['description'].value;
		_example.sequence = controls['sequence'].value;
		_example.isActive = controls['isActive'].value;
		if(this.imageFile)
			_example.imageFile = this.imageFile;
		
		return _example;
	}

	createExamples(_example: SaveExample) {
		this.alertService.fnLoading(true);
		const createSubscription = this.exampleService.create(_example)
			.pipe(finalize(() => this.alertService.fnLoading(false)))
			.subscribe(res => {
				this.alertService.tosterSuccess(`New Example has been added successfully.`);
				this.goBack();
			},
				error => {
					this.throwError(error);
				});
		this.subscriptions.push(createSubscription);
	}

	updateExamples(_example: SaveExample) {
		this.alertService.fnLoading(true);
		const updateSubscription = this.exampleService.update(_example)
			.pipe(finalize(() => this.alertService.fnLoading(false)))
			.subscribe(res => {
				this.alertService.tosterSuccess(`Example has been saved successfully.`);
				this.goBack();
			},
				error => {
					this.throwError(error);
				});
		this.subscriptions.push(updateSubscription);
	}

	getComponentTitle() {
		let result = 'Create Example';
		if (!this.example || !this.example.id) {
			return result;
		}

		result = `Edit Example - ${this.example.name}`;
		return result;
	}

	goBack() {
		this.router.navigate([`/examples`], { relativeTo: this.activatedRoute });
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

    onChangeFile(file: File) {
        console.log("image file", file);
        this.imageFile = file;
        if(this.imageFile == null)
        {
            this.example.imageUrl = '';
        }
    }
}
