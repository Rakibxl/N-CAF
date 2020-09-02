import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService } from '../Common/common.service';
import { SaveUserRole } from '../../Entity/Users/role';
import { Guid } from 'guid-typescript';
import { APIResponse } from '../../Entity/Response/api-response';
@Injectable({
    providedIn: 'root'
})
export class RoleService {
    public baseUrl: string;
    public userRolesEndpoint: string;

    constructor(
        private http: HttpClient, 
        @Inject('BASE_URL') baseUrl: string,
        private commonService: CommonService) {
            this.baseUrl = baseUrl + 'api/';
            this.userRolesEndpoint = this.baseUrl + 'v1/roles';
    }
  
    getRole(id) {
      return this.http.get<APIResponse>(`${this.userRolesEndpoint}/${id}`);
    }
  
    getRoles(filter?) {
      return this.http.get<APIResponse>(`${this.userRolesEndpoint}?${this.commonService.toQueryString(filter)}`);
    }

    create(userRole: SaveUserRole) {
      userRole.id = Guid.EMPTY;
      return this.http.post<APIResponse>(`${this.userRolesEndpoint}`, userRole);
    }
  
    update(userRole: SaveUserRole) {
      return this.http.put<APIResponse>(`${this.userRolesEndpoint}/${userRole.id}`, userRole);
    }
  
    delete(id) {
      return this.http.delete<APIResponse>(`${this.userRolesEndpoint}/${id}`);
    }
  
    activeInactive(id) {
      return this.http.post<APIResponse>(`${this.userRolesEndpoint}/activeInactive/${id}`, null);
    }

    getRoleSelect () {
      return this.http.get<APIResponse>(`${this.userRolesEndpoint}/select`);
    }
}