import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService } from '../Common/common.service';
import { SaveUserRole } from '../../Entity/Users/role';
import { Guid } from 'guid-typescript';
import { APIResponse } from '../../Entity/Response/api-response';
@Injectable({
  providedIn: 'root'
})

export class UserRoleService {
  public baseUrl: string;
  public userRolesEndpoint: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private commonService: CommonService) {
    this.baseUrl = baseUrl + 'api/';
    this.userRolesEndpoint = this.baseUrl + 'v1/userRoleMapping';
  }

  getUserRoles(filter?) {
    return this.http.get<APIResponse>(`${this.userRolesEndpoint}?${this.commonService.toQueryString(filter)}`);
  }

  createUserRole(data) {
    let url = this.userRolesEndpoint + "/Create";
    return this.http.post<APIResponse>(`${url}`, data);
  }
}