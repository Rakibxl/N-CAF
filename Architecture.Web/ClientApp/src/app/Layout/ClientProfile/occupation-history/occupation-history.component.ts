import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-occupation-history',
  templateUrl: './occupation-history.component.html',
  styleUrls: ['./occupation-history.component.css']
})
export class OccupationHistoryComponent implements OnInit {

    constructor(private router: Router) { }

  ngOnInit() {
    }


    public fnPtableCellClick(event) {
        console.log("cell click: ", event);
    }

    public fnCustomrTrigger(event) {
        console.log("custom  click: ", event);
        let id = 0;
        if (event.action == "new-record") {
            debugger;
            this.router.navigate(['/client-profile/occupation/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/occupation/0']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Occupation List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Asset Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Asset Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Number Of Asset', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'Equivalent Money Max', width: '15%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'Equivalent Money Min', width: '15%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'Money Average', width: '10%', internalName: 'moneyaverage', sort: true, type: "" },
            { headerName: 'Owner Type', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Owner Ship Percentage', width: '20%', internalName: 'ownershippercentage', sort: true, type: "" },
            { headerName: 'Owner From Date', width: '10%', internalName: 'rentamount', sort: true, type: "" },
            { headerName: 'Rent Amount', width: '10%', internalName: 'rentamount', sort: true, type: "" },
            { headerName: 'Tax Amount', width: '10%', internalName: 'taxamount', sort: true, type: "" },
            { headerName: 'Use-able Percentage', width: '10%', internalName: 'useablepercentage', sort: true, type: "" },
            { headerName: 'Any Restriction ByGovt', width: '10%', internalName: 'anyrestrictionbygovt', sort: true, type: "" },
            { headerName: 'City Name', width: '10%', internalName: 'cityname', sort: true, type: "" },
            { headerName: 'Note', width: '10%', internalName: 'note', sort: true, type: "" },
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

    public employeeList = [
        { assetinfoid: "AD-120", assettype: "House", numberofasset: "2", roadnumber: "6", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Car", numberofasset: "2", roadnumber: "7", equivalentmoneymax: "2", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Car", numberofasset: "3", roadnumber: "4", equivalentmoneymax: "2", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Car", numberofasset: "1", roadnumber: "2", equivalentmoneymax: "2", equivalentmoneymin: "4", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Car", numberofasset: "2", roadnumber: "6", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Car", numberofasset: "2", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "3", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Car", numberofasset: "1", roadnumber: "7", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "House ", numberofasset: "2", roadnumber: "9", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "House", numberofasset: "1", roadnumber: "1", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "House", numberofasset: "3", roadnumber: "2", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "House", numberofasset: "1", roadnumber: "5", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "House", numberofasset: "2", roadnumber: "4", equivalentmoneymax: "6", equivalentmoneymin: "3", moneyaverage: "2500.30", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "House", numberofasset: "1", roadnumber: "5", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "House", numberofasset: "2", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Car", numberofasset: "1", roadnumber: "4", equivalentmoneymax: "7", equivalentmoneymin: "3", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "House", numberofasset: "3", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "House", numberofasset: "2", roadnumber: "2", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Car", numberofasset: "1", roadnumber: "4", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Car", numberofasset: "2", roadnumber: "8", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "House", numberofasset: "2", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "4", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "House", numberofasset: "1", roadnumber: "5", equivalentmoneymax: "4", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Car", numberofasset: "3", roadnumber: "7", equivalentmoneymax: "4", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "House", numberofasset: "2", roadnumber: "4", equivalentmoneymax: "4", equivalentmoneymin: "4", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "House", numberofasset: "1", roadnumber: "2", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Car", numberofasset: "2", roadnumber: "4", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "House", numberofasset: "3", roadnumber: "6", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "House", numberofasset: "1", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "3", moneyaverage: "2500.30", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];

}
