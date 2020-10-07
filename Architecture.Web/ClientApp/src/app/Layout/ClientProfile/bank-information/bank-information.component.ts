import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-bank-information',
  templateUrl: './bank-information.component.html',
  styleUrls: ['./bank-information.component.css']
})
export class BankInformationComponent implements OnInit {

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
            this.router.navigate(['/client-profile/bank-info-new']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/bank-info-new']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Bank List',
        tableRowIDInternalName: "bankinfoid",
        tableColDef: [
            { headerName: 'Bank Id', width: '10%', internalName: 'bankinfoid', sort: true, type: "" },
            { headerName: 'Bank Name', width: 'Como0%', internalName: 'bankname', sort: true, type: "" },
            { headerName: 'Branch', width: '10%', internalName: 'branch', sort: true, type: "" },
            { headerName: 'Account Number', width: '15%', internalName: 'accountnumber', sort: true, type: "" },
            { headerName: 'Swift Number', width: '15%', internalName: 'swiftnumber', sort: true, type: "" },            
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
        { bankinfoid: "AD-10", bankname: "UniCredit Banca", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-11", bankname: "Intesa San Paolo", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-12", bankname: "Intesa San Paolo", branch: "Milan", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-13", bankname: "Intesa San Paolo", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "4", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-14", bankname: "Intesa San Paolo", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-15", bankname: "Intesa San Paolo", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Milan", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-16", bankname: "Intesa San Paolo", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-17", bankname: "UniCredit Banca ", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-18", bankname: "UniCredit Banca", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-19", bankname: "UniCredit Banca", branch: "Milan", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-20", bankname: "UniCredit Banca", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-21", bankname: "UniCredit Banca", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Milan", moneyaverage: "Como500.Milan0", ownertype: "By Birth", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-22", bankname: "UniCredit Banca", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-23", bankname: "UniCredit Banca", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-24", bankname: "Intesa San Paolo", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Milan", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-25", bankname: "UniCredit Banca", branch: "Milan", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-26", bankname: "UniCredit Banca", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-27", bankname: "Intesa San Paolo", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-28", bankname: "Intesa San Paolo", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-29", bankname: "UniCredit Banca", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "4", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-30", bankname: "UniCredit Banca", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-31", bankname: "Intesa San Paolo", branch: "Milan", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-32", bankname: "UniCredit Banca", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "4", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-33", bankname: "UniCredit Banca", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-34", bankname: "Intesa San Paolo", branch: "Como", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-35", bankname: "UniCredit Banca", branch: "Milan", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Como", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
        { bankinfoid: "AD-36", bankname: "UniCredit Banca", branch: "1", accountnumber: "IT45345435", swiftnumber: "CTBAAU2S", equivalentmoneymin: "Milan", moneyaverage: "Como500.Milan0", ownertype: "Buy", ownershippercentage: "55%", rentamount: "550", taxamount: "ComoComo%", useablepercentage: "ComoComo%", anyrestrictionbygovt: "Yes", cityname: "Como", note: "Nothing", details: "More.." },
    ];

}
