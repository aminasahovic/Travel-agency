import { Component, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map, startWith } from 'rxjs';

interface City {
  cityID: number;
  cityName: string;
  cityPostalCode: string;
  country: Country;
}
interface Country {
  countryID: number;
  name: string;
  code: string;
}
interface Destination {
  name: string;
  city: string;
  price: number;
}

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css'],
})
export class OfferComponent {
  @Input() basicUser!:boolean;
  @Input() registerUser!:boolean;
 
  destinations!: any[];
  images: string = '';
  helpArray!: any[];
  countries$: any;
  cities$!: Observable<City[]>;
  nazivPonude: string = '';
  filteredDestinations!: any[];
  selectedCountryID: number = 0;
  selectedCityID: number = 0;
  price:number=0;

  constructor(private http: HttpClient) {}

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

    this.cities$ = this.http
      .get<City[]>('https://localhost:7272/api/City')
      .pipe(
        map((cities) => cities.filter((city) => city.cityName !== null)),
        startWith([])
      );

    this.countries$ = this.http
      .get<Country[]>('https://localhost:7272/api/Country')
      .pipe(
        map((countries) =>
          countries.filter((country) => country.name !== null)
        ),
        startWith([])
      );
  }

  filterDestinations(nazivPonude?: string) {
    this.filteredDestinations = this.destinations;
    console.log(this.selectedCountryID);

    if (nazivPonude != '') {
      this.filteredDestinations = this.filteredDestinations.filter((destination) =>
        destination.name.toLowerCase().includes(this.nazivPonude.toLowerCase())
      );
    }
    if(this.selectedCountryID!=0){
      this.filteredDestinations = this.filteredDestinations.filter((destination) =>
      destination.city.country.countryID===this.selectedCountryID

    );
    }
    if(this.selectedCityID!=0){
      this.filteredDestinations = this.filteredDestinations.filter((destination) =>
      destination.city.cityID===this.selectedCityID
    );
    }
    if(this.price!=0){
      this.filteredDestinations = this.filteredDestinations.filter((destination) =>
      destination.price<=this.price
    );
    }
  }
}
