import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-basic-information',
  templateUrl: './basic-information.component.html',
  styleUrls: ['./basic-information.component.css']
})
export class BasicInformationComponent implements OnInit {

  constructor() { }


  defaultBindingsList = [
        { value:"1", label:"type here"},
        { value:"Celibe/Nubile - Unmarried Maiden", label:"Celibe/Nubile - Unmarried Maiden"},
        { value:"Coniugato/a - Married To", label:"Coniugato/a - Married To"},
        { value:"unito/a civilmente - joined civilly", label:"unito/a civilmente - joined civilly"},
        { value:"separata legalmente - legally separated", label:"separata legalmente - legally separated"},
        { value:"sciolto/a legalmente - legally dissolved", label:"sciolto/a legalmente - legally dissolved"},
        { value:"sciolto/a da unione civile-dissolved from civil union - civil union", label:"sciolto/a da unione civile-dissolved from civil union - civil union"},
        { value:"divorziato/a - divorced to", label:"divorziato/a - divorced to"},
        { value:"vedovo/a - widower", label:"vedovo/a - widower"},
        { value:"abbandonato/a - abandoned", label:"abbandonato/a - abandoned"},
        { value:"parte superstite dell'unione civile- surviving part of the civil union", label:"parte superstite dell'unione civile- surviving part of the civil union"},
    ];

  selectedCity ={ value:"1", label:"type here"};
  

  ngOnInit() {
  }

}
