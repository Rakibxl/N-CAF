import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageTitleComponent } from 'src/app/Layout/LayoutComponent/Components/page-title/page-title.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { AlertModule } from '../alert/alert.module';
import { PTableModule } from '../p-table/p-table.module';
import { ImageUploaderComponent } from 'src/app/Shared/Modules/image-uploader/image-upload.component';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [
    PageTitleComponent,
    ImageUploaderComponent
  ],
  imports: [
    CommonModule,
    AngularFontAwesomeModule,
    AlertModule,
    PTableModule,
    TranslateModule
  ],
  exports:[PageTitleComponent,
    ImageUploaderComponent, 
    AlertModule,
    PTableModule,
    TranslateModule
  ]
})
export class SharedMasterModule { }
