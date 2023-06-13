import { Component } from '@angular/core';
import { SignalRService } from 'src/app/service/SignalRService';

@Component({
  selector: 'app-live-chat',
  templateUrl: './live-chat.component.html',
  styleUrls: ['./live-chat.component.css']
})
export class LiveChatComponent {
  constructor(public s:SignalRService){}
}
