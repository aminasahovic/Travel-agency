import { Injectable } from '@angular/core';
import * as signalr from '@microsoft/signalr';
import { AuthService } from '../Services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  private connection!: signalr.HubConnection;
  public poruka1: string = 'poruka1';
  public poruka2: string = 'poruka2';
  message = '';
  role='';
  messages: string[] = [];
  user = 'User' + Math.floor(Math.random() * 100);
  public fullName: string = '';
  constructor(private authService: AuthService) {
    this.role= authService.getRoleFromToken();
    if(this.role==="Admin"){
      this.user="Admin";
    }
    else{
      this.fullName = authService.getFullNameFromToken();
      console.log(this.fullName);
      if(this.fullName==null){
        this.user="Anonimno";
      }
      else{
        this.user = this.fullName;
      }
      
    }
  }

  openWebsocketChannel() {
     this.connection = new signalr.HubConnectionBuilder()
      .withUrl('https://localhost:7272/poruke-hub-putanja')
      .build();

    this.connection.start().then(() => {
      console.log('Otvoren kanal');
    });
    this.connection.on('ReceiveMessage', (user: string, message: string) => {
      const text = `${user}: ${message}`;
      this.messages.push(text);
    });
  }
  public sendMessage(): void {
    this.connection.send('SendMessage', this.user, this.message)
      .then(() => this.message = '')
      .catch(err => console.log(err));
  }
}
