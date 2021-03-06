import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService } from '../Common/common.service';
import { SaveUser } from '../../Entity/Users/user';
import { Guid } from 'guid-typescript';
import { APIResponse } from '../../Entity/Response/api-response';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  public baseUrl: string;
  public usersEndpoint: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private commonService: CommonService) {
    this.baseUrl = baseUrl + 'api/';
    this.usersEndpoint = this.baseUrl + 'v1/users';
  }

  getUsers(filter?) {
    return this.http.get<APIResponse>(`${this.usersEndpoint}?${this.commonService.toQueryString(filter)}`);
  }

  getUser(id) {
    return this.http.get<APIResponse>(`${this.usersEndpoint}/${id}`);
  }

  createOrUpdateAppUser(data) {
    let url = this.usersEndpoint + "/CreateOrUpdate";
    return this.http.post<APIResponse>(`${url}`, data);
  }

  getExceptAppUsers(filter?) {
    return this.http.get<APIResponse>(`${this.usersEndpoint}/except-app-users?${this.commonService.toQueryString(filter)}`);
  }

  getAppUsers(filter?) {
    return this.http.get<APIResponse>(`${this.usersEndpoint}/app-users?${this.commonService.toQueryString(filter)}`);
  }

  create(user: SaveUser) {
    user.id = Guid.EMPTY;
    return this.http.post<APIResponse>(`${this.usersEndpoint}`, user);
  }

  update(user: SaveUser) {
    return this.http.put<APIResponse>(`${this.usersEndpoint}/${user.id}`, user);
  }

  delete(id) {
    return this.http.delete<APIResponse>(`${this.usersEndpoint}/${id}`);
  }

  activeInactive(id) {
    return this.http.post<APIResponse>(`${this.usersEndpoint}/activeInactive/${id}`, null);
    }
}