import { Component } from '@angular/core';
import { SignalRService } from './service/SignalRService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(public s:SignalRService){
    s.openWebsocketChannel();
  }
  title = 'Frontend';
  findCountry(){
    let searchValue=document.getElementById("search") as HTMLInputElement;
    console.log(searchValue.value);
  fetch('https://localhost:7272/api/Country/'+searchValue.value)           //api for the get request
  .then(response => response.json())
  .then(data => console.log(data));
  }
}
