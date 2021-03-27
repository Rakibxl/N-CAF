import { Component, Input, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profAssetInfo } from '../../../Shared/Entity/ClientProfile/profAssetInfo';
import { AssetInfoService } from '../../../Shared/Services/ClientProfile/asset-info.service';
import { CommonService } from '../../../Shared/Services/Common/common.service';

@Component({
  selector: 'app-asset-information',
  templateUrl: './asset-information.component.html',
  styleUrls: ['./asset-information.component.css']
})
export class AssetInformationComponent implements OnInit {
    @Input() profileIdInput: number= 0;
    constructor(private router: Router, private assetService: AssetInfoService, private commonService: CommonService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        debugger;
        if (this.profileIdInput > 0) { // check the input value if not available then chekc the param
            this.profileId = this.profileIdInput;
            this.ptableSettings.enabledDeleteBtn = false;
            this.ptableSettings.enabledPdfDownload = false;
            this.ptableSettings.enabledExcelDownload = false;


        } else {
            this.profileId=(+this.route.snapshot.paramMap.get("profId") || 0);
        } 


        if (this.profileId == 0) {
            this.router.navigate(['/dashboard/common']);
        }
        this.getAssetInfos();
    }

    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        if (event.action == "new-record") {
            this.router.navigate([`/client-profile/asset-info/${this.profileId}/0`]);
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/asset-info/0']);
            this.router.navigate([`/client-profile/asset-info/${this.profileId}/${event.record.assetInfoId}`]);
        }
    }

    public getAssetInfos() {
        debugger;
        this.assetService.getAssetInfo(this.profileId).subscribe(
            (success) => {
                console.log(" success.data::", success.data);
                this.assetInfoList = success.data;
                this.assetInfoList.forEach(x => {
                    x.assetTypeName = x.assetType.assetTypeName || "";
                    x.ownerTypeName = x.ownerType.ownerTypeName || "";
                    x.ownerFromDate = this.commonService.getDateToSetForm(x.ownerFromDate);
                })    

                console.log("get asset: ", success);
               
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Asset List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Asset Type', width: '7%', internalName: 'assetTypeName', sort: true, type: "" },
            { headerName: 'Number Of Asset', width: '7%', internalName: 'numberOfAsset', sort: true, type: "" },
            { headerName: 'Equivalent Money Max', width: '7%', internalName: 'equivalentMoneyMax', sort: true, type: "", visible: false },
            { headerName: 'Equivalent Money Min', width: '7%', internalName: 'equivalentMoneyMin', sort: true, type: "", visible: false },
            { headerName: 'Money Average', width: '7%', internalName: 'moneyAverage', sort: true, type: "", visible: false },
            { headerName: 'Owner Type', width: '7%', internalName: 'ownerTypeName', sort: true, type: "" },
            { headerName: 'Owner Ship Percentage', width: '10%', internalName: 'ownershipPercentage', sort: true, type: "" },
            { headerName: 'Owner From Date', width: '7%', internalName: 'ownerFromDate', sort: true, type: "" },
            { headerName: 'Rent Amount', width: '10%', internalName: 'rentAmount', sort: true, type: "", visible: false },
            { headerName: 'Tax Amount', width: '10%', internalName: 'taxAmount', sort: true, type: "", visible: false },
            { headerName: 'Use-able Percentage', width: '10%', internalName: 'useAblePercentage', sort: true, type: "", visible: false },
            { headerName: 'Any Restriction ByGovt', width: '10%', internalName: 'anyRestrictionByGovt', sort: true, type: "", visible: false },
            { headerName: 'City Name', width: '10%', internalName: 'cityName', sort: true, type: "", visible: false },
            { headerName: 'Note', width: '10%', internalName: 'note', sort: true, type: ""},
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

    public assetInfoList = [
        
    ];

}
