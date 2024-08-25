import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { InteractionService } from '../interaction/interaction.service';
import { User } from 'src/app/interfaces/User.interface';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  private hubConnection: signalR.HubConnection | undefined;
  constructor(private interactionService: InteractionService) {
    this.hubConnection?.onclose(error => {
      this.retryConnection();
    });
  }

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:44341/usersHub", { skipNegotiation: true, transport: signalR.HttpTransportType.WebSockets })
      .configureLogging(signalR.LogLevel.Information)
      .build();
    this.hubConnection
      .start()
      .then(() => {
        this.getUsersOnInit();
        this.updateUsers();
      })
      .catch(err => {
        this.retryConnection();
      });

    this.hubConnection.onclose(() => {
      console.log('Connection closed');
      this.retryConnection();
    });
  }

  getUsersOnInit() {
    this.hubConnection?.invoke("SendUsers")
      .then(data => {
      })
  }
  updateUsers() {
    this.hubConnection?.on("SendUsers", (users: User[]) => {
      this.interactionService.setUsers(users);
    })
  }

  private reconnectInterval = 5000;
  private maxRetries = 10;
  private retryCount = 0;

  private retryConnection(): void {
    if (this.retryCount < this.maxRetries) {
      setTimeout(() => {
        this.retryCount++;
        console.log(`Attempting to reconnect... (${this.retryCount}/${this.maxRetries})`);
        this.startConnection();
      }, this.reconnectInterval);
    } else {
      console.log('Max retries reached. Giving up.');
    }
  }
}
