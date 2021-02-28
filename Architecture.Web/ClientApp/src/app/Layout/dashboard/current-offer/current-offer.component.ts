/// <reference path="../common/common.component.ts" />
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OfferInfoService } from '../../../Shared/Services/Dashboard/offer-info.service';

@Component({
  selector: 'app-current-offer',
  templateUrl: './current-offer.component.html',
  styleUrls: ['./current-offer.component.css']
})
export class CurrentOfferComponent implements OnInit {
    constructor(private router: Router, private offerService:OfferInfoService) { }

    ngOnInit() {
        this.offerService.getMyOffer().subscribe(res => {
            console.log("Success",res);
        }, error => {
            console.log("Error ", error);
        });
  }
    onClickGeneratePDF() {
        const url = this.router.serializeUrl(
            this.router.createUrlTree(['./generate-pdf'])
        );
        window.open(url, '_blank');
    }

    onClickOffer() {
        const url = this.router.serializeUrl(
            this.router.createUrlTree(['./show-offer'])
        );
        window.open(url, '_blank');
    }

}
