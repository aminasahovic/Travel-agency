import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { UserStoreService } from 'src/app/Services/user-store.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-historyarragment',
  templateUrl: './historyarragment.component.html',
  styleUrls: ['./historyarragment.component.css'],
  providers: [DatePipe]
})



export class HistoryarragmentComponent {
  travelArrangements: TravelArrangement[] = [];
  userid: any;
  constructor(private http: HttpClient, private auth: AuthService, private userStore: UserStoreService,private datePipe: DatePipe) { }

  ngOnInit(): void {
    this.userStore.getIdFromStore().subscribe((val) => {
      const idFromToken = this.auth.getIdFromToken();
      this.userid = idFromToken || val;
    });
    const url = `https://localhost:7272/api/TravelArrangement/${this.userid}`;

    this.http.get<TravelArrangement[]>(url)
      .subscribe(
       
        data => {
          this.travelArrangements = data;
        },
        error => {
          console.error('Failed to fetch travel arrangements:', error);
        }
      );
  }
  formatDateTime(dateTime: string): string {
    const formattedDateTime = this.datePipe.transform(dateTime, 'dd.MM.yyyy.');
    return formattedDateTime || '';
  }

  
}

export interface TravelArrangement {
  travelArrangementID: number;
  destination: {
    destinationID: number;
    name: string;
    rate: number;
    describe: string;
    price: number;
    city: {
      cityID: number;
      cityName: string;
      cityPostalCode: string;
      country: {
        countryID: number;
        name: string;
        code: string;
      };
    };
  };
  users: {
    usersID: number;
    firsName: string;
    lastName: string;
    birthDate: string;
    isAdmin: boolean;
    email: string;
    username: string;
    password: string;
    token: string;
    role: string;
    isEmailAccepted: boolean;
    resetPasswordToken: string;
    resetPasswordExpiry: string;
    profileImageBase64: string;
    profileImage: string;
  };
  transportation: {
    transportationId: number;
    name: string;
    price: number;
    class: string;
  };
  accommodation: {
    accommodationID: number;
    name: string;
    pass: boolean;
    numberOfRooms: number;
    price: number;
    destination: {
      destinationID: number;
      name: string;
      rate: number;
      describe: string;
      price: number;
      city: {
        cityID: number;
        cityName: string;
        cityPostalCode: string;
        country: {
          countryID: number;
          name: string;
          code: string;
        };
      };
    };
    city: {
      cityID: number;
      cityName: string;
      cityPostalCode: string;
      country: {
        countryID: number;
        name: string;
        code: string;
      };
    };
  };
  numberOfPerson: number;
  price: number;
  isAccepted: boolean;
  departureTime:string;
  arrivalTime:string;
}
