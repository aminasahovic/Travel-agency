import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-location-popup',
  templateUrl: './location-popup.component.html',
  styleUrls: ['./location-popup.component.css']
})
export class LocationPopupComponent {
  @Input() accommodationId!: number;
  @Input() isOpen: boolean = false;
  @Output() isOpenChange: EventEmitter<boolean> = new EventEmitter<boolean>();

  onClosePopup() {
    this.isOpenChange.emit(false);
  }
}
