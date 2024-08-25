import { Component, OnInit } from '@angular/core';
import { SignalRService } from './services/signalR/signal-r.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'UserProject';

constructor(private SignalR:SignalRService) {


}

  ngOnInit(): void {
    this.SignalR.startConnection()
  }
}
