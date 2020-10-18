import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';
import { ProfFamilyInfo } from '../../../Shared/Entity/ClientProfile/profFamilyInfo';

@Component({
  selector: 'app-family-information',
  templateUrl: './family-information.component.html',
  styleUrls: ['./family-information.component.css']
})
export class FamilyInformationComponent implements OnInit {
    public familyInfos: ProfFamilyInfo[] = [];
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
            this.router.navigate(['/client-profile/family-info/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/family-info/0']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Family List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Family Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Relation Type', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Name', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'SurName', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'TaxCode', width: '15%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'Date Of Birth', width: '10%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'Place Of Birth', width: '10%', internalName: 'moneyaverage', sort: true, type: "" },
            { headerName: 'Phone Number', width: '20%', internalName: 'rentamount', sort: true, type: "" },
            { headerName: 'Nationality', width: '10%', internalName: 'ownertype', sort: true, type: "" },
            { headerName: 'Residence', width: '10%', internalName: 'ownershippercentage', sort: true, type: "" },
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
        { assetinfoid: "AD-120", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "Wife ",numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Bangladeshi", ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Italy",        rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Son",  numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "Wife", numberofasset: "Rakib", roadnumber: "Ahmed", equivalentmoneymax: "MRTMTT25D09F205Z", equivalentmoneymin: "07/05/1992", moneyaverage: "Milan", ownertype: "Italian",     ownershippercentage: "Out Of Italy", rentamount: "3896883996", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];

}
