import { Component, OnInit } from '@angular/core';
import { NotificationInfo } from '../../../../../../Shared/Entity/Notifiation/NotificationInfo';
import { MessageService } from '../../../../../../Shared/Services/Message/message.service';

@Component({
  selector: 'app-header-notification',
  templateUrl: './header-notification.component.html'
})
export class HeaderNotificationComponent implements OnInit {
    message: any; 
    title = 'ClientApp';
    txtMessage: string = '';
    uniqueID: string = new Date().getTime().toString();
    messages = new Array<any>();
    public unSeenNotificationCount: number = 0;
    public notificationCollection: NotificationInfo[] = [];
    //message = new Message();
    constructor(private messageService: MessageService) { }

    ngOnInit() {
        this.subscribeToEvents();
        this.fnGetMessage();
    }

    private sendMessage(): void {
            //this.message = new Message();
            this.message.clientuniqueid = new Date().getTime().toString();
            this.message.type = "sent";
            this.message.message ="Palash";
            this.message.date = new Date();
            this.messages.push(this.message);
            this.messageService.sendMessage(this.message);
            this.txtMessage = '';
    }

    public fnGetMessage() {
        this.messageService.getCurrentUserNotification(1, 100).subscribe(res => {
            this.notificationCollection = res.data || [];
            this.unSeenNotificationCount = this.notificationCollection.filter(x => !x.isSeen).length;
        })
    }
    private subscribeToEvents(): void {
        this.messageService.registerOnServerEvents();
        //this.chatService.messageReceived.subscribe((message: any) => {
        //    this._ngZone.run(() => {
        //        if (message.clientuniqueid !== this.uniqueID) {
        //            message.type = "received";
        //            this.messages.push(message);
        //        }
        //    });
        //});
    }  

}
