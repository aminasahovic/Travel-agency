import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserStoreService } from 'src/app/Services/user-store.service';
import { AuthService } from 'src/app/Services/auth.service';
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
  selector: 'app-arrangement-form-component',
  templateUrl: './arrangement-form-component.component.html',
  styleUrls: ['./arrangement-form-component.component.css'],
})
export class ArrangementFormComponentComponent implements OnInit {
  @Input() userid: any = '';

  countries!: any[];
  cities!: any[];
  accommodations!: any[];
  transports!: any[];
  users!: any[];

  selectedCountry: any;
  selectedCity: any;
  selectedAccommodation: any;
  selectedTransport: any;
  numberOfPersons: number | undefined;
  role!: any;
  selectedUser: any;
  selectedDepartureTime:any={};
  selectedArrivalTime: any={};
  showPopup = false;
  selectedAccommodationId!: number;

  constructor(
    private http: HttpClient,
    private userStore: UserStoreService,
    private auth: AuthService
  ) {}

  ngOnInit(): void {
    this.fetchCountries();
    this.fetchTransports();
    this.userStore.getIdFromStore().subscribe((val) => {
      const idFromToken = this.auth.getIdFromToken();
      this.userid = idFromToken || val;
    });

    this.userStore.getRoleFromStore().subscribe((val) => {
      const roleFromToken = this.auth.getRoleFromToken();
      this.role == val;
      console.log(this.role);
    });
    this.userStore.getRoleFromStore().subscribe((val) => {
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = roleFromToken || val;
      console.log(this.role);
    });
    this.http
      .get<any[]>('https://localhost:7272/api/Users')
      .subscribe((data) => {
        this.users = data.filter((data) => data.role === '');
      });
  }

  fetchCountries(): void {
    this.http
      .get<any[]>('https://localhost:7272/api/Country')
      .subscribe((data) => {
        this.countries = data;
      });
  }
  fetchUsers(): void {
    this.http
      .get<any[]>('https://localhost:7272/api/Users')
      .subscribe((data) => {
        this.users = data.filter((data) => (data.role = ''));
      });
  }

  fetchCities(): void {
    if (this.selectedCountry) {
      this.http
        .get<any[]>('https://localhost:7272/api/City')
        .subscribe((data) => {
          this.cities = data.filter(
            (city) => city.country.countryID === this.selectedCountry.countryID
          );
        });
    }
  }

  fetchAccommodations(): void {
    if (this.selectedCity) {
      this.http
        .get<any[]>('https://localhost:7272/api/Accommodation')
        .subscribe((data) => {
          this.accommodations = data.filter(
            (accommodation) =>
              accommodation.city &&
              accommodation.city.cityID === this.selectedCity.cityID
          );
        });
    }
  }

  fetchTransports(): void {
    this.http
      .get<any[]>('https://localhost:7272/api/Transportation')
      .subscribe((data) => {
        this.transports = data;
      });
  }

  submitForm(): void {
    if (
      this.selectedCity &&
      this.selectedTransport &&
      this.selectedAccommodation&&
      this.selectedDepartureTime
    ) {
      const destinationPayload = {
        name: 'useradded',
        rate: 0,
        describe: 'useradded',
        price: (this.selectedTransport.price + this.selectedAccommodation.price)*this.numberOfPersons!,
        cityId: this.selectedCity.cityID,
      };
      this.http
        .post('https://localhost:7272/api/Destination', destinationPayload)
        .subscribe((destinationResponse: any) => {
          let travelArrangementPayload: any;
        if(JSON.stringify(this.selectedArrivalTime) === '{}'){
          this.selectedArrivalTime =new Date('0001-01-01T00:00:00.000Z')
        }
          if (this.role != 'Employee') {
            travelArrangementPayload = {
              destinationID: destinationResponse.destinationID,
              userID: this.userid,
              trnsportID: this.selectedTransport.transportationId,
              accomodationID: this.selectedAccommodation.accommodationID,
              numberOfPerson: this.numberOfPersons,
              departureTime:this.selectedDepartureTime,
              arrivalTime:this.selectedArrivalTime
            };
          } else {
            travelArrangementPayload = {
              destinationID: destinationResponse.destinationID,
              userID: this.selectedUser.usersID,
              trnsportID: this.selectedTransport.transportationId,
              accomodationID: this.selectedAccommodation.accommodationID,
              numberOfPerson: this.numberOfPersons,
              departureTime:this.selectedDepartureTime,
              arrivalTime:this.selectedArrivalTime
            };
          }
          console.log(this.selectedArrivalTime);
          this.http
            .post(
              'https://localhost:7272/api/TravelArrangement',
              travelArrangementPayload
            )
            .subscribe(() => {
              alert('Uspjesno kreirana rezervacija');
              this.onClosePopup2();
            });
        });
    }
  }
  openPopup(accommodation: Accommodation) {
    this.showPopup = true;
    this.selectedAccommodationId = accommodation.accommodationID;
  }

  onClosePopup2() {
    this.showPopup = false;
  }
}
