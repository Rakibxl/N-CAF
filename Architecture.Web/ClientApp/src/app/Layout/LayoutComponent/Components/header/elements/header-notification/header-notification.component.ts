import { Component, OnInit } from '@angular/core';
import { NotificationInfo } from '../../../../../../Shared/Entity/Notifiation/NotificationInfo';
import { AlertService } from '../../../../../../Shared/Modules/alert/alert.service';
import { CommonService } from '../../../../../../Shared/Services/Common/common.service';
import { MessageService } from '../../../../../../Shared/Services/Message/message.service';

@Component({
  selector: 'app-header-notification',
  templateUrl: './header-notification.component.html'
})
export class HeaderNotificationComponent implements OnInit {
    message: any; 
    title = 'ClientApp';
    txtMessage: string = '';
    messages = new Array<any>();
    public unSeenNotificationCount: number = 0;
    public notificationCollection: NotificationInfo[] = [];
    //message = new Message();
    constructor(private messageService: MessageService, private alertService: AlertService, private commonService: CommonService) { }

    ngOnInit() {
        this.subscribeToEvents();
        this.fnGetMessage();

        MessageService.notify.subscribe((res: NotificationInfo) => {
            this.unSeenNotificationCount = this.unSeenNotificationCount + 1;
            this.alertService.titleTosterSuccess(`You have received a notification: ${res.messageContent}`);
        });
    }

    public fnGetMessage() {
        this.messageService.getCurrentUserNotification(1, 100).subscribe(res => {
            this.notificationCollection = res.data || [];
            this.unSeenNotificationCount = this.notificationCollection.filter(x => !x.isSeen).length;
            if (this.unSeenNotificationCount>0) {
                this.messageService.seenCurrentUserNotification().subscribe(res => {
                    console.log("seen result::", res);
                });
            }
        })
    }
    private subscribeToEvents(): void {
        this.messageService.registerOnServerEvents();        
    } 
}
