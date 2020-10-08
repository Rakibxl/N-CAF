import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-document-information',
  templateUrl: './document-information.component.html',
  styleUrls: ['./document-information.component.css']
})
export class DocumentInformationComponent implements OnInit {

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
            this.router.navigate(['/client-profile/document-info/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/document-info/0']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Document List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Document Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Document Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Document Name', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'Purpose Of Document', width: '15%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'Issues By', width: '15%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'Issue Date', width: '10%', internalName: 'moneyaverage', sort: true, type: "" },
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
        { assetinfoid: "AD-120", assettype: "Personal", numberofasset: "Resident Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Business", numberofasset: "Resident Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Business", numberofasset: "Resident Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Business", numberofasset: "Resident Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Business", numberofasset: "Resident Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Business", numberofasset: "Resident Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Business", numberofasset: "Resident Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "Personal ", numberofasset:"Identiy Card", roadnumber: "Personal", equivalentmoneymax:  "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "Personal", numberofasset: "Identity Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "Personal", numberofasset: "Identity Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Personal", numberofasset: "Identity Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "Personal", numberofasset: "Identity Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Personal", numberofasset: "Identity Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "Personal", numberofasset: "Identity Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Business", numberofasset: "Identity Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "Personal", numberofasset: "Identity Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "Personal", numberofasset: "Identity Card", roadnumber: "Personal", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Business", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Business", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "Personal", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "Personal", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Business", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "Personal", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "Personal", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Business", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "Personal", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "Personal", numberofasset: "Codice Fiscale", roadnumber: "Buiness", equivalentmoneymax: "Admin", equivalentmoneymin: "10/07/2020", moneyaverage: "10/07/2020", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];

}
