import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from "rxjs";
import { catchError, finalize } from "rxjs/operators"
import { AlertService } from './Shared/Modules/alert/alert.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from './Shared/Services/Users/auth.service';

@Injectable({ providedIn: 'root' })
export class AppInterceptorService implements HttpInterceptor {
    
    constructor(private alertService: AlertService,
        private activatedRoute: ActivatedRoute,
        private authService: AuthService) { 
    }

    handleError = (error: HttpErrorResponse, request?, next?) => {
        console.log("api error:", error);
        setTimeout(() => {
            this.alertService.fnLoading(false);   
            let statusCode = error.status;
            let errorMsg = error.error.message || "";
            if (statusCode == 0) {
                errorMsg = "You may have internet connection problem. Check your network and try again";
            } else if (statusCode == 404) {
                errorMsg = "You may have application issues. Please contact with system admin.";
            }
            else if (statusCode == 401 || statusCode == 403) {
                errorMsg = "You are not authorized. Please contact with system admin.";
            }
            else if (statusCode == 400) {
                errorMsg = "Validation failed for " + error.error.errors[0].propertyName + ". " 
                + error.error.errors[0].errorList[0];
            }

            //showing message            
            if (errorMsg != "") {
                this.alertService.titleTosterDanger(errorMsg);
            }
        }, 1000);

        return throwError(error)
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        debugger
        this.alertService.fnLoading(true);
        console.log('processing request', request);
        console.log('url', request.url);

        const token = this.authService.currentUserToken;

        if (request.method === 'POST' || request.method === 'PUT') {
            this.shiftDates(request.body);
        }
        
        const headers = new HttpHeaders({
            Authorization: 'Bearer ' + token
        });

        const haderClone = request.clone({
            headers
        });

        return next
            .handle(haderClone)
            .pipe(
                catchError(error => {
                    return this.handleError(error, request, next);
                }),
                finalize(() => {
                    setTimeout(() => {
                        this.alertService.fnLoading(false);
                    }, 1000);
                })
            )
    }

    shiftDates(body) {
        if (body === null || body === undefined) {
            return body;
        }
    
        if (typeof body !== 'object') {
            return body;
        }
    
        for (const key of Object.keys(body)) {
            const value = body[key];
            if (value instanceof Date) {
                body[key] = new Date(Date.UTC(value.getFullYear(), value.getMonth(), value.getDate(), value.getHours(), value.getMinutes()
                    , value.getSeconds()));
            } else if (typeof value === 'object') {
                this.shiftDates(value);
            }
        }
    }

}