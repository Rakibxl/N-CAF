import { Injectable, Inject } from '@angular/core';
import { QuestionInfo } from '../../Entity/Users/QuestionInfo';
import { APIResponse } from '../../Entity/Response/api-response';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class QuestionInfoService {
    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        debugger;    
        this.baseUrl = baseUrl + 'api/';
    }

    public saveQuestionInfo(data: QuestionInfo) {
        debugger;
        return this.http.post<APIResponse>(this.baseUrl + 'v1/QuestionInfo/CreateOrUpdate', data);
    }
    public getQuestionInfo() {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/QuestionInfo/GetQuestion`);
    }

    public getQuestionById(questionInfoId: number) {
        debugger;
        return this.http.get<APIResponse>(this.baseUrl + `v1/QuestionInfo/GetById/${questionInfoId}`);
    }
}
