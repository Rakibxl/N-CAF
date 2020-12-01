import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profHouseRentInfo } from '../../../Shared/Entity/ClientProfile/profHouseRentInfo';
import { HouseRentInfoService } from '../../../Shared/Services/ClientProfile/houserent-info.service';

@Component({
  selector: 'app-house-rent-information',
  templateUrl: './house-rent-information.component.html',
  styleUrls: ['./house-rent-information.component.css']
})
export class HouseRentInformationComponent implements OnInit {

    constructor(private router: Router, private houseRentService: HouseRentInfoService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 0;
        debugger;
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
            debugger;
            this.router.navigate([`/client-profile/house-rent/${this.profileId}/0`]);
            debugger
        }
        else if (event.action == "edit-item") {
            debugger;
            this.router.navigate([`/client-profile/house-rent/${this.profileId}/${event.record.houseRentInfoId}`]);
        }
    }

    public getHouseRentInfos() {
        debugger;
        this.houseRentService.getHouseRentInfo(this.profileId).subscribe(
            (success) => {
                console.log("get address: ", success);
                this.houseRentInfoList = success.data;
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'House Rent List',
        tableRowIDInternalName: "houserentinfoid",
        tableColDef: [
            { headerName: 'Contract Type', width: '20%', internalName: 'contractType', sort: true, type: "" },
            { headerName: 'Contract Date', width: '15%', internalName: 'contractDate', sort: true, type: "" },
            { headerName: 'Start Date', width: '15%', internalName: 'startDate', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'endDate', sort: true, type: "" },
            { headerName: 'Monthly Rent Amount', width: '10%', internalName: 'monthlyRentAmount', sort: true, type: "" },
            { headerName: 'Service Charge Amount', width: '20%', internalName: 'serviceChargeAmount', sort: true, type: "" },
            { headerName: 'Registration Info', width: '10%', internalName: 'registrationInfo', sort: true, type: "" },
            { headerName: 'Registration Date', width: '10%', internalName: 'registrationDate', sort: true, type: "" },
            { headerName: 'Registration Office', width: '10%', internalName: 'registrationOffice', sort: true, type: "" },
            { headerName: 'Registration Code', width: '10%', internalName: 'registrationCode', sort: true, type: "" },
            { headerName: 'Registration No', width: '10%', internalName: 'registrationNo', sort: true, type: "" },
            { headerName: 'Registration City', width: '10%', internalName: 'registrationCity', sort: true, type: "" },
            { headerName: 'Is Joined', width: '10%', internalName: 'isJoined', sort: true, type: "" },
            { headerName: 'Share Percent', width: '10%', internalName: 'sharePercent', sort: true, type: "" },
            { headerName: 'Foglio No', width: '10%', internalName: 'foglioNo', sort: true, type: "" },
            { headerName: 'Partiocella No', width: '10%', internalName: 'partiocellaNo', sort: true, type: "" },
            { headerName: 'Sub No', width: '10%', internalName: 'subNo', sort: true, type: "" },
            { headerName: 'Section No', width: '10%', internalName: 'sectionNo', sort: true, type: "" },
            { headerName: 'Zona No', width: '10%', internalName: 'zona', sort: true, type: "" },
            { headerName: 'Micro Zona', width: '10%', internalName: 'microZona', sort: true, type: "" },
            { headerName: 'Consistenza', width: '10%', internalName: 'consistenza', sort: true, type: "" },
            { headerName: 'Super Ficie Catastale', width: '10%', internalName: 'superficieCatastale', sort: true, type: "" },
            { headerName: 'Rendita', width: '10%', internalName: 'rendita', sort: true, type: "" },
            { headerName: 'Notaio Info', width: '10%', internalName: 'notaioInfo', sort: true, type: "" },
            { headerName: 'Has Loan', width: '10%', internalName: 'hasLoan', sort: true, type: "" },
            { headerName: 'Loan Start Date', width: '10%', internalName: 'loanStartDate', sort: true, type: "" },
            { headerName: 'Loan Amount', width: '10%', internalName: 'loanAmount', sort: true, type: "" },
            { headerName: 'Paid Amount', width: '10%', internalName: 'paidAmount', sort: true, type: "" },
            { headerName: 'Loan Period', width: '10%', internalName: 'loanPeriod', sort: true, type: "" },
            { headerName: 'Is RentByOwner', width: '10%', internalName: 'isRentByOwner', sort: true, type: "" },
            { headerName: 'RentAmount', width: '10%', internalName: 'rentAmount', sort: true, type: "" },
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
    };

    public houseRentInfoList = [];

}
