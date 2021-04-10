import { Component, Input, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profHouseRentInfo } from '../../../Shared/Entity/ClientProfile/profHouseRentInfo';
import { HouseRentInfoService } from '../../../Shared/Services/ClientProfile/houserent-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-house-rent-information',
  templateUrl: './house-rent-information.component.html',
  styleUrls: ['./house-rent-information.component.css']
})
export class HouseRentInformationComponent implements OnInit {
    @Input() parentProfileId: number = 0;
    constructor(private router: Router, private houseRentService: HouseRentInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        if (this.parentProfileId > 0) { // check the input value if not available then chekc the param
            this.profileId = this.parentProfileId;
            this.ptableSettings.enabledEditDeleteBtn = false;
            this.ptableSettings.enabledEditBtn = true;
            this.ptableSettings.enabledPdfDownload = false;
            this.ptableSettings.enabledExcelDownload = false;
            this.ptableSettings.enabledPrint = false;
            this.ptableSettings.enabledColumnSetting = false;
        } else {
            this.profileId = (+this.route.snapshot.paramMap.get("profId") || 0);
        } 


        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getHouseRentInfos();
  }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
           
            this.router.navigate([`/client-profile/house-rent/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
           
            this.router.navigate([`/client-profile/house-rent/${this.profileId}/${event.record.houseRentInfoId}`]);
        }
    }

    public getHouseRentInfos() {
       
        this.houseRentService.getHouseRentInfo(this.profileId).subscribe(
            (success) => {
                this.houseRentInfoList = success.data;
                this.houseRentInfoList.forEach(x => {
                    x.contractTypeName = (x.contractType ? x.contractType.contractTypeName:"") || "";
                    x.houseTypeName = (x.houseType ? x.houseType.houseTypeName:"") || "";
                    x.houseCategoryName = (x.houseCategory ? x.houseCategory.houseCategoryName:"") || "";
                    x.loanStatusTypeName = (x.loanStatusType ? x.loanStatusType.loanStatusTypeName:"") || "";
                    x.loanInterestTypeName = (x.loanInterestType ? x.loanInterestType.loanInterestTypeName:"") || "";
                    x.contractDate = this.commonService.getDateToSetForm(x.contractDate);
                    x.startDate = this.commonService.getDateToSetForm(x.startDate);
                    x.endDate = this.commonService.getDateToSetForm(x.endDate);
                    x.loanStartDate = this.commonService.getDateToSetForm(x.loanStartDate);
                    x.registrationDate = this.commonService.getDateToSetForm(x.registrationDate);
                })    

            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'House Rent List',
        tableRowIDInternalName: "houserentinfoid",
        tableColDef: [
            { headerName: 'House Type', width: '5%', internalName: 'houseTypeName', sort: true, type: "" },
            { headerName: 'Contract Type', width: '5%', internalName: 'contractTypeName', sort: true, type: "" },
            { headerName: 'Contract Date', width: '5%', internalName: 'contractDate', sort: true, type: "" },
            { headerName: 'Start Date', width: '5%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '5%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'Monthly Rent Amount', width: '5%', internalName: 'monthlyRentAmount', sort: true, type: "", displayType:"number" },
            { headerName: 'Service Charge Amount', width: '5%', internalName: 'serviceChargeAmount', sort: true, type: "", displayType: "number"},
            { headerName: 'Registration Info', width: '10%', internalName: 'registrationInfo', sort: true, type: "", visible: false },
            { headerName: 'Registration Date', width: '10%', internalName: 'registrationDate', sort: true, type: "", visible: false },
            { headerName: 'Registration Office', width: '10%', internalName: 'registrationOffice', sort: true, type: "", visible: false },
            { headerName: 'Registration Code', width: '10%', internalName: 'registrationCode', sort: true, type: "", visible: false },
            { headerName: 'Registration No', width: '10%', internalName: 'registrationNo', sort: true, type: "", visible: false },
            { headerName: 'Registration City', width: '10%', internalName: 'registrationCity', sort: true, type: "", visible: false },
            { headerName: 'Is Joined', width: '10%', internalName: 'isJoined', sort: true, type: "", visible: false },
            { headerName: 'Share Percent', width: '10%', internalName: 'sharePercent', sort: true, type: "", visible: false },
            { headerName: 'Foglio No', width: '10%', internalName: 'foglioNo', sort: true, type: "", visible: false },
            { headerName: 'Partiocella No', width: '10%', internalName: 'partiocellaNo', sort: true, type: "", visible: false },
            { headerName: 'Sub No', width: '10%', internalName: 'subNo', sort: true, type: "" ,visible: false},
            { headerName: 'Section No', width: '10%', internalName: 'sectionNo', sort: true, type: "", visible: false },
            { headerName: 'House Category', width: '10%', internalName: 'houseCategoryName', sort: true, type: "", visible: false },
            { headerName: 'Zona No', width: '10%', internalName: 'zona', sort: true, type: "", visible: false},
            { headerName: 'Micro Zona', width: '10%', internalName: 'microZona', sort: true, type: "", visible: false},
            { headerName: 'Consistenza', width: '10%', internalName: 'consistenza', sort: true, type: "", visible: false},
            { headerName: 'Super Ficie Catastale', width: '10%', internalName: 'superficieCatastale', sort: true, type: "", visible: false},
            { headerName: 'Rendita', width: '10%', internalName: 'rendita', sort: true, type: "", visible: false},
            { headerName: 'Notaio Info', width: '10%', internalName: 'notaioInfo', sort: true, type: "", visible: false},
            { headerName: 'Has Loan', width: '10%', internalName: 'hasLoan', sort: true, type: "", visible: false},
            { headerName: 'Loan Status', width: '10%', internalName: 'loanStatusTypeName', sort: true, type: "", visible: false},
            { headerName: 'Loan Start Date', width: '10%', internalName: 'loanStartDate', sort: true, type: "", visible: false},
            { headerName: 'Loan Amount', width: '10%', internalName: 'loanAmount', sort: true, type: "", visible: false},
            { headerName: 'Paid Amount', width: '10%', internalName: 'paidAmount', sort: true, type: "", visible: false},
            { headerName: 'Interest Type', width: '10%', internalName: 'loanInterestTypeName', sort: true, type: "", visible: false},
            { headerName: 'Loan Period', width: '10%', internalName: 'loanPeriod', sort: true, type: "", visible: false},
            { headerName: 'Is RentByOwner', width: '10%', internalName: 'isRentByOwner', sort: true, type: "", visible: false},
            { headerName: 'RentAmount', width: '10%', internalName: 'rentAmount', sort: true, type: "", visible: false},
            //{ headerName: 'Details', width: '7%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 15,
        enabledPagination: true,
        enabledEditDeleteBtn: true,
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
        enabledViewDetails: true

    };

    public houseRentInfoList = [];

}
