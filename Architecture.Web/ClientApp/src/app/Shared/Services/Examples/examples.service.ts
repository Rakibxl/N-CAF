import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService } from '../Common/common.service';
import { Guid } from 'guid-typescript';
import { APIResponse } from '../../Entity/Response/api-response';
import { SaveExample } from '../../Entity/Examples/example';

@Injectable({
    providedIn: 'root'
})

export class ExampleService {
    public baseUrl: string;
    public examplesEndpoint: string;

    constructor(
      private http: HttpClient,
      @Inject('BASE_URL') baseUrl: string,
      private commonService: CommonService) {
        this.baseUrl = baseUrl + 'api/';
        this.examplesEndpoint = this.baseUrl + 'v1/examples';
    }
  
    getExample(id) {
      return this.http.get<APIResponse>(`${this.examplesEndpoint}/${id}`);
    }
  
    getExamples(filter?) {
      return this.http.get<APIResponse>(`${this.examplesEndpoint}?${this.commonService.toQueryString(filter)}`);
    }

    create(Example: SaveExample) {
      Example.id = 0;
      return this.http.post<APIResponse>(`${this.examplesEndpoint}`, this.commonService.toFormData( Example));
    }
  
    update(Example: SaveExample) {
      return this.http.put<APIResponse>(`${this.examplesEndpoint}/${Example.id}`, this.commonService.toFormData( Example));
    }
  
    delete(id) {
      return this.http.delete<APIResponse>(`${this.examplesEndpoint}/${id}`);
    }
  
    activeInactive(id) {
      return this.http.post<APIResponse>(`${this.examplesEndpoint}/activeInactive/${id}`, null);
    }
}