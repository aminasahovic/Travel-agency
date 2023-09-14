import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';

interface Country {
  countryID: number;
  name: string;
  code: string;
}
@Component({
  selector: 'app-admin-location',
  templateUrl: './admin-location.component.html',
  styleUrls: ['./admin-location.component.css'],
})
export class AdminLocationComponent {
  countryForm!: FormGroup;
  cityForm!: FormGroup;
  countries$!: Observable<Country[]>;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.countryForm = new FormGroup({
      name: new FormControl('', Validators.required),
      code: new FormControl('', Validators.required),
    });
    this.cityForm = new FormGroup({
      cityName: new FormControl('', Validators.required),
      cityPostalCode: new FormControl('', Validators.required),
      countryId: new FormControl(0, Validators.required),
    });

    this.countries$ = this.http
      .get<Country[]>('https://localhost:7272/api/Country')
      .pipe(
        map((countries: any) =>
          countries.filter((country: any) => country.name !== null)
        ),
        startWith([])
      );
  }
  AddCountry() {
    const country = {
      name: this.countryForm.value.name,
      code: this.countryForm.value.code,
    };

    this.http.post('https://localhost:7272/api/Country', country).subscribe(
      (response: any) => {
        alert('Država uspešno dodata.');
        this.countryForm.reset();
      },
      (error) => {
        alert('Greška prilikom dodavanja države.');
      }
    );
  }
  AddCity() {
    const city={
      cityName: this.cityForm.value.cityName,
      cityPostalCode: this.cityForm.value.cityPostalCode,
      countryId: this.cityForm.value.countryId
    }
    this.http
      .post('https://localhost:7272/api/City', city)
      .subscribe(
        (response:any) => {
          alert('Uspjesno');
          this.cityForm.reset();
        },
        (error) => {
          alert('Greška');
        }
      );
  }
}
