import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonService } from '../Common/common.service';
import { SaveUserRole } from '../../Entity/Users/role';
import { Guid } from 'guid-typescript';
import { APIResponse } from '../../Entity/Response/api-response';

@Injectable({
  providedIn: 'root'
})
export class BranchService {
  public baseUrl: string;
  public branchEndpoint: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private commonService: CommonService) {
    this.baseUrl = baseUrl + 'api/';
    this.branchEndpoint = this.baseUrl + 'v1/Branch';
  }

  getBranchInfo(branchId) {
    let url = this.branchEndpoint + "/GetBranchInfo?branchId=" + branchId;
    return this.http.get<APIResponse>(`${url}`);
  }

  getBranchList() {
    let url = this.branchEndpoint + "/GetBranches";
    return this.http.get<APIResponse>(`${url}`);
  }

  createOrUpdate(data) {
    let url = this.branchEndpoint + "/CreateOrUpdate";
    return this.http.post<APIResponse>(`${url}`, data);
  }
}
