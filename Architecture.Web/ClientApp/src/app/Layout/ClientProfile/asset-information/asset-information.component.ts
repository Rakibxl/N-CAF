import { Component, OnInit } from '@angular/core';
import { Router,ActivatedRoute } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { profAssetInfo } from '../../../Shared/Entity/ClientProfile/profAssetInfo';
import { AssetInfoService } from '../../../Shared/Services/ClientProfile/asset-info.service';

@Component({
  selector: 'app-asset-information',
  templateUrl: './asset-information.component.html',
  styleUrls: ['./asset-information.component.css']
})
export class AssetInformationComponent implements OnInit {

    constructor(private router: Router, private assetService: AssetInfoService, private route: ActivatedRoute) { }
    private profileId: number;
    ngOnInit() {
        this.profileId = +this.route.snapshot.paramMap.get("profId") || 2;
        debugger;
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
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate([`/client-profile/asset-info/${this.profileId}/0`]);
            debugger
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
                console.log("get asset: ", success);
                this.assetInfoList = success.data;
            },
            error => {
            });

    }

    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Asset List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            //{ headerName: 'Asset Id', width: '7%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Asset Type', width: '7%', internalName: 'assetType', sort: true, type: "" },
            { headerName: 'Number Of Asset', width: '7%', internalName: 'numberOfAsset', sort: true, type: "" },
            { headerName: 'Equivalent Money Max', width: '7%', internalName: 'equivalentMoneyMax', sort: true, type: "" },
            { headerName: 'Equivalent Money Min', width: '7%', internalName: 'equivalentMoneyMin', sort: true, type: "" },
            { headerName: 'Money Average', width: '7%', internalName: 'moneyAverage', sort: true, type: "" },
            //{ headerName: 'Owner Type', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Owner Ship Percentage', width: '10%', internalName: 'ownershipPercentage', sort: true, type: "" },
            { headerName: 'Owner From Date', width: '10%', internalName: 'ownerFromDate', sort: true, type: "" },
            { headerName: 'Rent Amount', width: '10%', internalName: 'rentAmount', sort: true, type: "" },
            { headerName: 'Tax Amount', width: '10%', internalName: 'taxAmount', sort: true, type: "" },
            { headerName: 'Use-able Percentage', width: '10%', internalName: 'useAblePercentage', sort: true, type: "" },
            { headerName: 'Any Restriction ByGovt', width: '10%', internalName: 'anyRestrictionByGovt', sort: true, type: "" },
            { headerName: 'City Name', width: '10%', internalName: 'cityName', sort: true, type: "" },
            { headerName: 'Note', width: '10%', internalName: 'note', sort: true, type: "" },
            { headerName: 'Details', width: '10%', internalName: 'details', sort: true, type: "button", onClick: 'true', innerBtnIcon: "fa fa-copy" },

        ],
        enabledSearch: true,
        enabledSerialNo: true,
        pageSize: 15,
        enabledPagination: true,
       //enabledAutoScrolled: true,
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

    public assetInfoList = [
        
    ];

}
