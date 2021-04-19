import { Component, OnInit } from '@angular/core';
import {  scaleAnimation } from 'src/app/Shared/Modules/animations/animationRightToggle';
import { NotificationInfo } from '../../Entity/Notifiation/NotificationInfo';
import { AlertService } from '../../Modules/alert/alert.service';
import { OfferInfoService } from '../../Services/Dashboard/offer-info.service';
import { MessageService } from '../../Services/Message/message.service';
import { UserService } from '../../Services/Users/user.service';

@Component({
  selector: 'app-chat-box-popup',
  templateUrl: './chat-box-popup.component.html',
  animations: [scaleAnimation]
})
export class ChatBoxPopupComponent implements OnInit {

    constructor(private messageService: MessageService, private userService: UserService, private offerInfoService: OfferInfoService, private alertService: AlertService) { }
    public applicationUserData: any[] = [];
    public applicationOfferData: any[] = [];
    public messageInfo: string;
    public chattingUserId: any;
    public chattingOfferInfoId: any;
    public notificationCollection: NotificationInfo[] = [];
  animationOpen: string = 'out';
  toggleClick() {
    this.animationOpen = this.animationOpen === 'out' ? 'in' : 'out';
  }
  closeChatbox=()=>{this.animationOpen = 'out';}


    ngOnInit() {
        this.fnGetApplicationUsers();
        this.fnGetProgressOffer();
        MessageService.notify.subscribe((res) => {
            let message: NotificationInfo = res;
            if ((message.createdBy == this.chattingUserId) || (message.offerInfoId == this.chattingOfferInfoId && (message.offerInfoId || null) != null)) {
                this.notificationCollection.push(message);
            }
        });
    }

    fnGetProgressOffer() {
        if (sessionStorage.getItem("applicationOfferData") != null) {
            this.applicationOfferData = sessionStorage.getItem("applicationOfferData") == null ? [] : JSON.parse(sessionStorage.getItem("applicationOfferData"));
            return false;
        }
        this.offerInfoService.getProgressOfferForChatting().subscribe((res) => {
            sessionStorage.setItem("applicationOfferData", JSON.stringify(res.data || []));
            this.applicationOfferData = res.data || [];
            console.log("chatting offer :::", res);

        });
    }

    fnGetApplicationUsers() {
        if (sessionStorage.getItem("applicationUserData") != null) {
            this.applicationUserData = sessionStorage.getItem("applicationUserData") == null ? [] : JSON.parse(sessionStorage.getItem("applicationUserData"));
            return false;
        }
       

        this.userService.getUsers().subscribe((res) => {
            sessionStorage.setItem("applicationUserData", JSON.stringify(res.data || []));
            this.applicationUserData= res.data || [];
            console.log("Applciation users::: ", res);

        });
    }

    public fnSendMessage() {
        console.log("chattingUserId::", this.chattingUserId);
        console.log("chattingOfferInfoId::", this.chattingOfferInfoId);  
        if ((this.chattingOfferInfoId || null) != null || (this.chattingUserId || null) != null) {

            let nofiticationInfo: NotificationInfo = new NotificationInfo();
            nofiticationInfo.messageContent = this.messageInfo;
            nofiticationInfo.messageFor = this.chattingUserId;
            nofiticationInfo.offerInfoId = this.chattingOfferInfoId;
            
            this.messageService.saveNotificationInfo(nofiticationInfo).subscribe(res => {
                this.messageInfo = "";
                this.notificationCollection.push(res.data);
                console.log(res);
            });

        } else {
            this.alertService.tosterWarning("Please select offer information of perticular person name and try again.");
        }
    }

    public fnChangeApplicationUser() {
        this.fnGetMessage();
    }

    public fnChangeOfferId() {

    }

    public fnGetMessage() {
        if ((this.chattingUserId || null) == null) {
            this.notificationCollection =  [];
            return false;
        }

        this.messageService.getNotificationByApplicatonUserId(this.chattingUserId).subscribe(res => {
            console.log("notification: ", res);
            this.notificationCollection = res.data || [];
        })
    }

}
