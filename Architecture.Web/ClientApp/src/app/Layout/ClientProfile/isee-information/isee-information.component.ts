import { Component, OnInit } from '@angular/core';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { Router } from '@angular/router';

@Component({
  selector: 'app-isee-information',
  templateUrl: './isee-information.component.html',
  styleUrls: ['./isee-information.component.css']
})
export class IseeInformationComponent implements OnInit {

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
            this.router.navigate(['/client-profile/isee-info/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/isee-info/0']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Isee List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Isee Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Isee Class', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'IseeValue', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'Point', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'IseeFamilyIncome', width: '15%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'IspAmount', width: '10%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'ISE Amount', width: '10%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'ISR Amount', width: '20%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'IdnetificationNumber', width: '10%', internalName: 'moneyaverage', sort: true, type: "" },
            { headerName: 'Sumitted Date', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Delivery Date', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Expiry Date', width: '10%', internalName: 'ownertype', sort: true, type: "" },
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
        { assetinfoid: "AD-120", assettype: "High", numberofasset: "12000", roadnumber: "6", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Low",  numberofasset: "12000", roadnumber: "7", equivalentmoneymax: "2", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Low",  numberofasset: "12000", roadnumber: "4", equivalentmoneymax: "2", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Low",  numberofasset: "12000", roadnumber: "2", equivalentmoneymax: "2", equivalentmoneymin: "4", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Low",  numberofasset: "12000", roadnumber: "6", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Low",  numberofasset: "12000", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "3", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Low",  numberofasset: "12000", roadnumber: "7", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "High ",numberofasset: "12000", roadnumber: "9", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "High", numberofasset: "12000", roadnumber: "1", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "High", numberofasset: "12000", roadnumber: "2", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "High", numberofasset: "12000", roadnumber: "5", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "High", numberofasset: "12000", roadnumber: "4", equivalentmoneymax: "6", equivalentmoneymin: "3", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "High", numberofasset: "12000", roadnumber: "5", equivalentmoneymax: "6", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "High", numberofasset: "12000", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Low",  numberofasset: "12000", roadnumber: "4", equivalentmoneymax: "7", equivalentmoneymin: "3", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "High", numberofasset: "12000", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "High", numberofasset: "12000", roadnumber: "2", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Low",  numberofasset: "12000", roadnumber: "4", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Low",  numberofasset: "12000", roadnumber: "8", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "High", numberofasset: "12000", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "4", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "High", numberofasset: "12000", roadnumber: "5", equivalentmoneymax: "4", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Low",  numberofasset: "12000", roadnumber: "7", equivalentmoneymax: "4", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "High", numberofasset: "12000", roadnumber: "4", equivalentmoneymax: "4", equivalentmoneymin: "4", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "High", numberofasset: "12000", roadnumber: "2", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Low",  numberofasset: "12000", roadnumber: "4", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "High", numberofasset: "12000", roadnumber: "6", equivalentmoneymax: "7", equivalentmoneymin: "2", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "High", numberofasset: "12000", roadnumber: "3", equivalentmoneymax: "7", equivalentmoneymin: "3", moneyaverage: "AR3432", ownertype: "20/05/2020", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];


}
