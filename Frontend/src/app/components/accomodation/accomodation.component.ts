import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
  FormControl,
} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Observable, map, startWith } from 'rxjs';

interface City {
  cityID: number;
  cityName: string;
  cityPostalCode: string;
  country: {
    countryID: number;
    name: string;
    code: string;
  };
}

interface Destination {
  destinationID: number;
  name: string;
  rate: number;
  describe: string;
  price: number;
  cityId: number;
}



@Component({
  selector: 'app-accomodation',
  templateUrl: './accomodation.component.html',
  styleUrls: ['./accomodation.component.css'],
})
export class AccomodationComponent implements OnInit {
  accomodation!: FormGroup;
  destination!: Observable<Destination[]>;
  city!: Observable<City[]>; 
  imageUrls: any[] = [];
  accommodationId:number=0;

  constructor(private formBuilder: FormBuilder, private http: HttpClient) {}

  ngOnInit() {
    this.accomodation = this.formBuilder.group({
      name: new FormControl('', Validators.required),
      numberOfRooms: new FormControl('', Validators.required),
      destinationID: new FormControl('', Validators.required),
      cityID: new FormControl('', Validators.required),
      pass: false,
      price:new FormControl('', Validators.required),
    });

    this.destination = this.http
      .get<Destination[]>('https://localhost:7272/api/Destination')
      .pipe(
        map((dest: any) => dest.filter((dest: any) => dest.name !== null)),
        startWith([])
      );

      this.city = this.http.get<City[]>('https://localhost:7272/api/City');
  }

  OnSubmit() {
    const accomodation = {
      name: this.accomodation.value.name,
      numberOfRooms: this.accomodation.value.numberOfRooms,
      destinationID: this.accomodation.value.destinationID,
      cityID: this.accomodation.value.cityID,
      price:  this.accomodation.value.price,
      pass: false,
    };
    this.http
      .post('https://localhost:7272/api/Accommodation', accomodation)
      .subscribe(
        (response: any) => {
          this.accommodationId=response.accommodationID;
          alert("Uspjesno");
          alert(this.accommodationId);
          this.addImagesToBase();
        },
        (error) => {
          console.error(error);
          alert('Greška');
        }
      );
  }
  clearForm() {
    this.accomodation.patchValue({
      name: '',
      numberOfRooms: null,
      destinationID: null,
    });
    this.accomodation.get('name')?.setErrors(null);
    this.accomodation.get('numberOfRooms')?.setErrors(null);
    this.accomodation.get('destinationID')?.setErrors(null);
  }

  AddImages(event: any) {
    const files = event.target.files;
      for (let i = 0; i < files.length; i++) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.imageUrls?.push(e.target.result.split(',')[1]);
        };
        reader.readAsDataURL(files[i]);
      }

      console.log(this.imageUrls);
    
  }

  addImagesToBase(){

    this.imageUrls?.forEach((e: any) => {
      const obj: any={};
      obj.accommodationID=this.accommodationId;
      obj.imageBase64=e;

      this.http
      .post('https://localhost:7272/api/AccommodationImage', obj)
      .subscribe(
        (response:any) => {
 
        },
        (error) => {
          console.error(error);
          alert('Greška');
        }
      );
    });
  }
}
