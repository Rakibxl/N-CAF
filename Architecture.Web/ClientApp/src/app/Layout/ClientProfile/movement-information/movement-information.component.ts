import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-movement-information',
  templateUrl: './movement-information.component.html',
  styleUrls: ['./movement-information.component.css']
})
export class MovementInformationComponent implements OnInit {

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
            this.router.navigate(['/client-profile/movement-info/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/movement-info/0']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Movement List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Movement Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Country Name', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Start Date', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'End Date', width: '15%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'Purpose', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'Status', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            //{ headerName: 'Owner Type', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            //{ headerName: 'Owner Ship Percentage', width: '20%', internalName: 'ownershippercentage', sort: true, type: "" },
            //{ headerName: 'Owner From Date', width: '10%', internalName: 'rentamount', sort: true, type: "" },
            //{ headerName: 'Rent Amount', width: '10%', internalName: 'rentamount', sort: true, type: "" },
            //{ headerName: 'Tax Amount', width: '10%', internalName: 'taxamount', sort: true, type: "" },
            //{ headerName: 'Use-able Percentage', width: '10%', internalName: 'useablepercentage', sort: true, type: "" },
            //{ headerName: 'Any Restriction ByGovt', width: '10%', internalName: 'anyrestrictionbygovt', sort: true, type: "" },
            //{ headerName: 'City Name', width: '10%', internalName: 'cityname', sort: true, type: "" },
            //{ headerName: 'Note', width: '10%', internalName: 'note', sort: true, type: "" },
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
        { assetinfoid: "AD-120", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "Italy ", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Bangladesh", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "Italy", numberofasset: "20-09-2020", roadnumber: "Visit", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];

}
