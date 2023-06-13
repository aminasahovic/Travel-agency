import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PopUpComponent } from '../pop-up/pop-up.component';

@Component({
  selector: 'app-destination-card',
  templateUrl: './destination-card.component.html',
  styleUrls: ['./destination-card.component.css']
})

export class DestinationCardComponent {
  @Input() destination: any;
  @Input() showPopup: any;
  @Input() basicUser!:boolean;
  @Input() registerUser!:boolean;
  @Input() showDetail: any;
  anonimo:boolean=false;

  // showPopup:any;
  constructor(private dialog: MatDialog) { 
  }
  ngOnInit(){
    // this.basicUser=true;
  }

  openPopup() {
    this.showPopup = true;
  }
  closePopup() {
    this.showPopup = false;
  }
  openDetail() {
    this.showDetail = true;
  }
  openDetail2(){
    this.showDetail = true;
    this.anonimo=true;
  }
  closeDetail() {
    this.showDetail = false;
  }
}
