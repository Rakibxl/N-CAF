import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { ClientProfileService } from '../../../Shared/Services/ClientProfile/client-profile.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { OccupationInfoService } from '../../../Shared/Services/ClientProfile/occupation-info.service';


@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent implements OnInit {
  basicInfo: any = {};
  occupationInfoList: any[] = [];
  ptableSettings: IPTableSetting;

  constructor(private router: Router, private clientProfileService: ClientProfileService,
    private commonService: CommonService, private occupationService: OccupationInfoService) {
    this.initGrid();
  }

  ngOnInit() {
    this.loadBasicInfo();
  }

  initGrid() {
    this.ptableSettings = {
      tableClass: "table table-border ",
      tableName: 'Occupation List',
      tableRowIDInternalName: "assetinfoid",
      tableColDef: [
        { headerName: 'Job Type', width: '20%', internalName: 'jobType', sort: true, type: "" },
        { headerName: 'JobHour', width: '10%', internalName: 'jobHour', sort: true, type: "" },
        { headerName: 'ContractType', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
        { headerName: 'Contract StartDate', width: '15%', internalName: 'contractStartDate', sort: true, type: "" },
        { headerName: 'Contract EndDate', width: '10%', internalName: 'contractEndDate', sort: true, type: "" },
        { headerName: 'CompanyName', width: '10%', internalName: 'companyName', sort: true, type: "" },
        { headerName: 'VATNo', width: '20%', internalName: 'vatNo', sort: true, type: "" },
        { headerName: 'Legal Company Address', width: '10%', internalName: 'legalCompanyAddress', sort: true, type: "" },
        { headerName: 'Office Address', width: '10%', internalName: 'officeAddress', sort: true, type: "" },
        { headerName: 'Branch Address', width: '10%', internalName: 'branchAddress', sort: true, type: "" },
        { headerName: 'Chamber Of CommerceRegNo', width: '10%', internalName: 'chamberOfCommerceRegNo', sort: true, type: "" },
        { headerName: 'Chamber OfCommerce CityName', width: '10%', internalName: 'chamberOfCommerceCityName', sort: true, type: "" },
        { headerName: 'REANo', width: '10%', internalName: 'reaNo', sort: true, type: "" },
        { headerName: 'ATECONo', width: '10%', internalName: 'atecoNo', sort: true, type: "" },
        { headerName: 'SCIANo', width: '10%', internalName: 'sciaNo', sort: true, type: "" },
        { headerName: 'SCIA CityName', width: '10%', internalName: 'sciaCityName', sort: true, type: "" },
        { headerName: 'IsShareHolder', width: '10%', internalName: 'isShareHolder', sort: true, type: "" },
        { headerName: 'Percentage of Share', width: '10%', internalName: 'percentageOfShare', sort: true, type: "" },
        { headerName: 'Notaio Info', width: '10%', internalName: 'notaioInfo', sort: true, type: "" },
        { headerName: 'Company Representative', width: '10%', internalName: 'companyRepresentative', sort: true, type: "" },
        { headerName: 'Details', width: '15%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },
      ],
      enabledSearch: true,
      enabledSerialNo: true,
      pageSize: 15,
      enabledPagination: false,
      enabledAutoScrolled: true,
      // enabledEditDeleteBtn: true,
      enabledEditDeleteBtn: true,
      //enabledDeleteBtn: true,
      enabledCellClick: true,
      enabledColumnFilter: true,
      enabledDataLength: true,
      enabledColumnResize: true,
      enabledReflow: true,
      enabledPdfDownload: true,
      enabledExcelDownload: true,
      enabledPrint: true,
      enabledColumnSetting: true,
      enabledRecordCreateBtn: true,
      enabledTotal: true,
      //enabledCheckbox:true,
      enabledRadioBtn: false,
      tableHeaderVisibility: true,
      // tableFooterVisibility:false,
      pTableStyle: {
        tableOverflowY: true,
        overflowContentHeight: '460px'
      }
    }
  }

  onEditBasicInfo() {
    this.router.navigate([`/client-profile/basic-info/${this.basicInfo.profileId}`]);
  }

  loadBasicInfo() {
    this.clientProfileService.getCurrentUserBasicInfo().subscribe(res => {
      if (res && res.data.profileId) {
        res.data.dateOfBirth = this.commonService.getFormatedDateToSave(res.data.dateOfBirth);
        res.data.taxCodeStartDate = this.commonService.getFormatedDateToSave(res.data.taxCodeStartDate);
        res.data.taxCodeEndDate = this.commonService.getFormatedDateToSave(res.data.taxCodeEndDate);
        res.data.expectedBabyBirthDate = this.commonService.getFormatedDateToSave(res.data.expectedBabyBirthDate);
        res.data.unEmployedCertificateIssuesDate = this.commonService.getFormatedDateToSave(res.data.unEmployedCertificateIssuesDate);
        this.basicInfo = res.data;

        this.getOccupationInfos();
      }
    }, (error: any) => {
      console.log(error)
    });
  }

  fnPtableCellClick(event) {
    console.log("cell click: ", event);
  }

  fnCustomrTrigger(event) {
    if (event.action == "new-record") {
      this.router.navigate([`/client-profile/occupation/${this.basicInfo.profileId}/0`]);
    } else if (event.action == "edit-item") {
      this.router.navigate([`/client-profile/occupation/${this.basicInfo.profileId}/${event.record.occupationInfoId}`]);
    }
  }

  getOccupationInfos() {
    this.occupationService.getOccupationInfo(this.basicInfo.profileId).subscribe(
      (success) => {
        for (let i = 0; i < success.data.length; i++) {
          success.data[i].contractStartDate = this.commonService.getDateToSetForm(success.data[i].contractStartDate);
          success.data[i].contractEndDate = this.commonService.getDateToSetForm(success.data[i].contractEndDate);
        }
        this.occupationInfoList = success.data;
      }, error => {
      });
  }
}