import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-house-rent-information',
  templateUrl: './house-rent-information.component.html',
  styleUrls: ['./house-rent-information.component.css']
})
export class HouseRentInformationComponent implements OnInit {

  constructor(private router:Router) { }

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
            this.router.navigate(['/client-profile/house-rent-new']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/house-rent-new']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'House Rent List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'House Rent Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Contract Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'House Type', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'Start Date', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'End Date', width: '15%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'Monthly Rent Amount', width: '10%', internalName: 'rentamount', sort: true, type: "" },
            { headerName: 'Service Charge Amount', width: '10%', internalName: 'rentamount', sort: true, type: "" },
            { headerName: 'Registration Info', width: '20%', internalName: 'note', sort: true, type: "" },
            { headerName: 'Registration Date', width: '10%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'Registration Office', width: '10%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'Registration Code', width: '10%', internalName: 'moneyaverage', sort: true, type: "" },
            { headerName: 'Registration No', width: '10%', internalName: 'ownertype', sort: true, type: "" },
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
        { assetinfoid: "AD-120", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "Limited ",     numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043",ownershippercentage:"20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020",    equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage:    "20/07/2019", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Unlimited",    numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "Limited",      numberofasset: "Owner", roadnumber: "20/07/2018", equivalentmoneymax: "20/7/2020", equivalentmoneymin: "Milan", moneyaverage: "HR0432", ownertype: "RN043", ownershippercentage: "20/072020", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];

}
