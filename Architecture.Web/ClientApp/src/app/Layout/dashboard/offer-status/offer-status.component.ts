import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-offer-status',
  templateUrl: './offer-status.component.html',
  styleUrls: ['./offer-status.component.css']
})
export class OfferStatusComponent implements OnInit {

    constructor() { }

    public onClickGeneratePDF() {
        console.log("generate pdf.");
    }

    public onClickOffer() {

    }

  ngOnInit() {
  }

}
