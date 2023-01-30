import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalR';
import { MyConfig } from '../shared/MyConfig';
import { NotificationsService } from './NotificationsService';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  hasUnreadNotifications: boolean = false;
  unreadNotifications: any;
  constructor(private notificationsService: NotificationsService) {}
  private hubConnection: signalR.HubConnection;
  public startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(MyConfig.address_server_base + 'hubs/notifications')
      .build();

    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch((err: any) =>
        console.log('Error while starting connection: ' + err)
      );
  }

  public notifications() {
    this.hubConnection.on('notificationsData', (data) => {
      this.notificationsService
        .getUnreadNotifications()
        .subscribe((data: any) => {
          this.unreadNotifications = data;
          this.hasUnreadNotifications = true;
        });
    });
  }
}
