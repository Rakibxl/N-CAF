import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { APIResponse } from '../../Entity/Response/api-response';
import { NotificationInfo } from '../../Entity/Notifiation/NotificationInfo';
import { AuthService } from '../Users/auth.service';
import { IAuthUser } from '../../Entity/Users/auth';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageService {


    public baseUrl: string;
    public user: IAuthUser;
    public static notify = new Subject<any>();
    private _hubConnection: HubConnection;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private authService: AuthService) {
    console.log("baseUrl: ", baseUrl);
      this.baseUrl = baseUrl + 'api/';
      this.createConnection();
  }

  getDashboardData() {
    return this.http.get<APIResponse>(this.baseUrl + 'v1/dashboard');
    }

    //public onSendButtonClick(): void {
    //    this._hubConnection.send('SendMessage', 'test message').then(r => { });
    //}

    public createConnection(): void {
        this._hubConnection = new HubConnectionBuilder()
            .withUrl('https://localhost:44357/notificationHub')
            //.withUrl('https://localhost:44357/notification')
            .build();

        //this._hubConnection.on('MessageReceived', (message) => {
        //    console.log("MessageReceived::::",message);
        //});

        this._hubConnection.start()
            .then(() => console.log('connection started'))
            .catch((err) => console.log('error while establishing signalr connection: ' + err));
    }

    public sendMessage(message: any) {
        this._hubConnection.invoke('NewMessage', message);
    }
    public registerOnServerEvents(): void {
        this.authService.currentUser.subscribe(user => this.user = user);

        this._hubConnection.on(this.user.id, (data: any) => {
            console.log("notification success:::", data);
            MessageService.notify.next(data);
        });
    }

    //#region Notification 

    public saveNotificationInfo(data: NotificationInfo) {
        return this.http.post<APIResponse>(this.baseUrl + 'v1/notification/CreateOrUpdate', data);
    }
    public getNotificationInfoById(notificationId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/notification/GetNotification/${notificationId}`);
    }

    public getNotificationByOfferId( offerInfoId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/notification/GetByOfferId/${offerInfoId}`);
    }
    public getNotificationByApplicatonUserId(applicationUserId: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/notification/GetByApplicationByAppUserId/${applicationUserId}`);
    }
    public getCurrentUserNotification(pageNumber: number, pageSize: number) {
        return this.http.get<APIResponse>(this.baseUrl + `v1/notification/CurrentUserNotification/${pageNumber}/${pageSize}`);
    }
    //#endregion Notificaiton 
}
