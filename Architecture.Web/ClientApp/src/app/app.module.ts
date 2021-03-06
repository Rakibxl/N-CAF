import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgReduxModule } from '@angular-redux/store';
import { NgRedux, DevToolsExtension } from '@angular-redux/store';
import { rootReducer, ArchitectUIState } from './ThemeOptions/store';
import { ConfigActions } from './ThemeOptions/store/config.actions';
import { AppRoutingModule } from './app-routing.module';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';

// BOOTSTRAP COMPONENTS
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';


import { AppInterceptorService } from './app-interceptor.service';
import { AuthGuard } from './Shared/Guards/auth.guard';
import { PermissionGuard } from './Shared/Guards/permission.guard';
import { JwtModule } from '@auth0/angular-jwt';
import { IAuthUser } from './Shared/Entity/Users/auth';
import { MustMatchDirective } from './Shared/Directive/mustmatch.directive';
import { PDFModifyComponent } from './pdfmodify/pdfmodify.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { SelectModule } from 'ng-select';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { DashboardGuard } from './Shared/Guards/dashboard.guard';
export function HttpLoaderFactory(http: HttpClient) {
    return new TranslateHttpLoader(http);
}

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
    suppressScrollX: true
};


const isIE = window.navigator.userAgent.indexOf('MSIE ') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;

export function tokenGetter(): string {
    const authUser = JSON.parse(localStorage.getItem("currentUser")) as IAuthUser;
    return authUser ? authUser.token : "";
}

@NgModule({
    declarations: [
        AppComponent,
        MustMatchDirective,
        PDFModifyComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        PdfViewerModule,
        NgReduxModule,
        CommonModule,
        LoadingBarRouterModule,
        MatProgressSpinnerModule,
        // Angular Bootstrap Components
        PerfectScrollbarModule,
        NgbModule,
        AngularFontAwesomeModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        SelectModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: tokenGetter
            }
        }),
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpClient]
            },
            defaultLanguage: 'en'
        })
    ],
    exports: [
        MatProgressSpinnerModule,
        TranslateModule
    ],
    providers: [{
        provide: HTTP_INTERCEPTORS,
        useClass: AppInterceptorService,
        multi: true
    },
    {
        provide:
            PERFECT_SCROLLBAR_CONFIG,
        // DROPZONE_CONFIG,
        useValue:
            DEFAULT_PERFECT_SCROLLBAR_CONFIG,
        // DEFAULT_DROPZONE_CONFIG,
    },
        ConfigActions,
        AuthGuard,
        PermissionGuard,
        DashboardGuard
    ],
    bootstrap: [AppComponent]
})

export class AppModule {
    constructor(private ngRedux: NgRedux<ArchitectUIState>,
        private devTool: DevToolsExtension) {
        this.ngRedux.configureStore(
            rootReducer,
            {} as ArchitectUIState,
            [],
            [devTool.isEnabled() ? devTool.enhancer() : f => f]
        );
    }
}
