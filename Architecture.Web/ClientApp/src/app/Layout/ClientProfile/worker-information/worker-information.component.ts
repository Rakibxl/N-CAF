import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-worker-information',
  templateUrl: './worker-information.component.html',
  styleUrls: ['./worker-information.component.css']
})
export class WorkerInformationComponent implements OnInit {

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
            this.router.navigate(['/client-profile/worker-info/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/worker-info/0']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Worker List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Worker Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Worker Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Name', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'SurName', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'TaxCode', width: '15%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'Contract Number', width: '10%', internalName: 'rentamount', sort: true, type: "" },
            { headerName: 'Monthly Salary', width: '10%', internalName: 'useablepercentage', sort: true, type: "" },
            { headerName: 'Start Date', width: '20%', internalName: 'anyrestrictionbygovt', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'anyrestrictionbygovt', sort: true, type: "" },
            { headerName: 'Status', width: '10%', internalName: 'note', sort: true, type: "" },           
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
        { assetinfoid: "AD-120", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-127", assettype: "Company Worker ", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-128", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-129", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-130", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-132", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-134", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-135", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-138", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-139", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-151", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-152", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Domestic Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-154", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
        { assetinfoid: "AD-155", assettype: "Company Worker", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian", ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "1450", useablepercentage: "1450", anyrestrictionbygovt: "20/10/2020", cityname: "Como", note: "Active", details: "More.." },
    ];

}
