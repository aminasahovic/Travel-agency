import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-location-component',
  templateUrl: './location-component.component.html',
  styleUrls: ['./location-component.component.css']
})
export class LocationComponent implements OnInit {
  @Input() accommodationId!: number | null;
  @Output() closePopup: EventEmitter<void> = new EventEmitter<void>();
  accommodation: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    if (this.accommodationId) {
      this.getAccommodation();
    }
  }

  getAccommodation() {
    this.http
      .get<any>('https://localhost:7272/api/Accommodation/getbyid/' + this.accommodationId)
      .subscribe((accommodation) => {
        this.accommodation = accommodation;
      });
  }

  onClosePopup() {
    this.closePopup.emit();
  }
}
