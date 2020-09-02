import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExampleRoutingModule } from './example-routing.module';
import { ExampleComponent } from './example.component';
import { SharedMasterModule } from 'src/app/Shared/Modules/shared-master/shared-master.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ExampleListComponent } from './example-list/example-list.component';
import { ExampleFormComponent } from './example-form/example-form.component';


@NgModule({
  declarations: [
    ExampleListComponent,
    ExampleFormComponent,
    ExampleComponent
  ],
  imports: [
    CommonModule,
    ExampleRoutingModule,
    SharedMasterModule,
    AngularFontAwesomeModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule
  ],
  entryComponents: [
  ]
})
export class ExampleModule { }
