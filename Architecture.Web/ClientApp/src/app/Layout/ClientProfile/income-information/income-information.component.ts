import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-income-information',
  templateUrl: './income-information.component.html',
  styleUrls: ['./income-information.component.css']
})
export class IncomeInformationComponent implements OnInit {

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
            this.router.navigate(['/client-profile/income-info/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/income-info/0']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Income List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Income Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Income Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Yearly Income', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'Montly Income', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'Year', width: '15%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'Month', width: '10%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'Document', width: '10%', internalName: 'moneyaverage', sort: true, type: "" },
            { headerName: 'Status', width: '20%', internalName: 'ownertype', sort: true, type: "" },
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
        { assetinfoid: "AD-120", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "Single Income ", numberofasset: "25000", roadnumber:"1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Double Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "Single Income", numberofasset: "25000", roadnumber: "1400", equivalentmoneymax: "2020", equivalentmoneymin: "July", moneyaverage: "Pay Slip", ownertype: "Active", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];


}
