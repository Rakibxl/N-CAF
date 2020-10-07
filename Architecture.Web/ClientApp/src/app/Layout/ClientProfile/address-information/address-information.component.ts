import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPTableSetting } from '../../../Shared/Modules/p-table';

@Component({
  selector: 'app-address-information',
  templateUrl: './address-information.component.html',
  styleUrls: ['./address-information.component.css']
})
export class AddressInformationComponent implements OnInit {

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
            this.router.navigate(['/client-profile/address-new']);
            debugger
        }
        else if (event.action == "edit-item") {
            this.router.navigate(['/client-profile/address-new']);
        }
    }


    public ptableSettings: IPTableSetting = {
        tableClass: "table table-border ",
        tableName: 'Address List',
        tableRowIDInternalName: "userId",
        tableColDef: [
            { headerName: 'Address Id', width: '10%', internalName: 'userId', sort: true, type: "" },
            { headerName: 'AddressType', width: '20%', internalName: 'addresstype', sort: true, type: "" },
            { headerName: 'Road Name ', width: '10%', internalName: 'roadname', sort: true, type: "" },
            { headerName: 'Road Number ', width: '15%', internalName: 'roadnumber', sort: true, type: "" },
            { headerName: 'Building Number', width: '15%', internalName: 'buildingnumber', sort: true, type: "" },
            { headerName: 'Floor Number', width: '10%', internalName: 'floornumber', sort: true, type: "" },
            { headerName: 'Appartment Number', width: '10%', internalName: 'appartmentnumber', sort: true, type: "" },
            { headerName: 'Province', width: '20%', internalName: 'province', sort: true, type: "" },
            { headerName: 'City Name', width: '10%', internalName: 'cityname', sort: true, type: "" },
            { headerName: 'Postal Code', width: '10%', internalName: 'postalcode', sort: true, type: "" },
            { headerName: 'Start Date', width: '10%', internalName: 'startdate', sort: true, type: "" },
            { headerName: 'End Date', width: '10%', internalName: 'enddate', sort: true, type: "" },
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
        { userId: "AD-120", addresstype: "Guest", roadname: "Via Torino", roadnumber: "6", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Milan", cityname: "Milan", postalcode: "22100",        startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-121", addresstype: "Permanent", roadname: "Via Torino", roadnumber: "7", buildingnumber: "2", floornumber: "2", appartmentnumber: "A", province: "Milan", cityname: "Milan", postalcode: "22100",     startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-122", addresstype: "Permanent", roadname: "Via Milano", roadnumber: "4", buildingnumber: "2", floornumber: "2", appartmentnumber: "A", province: "Milan", cityname: "Como", postalcode: "22100",      startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-123", addresstype: "Permanent", roadname: "Via Allesandro", roadnumber: "2", buildingnumber: "2", floornumber: "4", appartmentnumber: "A", province: "Milan", cityname: "Milan", postalcode: "22100", startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-124", addresstype: "Permanent", roadname: "Via Torino", roadnumber: "6", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Milan", cityname: "Milan", postalcode: "22100",     startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-125", addresstype: "Permanent", roadname: "Via Torino", roadnumber: "3", buildingnumber: "7", floornumber: "3", appartmentnumber: "A", province: "Milan", cityname: "Como", postalcode: "22100",      startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-126", addresstype: "Permanent", roadname: "Via Allesandro", roadnumber: "7", buildingnumber: "6", floornumber: "2", appartmentnumber: "A", province: "Milan", cityname: "Como", postalcode: "22100",  startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-127", addresstype: "Guest ", roadname: "Via Torino", roadnumber: "9", buildingnumber: "6", floornumber: "2", appartmentnumber: "A", province: "Milan", cityname: "Milan", postalcode: "22100",        startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-128", addresstype: "Guest", roadname: "Via Allesandro", roadnumber: "1", buildingnumber: "6", floornumber: "2", appartmentnumber: "A", province: "Milan", cityname: "Milan", postalcode: "22100",     startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-129", addresstype: "Guest", roadname: "Via Milano", roadnumber: "2", buildingnumber: "6", floornumber: "2", appartmentnumber: "A", province: "Milan", cityname: "Como", postalcode: "22100",          startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-131", addresstype: "Guest", roadname: "Via Allesandro", roadnumber: "5", buildingnumber: "6", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Como", postalcode: "22100",       startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-130", addresstype: "Guest", roadname: "Via Torino", roadnumber: "4", buildingnumber: "6", floornumber: "3", appartmentnumber: "A", province: "Milan", cityname: "Milan", postalcode: "22100",         startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-131", addresstype: "Guest", roadname: "Via Allesandro", roadnumber: "5", buildingnumber: "6", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Como", postalcode: "22100",       startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-132", addresstype: "Guest", roadname: "Via Torino", roadnumber: "3", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Milan", postalcode: "22100",          startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-133", addresstype: "Permanent", roadname: "Via Allesandro", roadnumber: "4", buildingnumber: "7", floornumber: "3", appartmentnumber: "A", province: "Como", cityname: "Como", postalcode: "22100",   startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-134", addresstype: "Guest", roadname: "Via Milano", roadnumber: "3", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Milan", postalcode: "22100",          startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-135", addresstype: "Guest", roadname: "Via Torino", roadnumber: "2", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Como", postalcode: "22100",           startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-136", addresstype: "Permanent", roadname: "Via Allesandro", roadnumber: "4", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Milan", postalcode: "22100",  startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-137", addresstype: "Permanent", roadname: "Via Torino", roadnumber: "8", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Como", postalcode: "22100",       startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-138", addresstype: "Guest", roadname: "Via Torino", roadnumber: "3", buildingnumber: "7", floornumber: "4", appartmentnumber: "A", province: "Como", cityname: "Milan", postalcode: "22100",          startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-139", addresstype: "Guest", roadname: "Via Allesandro", roadnumber: "5", buildingnumber: "4", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Como", postalcode: "22100",       startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-140", addresstype: "Permanent", roadname: "Via Milano", roadnumber: "7", buildingnumber: "4", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Milan", postalcode: "22100",      startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-151", addresstype: "Guest", roadname: "Via Torino", roadnumber: "4", buildingnumber: "4", floornumber: "4", appartmentnumber: "A", province: "Como", cityname: "Milan", postalcode: "22100",          startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-152", addresstype: "Guest", roadname: "Via Allesandro", roadnumber: "2", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Como", postalcode: "22100",       startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-153", addresstype: "Permanent", roadname: "Via Torino", roadnumber: "4", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Milan", postalcode: "22100",      startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-154", addresstype: "Guest", roadname: "Via Milano", roadnumber: "6", buildingnumber: "7", floornumber: "2", appartmentnumber: "A", province: "Como", cityname: "Como", postalcode: "22100",           startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
        { userId: "AD-155", addresstype: "Guest", roadname: "Via Allesandro", roadnumber: "3", buildingnumber: "7", floornumber: "3", appartmentnumber: "A", province: "Como", cityname: "Milan", postalcode: "22100",      startdate: "10/06/2020", enddate: "10/06/2020",  details: "More.." },
    ];

}
