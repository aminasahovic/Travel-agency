import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-employee-popup',
  templateUrl: './employee-popup.component.html',
  styleUrls: ['./employee-popup.component.css']
})
export class EmployeePopupComponent {
  @Input() showPopup: boolean = false;
  @Output() closePopup = new EventEmitter();
  @Input() function: any;

  onClosePopup() {
    this.showPopup = false;
    this.closePopup.emit();
  }


}
