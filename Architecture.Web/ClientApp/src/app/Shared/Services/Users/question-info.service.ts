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
        this.baseUrl = baseUrl + 'api/';
    }

    public saveQuestionInfo(data: QuestionInfo) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/QuestionInfo/CreateOrUpdate', data);
    }
    public getQuestionInfo() {
        return this.http.get<APIResponse>(this.baseUrl + `v1/QuestionInfo/GetQuestion`);
    }

    public getQuestionById(questionInfoId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/QuestionInfo/GetById/${questionInfoId}`);
    }
    public GetUserQuestion() {
        return this.http.get<APIResponse>(this.baseUrl + `v1/QuestionInfo/GetUserQuestion`);
    }
}
