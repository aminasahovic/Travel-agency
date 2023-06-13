import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Observable, map, startWith } from 'rxjs';
import { AuthService } from 'src/app/Services/auth.service';
import { UserStoreService } from 'src/app/Services/user-store.service';
import { Router, ActivatedRoute } from '@angular/router';
import { SignUpComponent } from '../sign-up/sign-up.component';

interface Transport {
  transportationId: number;
  name: string;
  price: number;
  class: string;
}
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
  selector: 'app-destination-detail',
  templateUrl: './destination-detail.component.html',
  styleUrls: ['./destination-detail.component.css'],
})
export class DestinationDetailComponent {
  @Input() showDetail: boolean = false;
  @Input() popupData: any;
  @Input() anonimo: boolean = false;
  @Output() closePopup = new EventEmitter();
  tarsnports$!: Observable<Transport[]>;
  reservationForm!: FormGroup;
  accommodations!: any[];
  selectedCity: any;
  userid: any;
  showPopup = false;
  selectedAccommodationId!: number;
  selectedArrivalTime:any;
  selectedDepartureTime:any;
  role:any;

  constructor(
    private dialog: MatDialog,
    private userStore: UserStoreService,
    private http: HttpClient,
    private auth: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private matDialog: MatDialog
  ) {}

  ngOnInit() {
    this.userStore.getIdFromStore().subscribe((val) => {
      const idFromToken = this.auth.getIdFromToken();
      this.userid = idFromToken || val;
    });
    this.userStore.getRoleFromStore().subscribe((val) => {
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = roleFromToken || val;
    });
    console.log("role"+this.role);

    this.reservationForm = new FormGroup({
      trnsportID: new FormControl(0, Validators.required),
      accomodationID: new FormControl(0, Validators.required),
      numberOfPerson: new FormControl(1, Validators.required),
      departureTime:new FormControl(Validators.required),
      arrivalTime:new FormControl(new Date('0001-01-01T00:00:00.000Z'),Validators.required),
    });
    this.tarsnports$ = this.http
      .get<Transport[]>('https://localhost:7272/api/Transportation')
      .pipe(
        map((tarsnports) =>
          tarsnports.filter((tarsnport) => tarsnport.name !== null)
        ),
        startWith([])
      );
    this.getAccomodations();
  }
  onClosePopup() {
    this.showDetail = false;
    this.closePopup.emit();
  }
  submit() {
    this.showConfirmationDialog();
  }
  OpenSignIn(){
    this.onClosePopup();
    this.matDialog.open(SignUpComponent, {width:'50%', height:'68%'});
  }
  showConfirmationDialog(): void {
    const result = confirm('Da li ste sigurni?');
    
    const travelArr = {
      destinationID: this.popupData.destinationID,
      userID: this.userid,
      trnsportID: this.reservationForm.value.trnsportID,
      accomodationID: this.reservationForm.value.accomodationID,
      numberOfPerson: this.reservationForm.value.numberOfPerson,
      departureTime:this.reservationForm.value.departureTime,
      arrivalTime:this.reservationForm.value.arrivalTime
    };
    if (result && travelArr.accomodationID!=0 && travelArr.trnsportID!=0) {
      this.http
        .post('https://localhost:7272/api/TravelArrangement', travelArr)
        .subscribe(
          (response: any) => {
            this.onClosePopup();
            alert('Uspjesno kreirana rezervacija');
          },
          (error) => {
            console.error(error);
            alert('Greška');
          }
        );
    } else {
      alert('Greška');
      console.log('Korisnik je odabrao No.');
    }
  }

  getAccomodations() {
    this.http
      .get<any[]>('https://localhost:7272/api/Accommodation')
      .subscribe((data) => {
        console.log(data);
        this.accommodations = data.filter(
          (accommodation) =>
            accommodation.city &&
            accommodation.city.cityID === this.popupData.city.cityID
        );
      });
  }

  openPopup(accommodation: Accommodation) {
    this.showPopup = true;
    this.selectedAccommodationId = accommodation.accommodationID;
  }

  onClosePopup2() {
    this.showPopup = false;
  }
}
