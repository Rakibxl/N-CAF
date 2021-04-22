import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { NotificationInfo } from '../../../Shared/Entity/Notifiation/NotificationInfo';
import { MessageService } from '../../../Shared/Services/Message/message.service';

@Component({
  selector: 'app-job-notification-history',
  templateUrl: './job-notification-history.component.html',
  styleUrls: ['./job-notification-history.component.css']
})
export class JobNotificationHistoryComponent implements OnInit {

    constructor(private modalService: NgbModal, private messageService: MessageService) { }
    public notificationCollection: NotificationInfo[] = [];

  ngOnInit() { }

    public fnShowDetailsModal(content) {
        this.messageService.getNotificationByOfferId(19).subscribe((res: any) => {
            console.log("offer history::", res);
            this.notificationCollection = res.data || [];
            this.modalService.open(content, {
                size: 'lg'
            });
        });
       
    }

}
