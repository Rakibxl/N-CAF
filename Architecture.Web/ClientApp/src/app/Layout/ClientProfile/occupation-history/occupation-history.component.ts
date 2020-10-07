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
            { headerName: 'Occupation Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Job Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'JobHour', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'ContractType', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'Contract StartDate', width: '15%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'Contract EndDate', width: '10%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'CompanyName', width: '10%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'VATNo', width: '20%', internalName: 'moneyaverage', sort: true, type: "" },
            { headerName: 'Legal Company Address', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Office Address', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Branch Address', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Chamber Of CommerceRegNo', width: '10%', internalName: 'ownershippercentage', sort: true, type: "" },
            { headerName: 'Chamber OfCommerce CityName', width: '10%', internalName: 'cityname', sort: true, type: "" },
            { headerName: 'REANo', width: '10%', internalName: 'ownershippercentage', sort: true, type: "" },
            { headerName: 'ATECONo', width: '10%', internalName: 'ownershippercentage', sort: true, type: "" },
            { headerName: 'SCIANo', width: '10%', internalName: 'ownershippercentage', sort: true, type: "" },
            { headerName: 'SCIA CityName', width: '10%', internalName: 'cityname', sort: true, type: "" },
            { headerName: 'IsShareHolder', width: '10%', internalName: 'anyrestrictionbygovt', sort: true, type: "" },
            { headerName: 'Percentage of Share', width: '10%', internalName: 'useablepercentage', sort: true, type: "" },
            { headerName: 'Notaio Info', width: '10%', internalName: 'note', sort: true, type: "" },
            { headerName: 'Company Representative', width: '10%', internalName: 'note', sort: true, type: "" },
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
        { assetinfoid: "AD-120", assettype: "Full-Time", numberofasset: "2", roadnumber: "Limited", equivalentmoneymax: "20/07/2018", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Part-Time", numberofasset: "2", roadnumber: "Limited", equivalentmoneymax: "20/07/2018", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Part-Time", numberofasset: "3", roadnumber: "Limited", equivalentmoneymax: "20/07/2018", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Part-Time", numberofasset: "1", roadnumber: "Limited", equivalentmoneymax: "20/07/2018", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Part-Time", numberofasset: "2", roadnumber: "Limited", equivalentmoneymax: "20/07/2018", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Part-Time", numberofasset: "2", roadnumber: "Limited", equivalentmoneymax: "20/07/2018", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Part-Time", numberofasset: "1", roadnumber: "Limited", equivalentmoneymax: "20/07/2018", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "Full-Time ", numberofasset: "2", roadnumber: "Limited", equivalentmoneymax: "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "Full-Time", numberofasset: "1", roadnumber: "Limited", equivalentmoneymax:  "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "Full-Time", numberofasset: "3", roadnumber: "Limited", equivalentmoneymax:  "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Full-Time", numberofasset: "1", roadnumber: "Limited", equivalentmoneymax:  "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "Full-Time", numberofasset: "2", roadnumber: "Limited", equivalentmoneymax:  "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Milano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Full-Time", numberofasset: "1", roadnumber: "Limited", equivalentmoneymax:  "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "Full-Time", numberofasset: "2", roadnumber: "Limited", equivalentmoneymax:  "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Part-Time", numberofasset: "1", roadnumber: "Limited", equivalentmoneymax: "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "Full-Time", numberofasset: "3", roadnumber: "Unlimited", equivalentmoneymax: "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "Full-Time", numberofasset: "2", roadnumber: "Unlimited", equivalentmoneymax: "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Part-Time", numberofasset: "1", roadnumber: "Unlimited", equivalentmoneymax: "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Part-Time", numberofasset: "2", roadnumber: "Unlimited", equivalentmoneymax:"10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "Full-Time", numberofasset: "2", roadnumber: "Unlimited", equivalentmoneymax:"10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "Full-Time", numberofasset: "1", roadnumber: "Unlimited", equivalentmoneymax:"10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Part-Time", numberofasset: "3", roadnumber: "Unlimited", equivalentmoneymax:"10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "Full-Time", numberofasset: "2", roadnumber: "Unlimited", equivalentmoneymax:"10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "Full-Time", numberofasset: "1", roadnumber: "Unlimited", equivalentmoneymax:"10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Part-Time", numberofasset: "2", roadnumber: "Unlimited", equivalentmoneymax:"10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "Full-Time", numberofasset: "3", roadnumber: "Unlimited", equivalentmoneymax:"10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "Full-Time", numberofasset: "1", roadnumber: "Unlimited", equivalentmoneymax: "10/06/2020", equivalentmoneymin: "National Caf", moneyaverage: "IT10002045334", ownertype: "Via Toriano", ownershippercentage: "AR3234234", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];

}
