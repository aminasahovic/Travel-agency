import { HttpClient } from '@angular/common/http';
import { Component, Input } from '@angular/core';
import { SignalRService } from 'src/app/service/SignalRService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  @Input() basicUser!: boolean;

  serverResponseData: any;
  filteredDestinations!: any[];
  destinations!: any[];

  constructor(public s: SignalRService, private http: HttpClient) {}

  getImg(base64img: string) {
    const url = `data:image/jpg;base64,${base64img}`;
    return url;
  }

  ngOnInit() {
    this.http
      .get<any[]>('https://localhost:7272/api/Destination')
      .subscribe((destinations) => {
        this.destinations = destinations;
        console.log(this.destinations);

        this.http
          .get<any[]>('https://localhost:7272/api/DestinationImage/getall')
          .subscribe((images) => {
            const mappedDestinations = this.destinations.map((destination) => {
              const destinationImage = images.find(
                (image) => image.destinationID === destination.destinationID
              );
              return {
                ...destination,
                img: destinationImage
                  ? this.getImg(destinationImage.imageByteArray)
                  : null,
              };
            });
            this.destinations = mappedDestinations;
            this.filteredDestinations = mappedDestinations;
          });
      });
  }

  findCity() {
    let searchValue = document.getElementById('search') as HTMLInputElement;
    console.log(searchValue.value);
    fetch('https://localhost:7272/api/Accommodation/' + searchValue.value) //api for the get request
      .then((response) => response.json())
      .then((data) => (this.serverResponseData = data))
      .then((data) => console.log(data));
  }

  onInputChange(event: Event): void {
    let searchValue = document.getElementById('search') as HTMLInputElement;

    if (searchValue.value === '') {
      this.filteredDestinations = this.destinations;
    } else {
      this.filteredDestinations = this.filteredDestinations.filter(
        (destination) =>
          destination.name
            .toLowerCase()
            .includes(searchValue.value.toLowerCase())
      );
    }
  }

  OpenSignIn() {
    alert('Morate biti prijavljeni :)');
  }
}
