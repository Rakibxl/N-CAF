import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-educational-information',
  templateUrl: './educational-information.component.html',
  styleUrls: ['./educational-information.component.css']
})
export class EducationalInformationComponent implements OnInit {

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
            this.router.navigate(['/client-profile/education/0']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/education/0']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Education List',
        tableRowIDInternalName: "assetinfoid",
        tableColDef: [
            { headerName: 'Education Id', width: '10%', internalName: 'assetinfoid', sort: true, type: "" },
            { headerName: 'Degree Name', width: '20%', internalName: 'assettype', sort: true, type: "" },
            { headerName: 'Inistitution Name', width: '10%', internalName: 'numberofasset', sort: true, type: "" },
            { headerName: 'Start Year', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'End Year', width: '15%', internalName: 'equivalentmoneymax', sort: true, type: "" },
            { headerName: 'University Address', width: '10%', internalName: 'equivalentmoneymin', sort: true, type: "" },
            { headerName: 'Activities and societies', width: '10%', internalName: 'moneyaverage', sort: true, type: "" },
            { headerName: 'Result', width: '20%', internalName: 'ownertype', sort: true, type: "" },            
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
        { assetinfoid: "AD-120", assettype: "Bachelor In Science", numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-121", assettype: "Masters",             numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-122", assettype: "Masters",             numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-123", assettype: "Masters",             numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-124", assettype: "Masters",             numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-125", assettype: "Masters",             numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-126", assettype: "Masters",             numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-127", assettype: "Bachelor In Science ",numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-128", assettype: "Bachelor In Science", numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-129", assettype: "Bachelor In Science", numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Bachelor In Science", numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-130", assettype: "Bachelor In Science", numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-131", assettype: "Bachelor In Science", numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-132", assettype: "Bachelor In Science", numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-133", assettype: "Masters",             numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-134", assettype: "Bachelor In Science", numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-135", assettype: "Bachelor In Science", numberofasset: "Milano politecnico",  roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-136", assettype: "Masters",             numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-137", assettype: "Masters",             numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-138", assettype: "Bachelor In Science", numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-139", assettype: "Bachelor In Science", numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-140", assettype: "Masters",             numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-151", assettype: "Bachelor In Science", numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-152", assettype: "Bachelor In Science", numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-153", assettype: "Masters",             numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-154", assettype: "Bachelor In Science", numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { assetinfoid: "AD-155", assettype: "Bachelor In Science", numberofasset: "University Of Milan", roadnumber: "10/7/2018", equivalentmoneymax: "10/7/2021", equivalentmoneymin: "Milan", moneyaverage: "Sports", ownertype: "First Division", ownershippercentage: "55%", rentamount: "550", taxamount: "22%", useablepercentage: "22%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];

}
