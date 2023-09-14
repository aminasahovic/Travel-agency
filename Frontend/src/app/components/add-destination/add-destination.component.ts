import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { ContentObserver } from '@angular/cdk/observers';

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

@Component({
  selector: 'app-add-destination',
  templateUrl: './add-destination.component.html',
  styleUrls: ['./add-destination.component.css'],
})
export class AddDestinationComponent implements OnInit {
  form!: FormGroup;
  cities$!: Observable<City[]>;
  countries$!: Observable<Country[]>;
  imageUrls: any[] = [];
  destinationId:number=0;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      describe: new FormControl('', Validators.required),
      price: new FormControl('', Validators.required),
      cityID: new FormControl('', Validators.required),
      countryID: new FormControl('', Validators.required),
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

  

  onSubmit() {
    const destination = {
      name: this.form.value.name,
      describe: this.form.value.describe,
      rate: 0,
      price: this.form.value.price,
      cityID: this.form.value.cityID,
    };

    this.http
      .post('https://localhost:7272/api/Destination', destination)
      .subscribe(
        (response:any) => {

          this.destinationId=response.destinationID;

          alert('Uspjesno');
          this.addImagesToBase();
        },
        (error) => {
          alert('Greška');
        }
      );

  }

  AddImages(event: any) {
    const files = event.target.files;
      // Upload vise slika
      for (let i = 0; i < files.length; i++) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.imageUrls?.push(e.target.result.split(',')[1]);
          // sessionStorage.setItem('imageUrls', JSON.stringify(this.imageUrls));
        };
        reader.readAsDataURL(files[i]);
      }

  }

  addImagesToBase(){

    this.imageUrls?.forEach((e: any) => {
      const obj: any={};
      obj.destinationID=this.destinationId;
      obj.imageBase64=e;

      this.http
      .post('https://localhost:7272/api/DestinationImage', obj)
      .subscribe(
        (response:any) => {
 
        },
        (error) => {
          alert('Greška');
        }
      );
    });
  }

}
