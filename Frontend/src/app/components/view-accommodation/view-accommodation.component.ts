import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Accommodation {
  expanded: boolean;
  accommodationID: number;
  name: string;
  numberOfRooms: number;
  price: number;
  accommodationImages: AccommodationImage[];
  imageUrl: string;
}

interface AccommodationImage {
  accommodationImageID: number;
  accomodationID: number;
  imageByteArray: string;
}

@Component({
  selector: 'app-view-accommodation',
  templateUrl: './view-accommodation.component.html',
  styleUrls: ['./view-accommodation.component.css']
})
export class ViewAccommodationComponent implements OnInit {
  accommodations: Accommodation[] = [];
  showPopup = false;
  selectedAccommodationId!: number;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getAccommodations();
  }

  getAccommodations() {
    const url = 'https://localhost:7272/api/Accommodation';
    this.http.get<Accommodation[]>(url).subscribe(
      (response) => {
        this.accommodations = response;
        this.getAccommodationImages();
      },
      (error) => {
        console.log('Error fetching accommodations:', error);
      }
    );
  }

  getAccommodationImages() {
    this.accommodations.forEach((accommodation) => {
      const imageUrl = `https://localhost:7272/api/AccommodationImage?id=${accommodation.accommodationID}`;
      this.http.get<AccommodationImage[]>(imageUrl).subscribe(
        (response) => {
          if (response && response.length > 0) {
            const firstImage = response[0];
            accommodation.imageUrl = `data:image/jpg;base64,${firstImage.imageByteArray}`;
          }
        },
        (error) => {
          console.log(`Error fetching images for accommodation ID ${accommodation.accommodationID}:`, error);
        }
      );
    });
  }

  getFirstImage(accommodation: Accommodation): string {
    // return accommodation.imageUrl || '';
    if (accommodation && accommodation.imageUrl) {
      return accommodation.imageUrl;
    }
    return '';
  }

  openPopup(accommodation: Accommodation) {
    this.showPopup = true;
    this.selectedAccommodationId = accommodation.accommodationID;
  }

  onClosePopup() {
    this.showPopup = false;
  }
}


