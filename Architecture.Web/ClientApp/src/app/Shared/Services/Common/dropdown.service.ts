import { Injectable, Inject } from '@angular/core';
import * as _moment from 'moment';
import { HttpClient } from '@angular/common/http';
import { APIResponse } from '../../Entity/Response/api-response';
declare var jQuery: any;

@Injectable({
    providedIn: 'root'
})
export class DropdownService {

    public baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl + 'api/';
    }

    public async getAddressInfo() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/AddressType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getAppUserStatus() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/UserStatus`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getAppUserType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/UserType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getAssetType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/AssetType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getBankName() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/BankName`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getContractType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/ContractType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getCountryName() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/CountryName`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getDegreeName() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/DegreeName`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getDocumentType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/DocumentType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getEyeColor() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/EyeColor`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getGender() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/Gender`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getHouseCategory() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/HouseCategory`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getHouseType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/HouseType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getIncomeType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/IncomeType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getInsuranceType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/InsuranceType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getISEEClassType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/ISEEClassType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getJobDeliveryType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/JobDeliveryType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getJobType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/JobType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getLoanInterestType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/LoanInterestType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getLoanStatusType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/LoanStatusType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getMaritalStatus() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/MaritalStatus`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getMotiveType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/MotiveType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getNationalIdType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/NationalIdType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getNationality() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/Nationality`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getOccupationPositionType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/OccupationPositionType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getOccupationType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/OccupationType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getOwnerType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/OwnerType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getRelationType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/RelationType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getResidenceScope() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/ResidenceScope`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getOccupationPosition() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/OccupationPosition`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getSectionName() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/SectionName`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getOperatorKeyword() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/OperatorKeyword`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getProvince() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/Province`).toPromise().then(res => { result = res.data });
        return result;
    }

    public async getWorkerType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/WorkerType`).toPromise().then(res => { result = res.data });
        return result;
    }
    public async getPaymentType() {
        let result;
        await this.http.get<APIResponse>(this.baseUrl + `v1/GenericDropDown/PaymentType`).toPromise().then(res => { result = res.data });
        return result;
    }

}
