import { Component } from '@angular/core';
import { SignalRService } from 'src/app/service/SignalRService';

@Component({
  selector: 'app-admin-chat',
  templateUrl: './admin-chat.component.html',
  styleUrls: ['./admin-chat.component.css']
})
export class AdminChatComponent {
  constructor(public s:SignalRService){}
}
