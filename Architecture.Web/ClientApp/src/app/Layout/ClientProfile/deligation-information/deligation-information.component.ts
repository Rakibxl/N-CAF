import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-deligation-information',
  templateUrl: './deligation-information.component.html',
  styleUrls: ['./deligation-information.component.css']
})
export class DeligationInformationComponent implements OnInit {

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
            this.router.navigate(['/client-profile/deligation-info-new']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/deligation-info-new']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Delegation List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Delegation Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Name', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Sur Name', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'Date Of Birth', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'TaxCode', width: '15%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'Purpose', width: '10%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'Document Name', width: '10%', internalName: 'moneyaverage', sort: true, type: "" },
            { headerName: 'Document Issue Date', width: '20%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Expiry Date', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Issued By', width: '10%', internalName: 'rentamount', sort: true, type: "" },
            { headerName: 'Status', width: '10%', internalName: 'taxamount', sort: true, type: "" },        
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
        { assetinfoid: "AD-120", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno",            moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "AK ", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/7/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Mustafiz", numberofasset: "Rahman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Mustafiz", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "AK", numberofasset: "Zaman", roadnumber: "10/07/1982", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "Renewal Permesso di soggiorno", moneyaverage: "Resident Card", ownertype: "10/9/2020", ownershippercentage: "10/9/2020", rentamount: "Admin", taxamount: "Active", useablepercentage: "Active", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];

}
