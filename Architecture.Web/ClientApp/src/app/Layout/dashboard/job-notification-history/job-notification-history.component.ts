import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NotificationInfo } from '../../../Shared/Entity/Notifiation/NotificationInfo';
import { OfferInfo } from '../../../Shared/Entity/Users/OfferInfo';
import { CommonService } from '../../../Shared/Services/Common/common.service';
import { MessageService } from '../../../Shared/Services/Message/message.service';

@Component({
  selector: 'app-job-notification-history',
  templateUrl: './job-notification-history.component.html',
  styleUrls: ['./job-notification-history.component.css']
})
export class JobNotificationHistoryComponent implements OnInit {
    @Input() offerInfo: OfferInfo;
    public selectedOfferInfoId: OfferInfo;
    @ViewChild('content', { static: true }) modalContent: ElementRef;
    constructor(private modalService: NgbModal, private messageService: MessageService, private commonService: CommonService) { }
    public notificationCollection: NotificationInfo[] = [];

    ngOnInit() { }

    ngOnChanges(changes: any) {
        let offerInfo = changes.offerInfo.currentValue;
        if ((offerInfo.offerInfoId || null) != null) {
            this.selectedOfferInfoId = changes.offerInfo.currentValue;
            this.fnShowDetailsModal(offerInfo.offerInfoId);
        }
    }

    public fnShowDetailsModal(offerInfoid:number) {
        this.messageService.getNotificationByOfferId(offerInfoid).subscribe((res: any) => {
            this.notificationCollection = res.data || [];            
            this.modalService.open(this.modalContent, {
                size: 'lg'
            });
        });
       
    }

}
