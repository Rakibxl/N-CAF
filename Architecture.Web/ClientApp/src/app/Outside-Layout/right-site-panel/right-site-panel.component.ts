import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-right-site-panel',
  templateUrl: './right-site-panel.component.html',
  styleUrls:['./right-site-panel-host.scss']
})
export class RightSitePanelComponent implements OnInit {

  constructor() { }


  @Output() closePanel = new EventEmitter<String>();

  closeFnPanel(status) {
    this.closePanel.emit(status);
  }

  ngOnInit() {
  }

}
