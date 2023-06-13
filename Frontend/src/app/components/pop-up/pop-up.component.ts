import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

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
  selector: 'app-pop-up',
  templateUrl: './pop-up.component.html',
  styleUrls: ['./pop-up.component.css'],
})
export class PopUpComponent {
  @Input() showPopup: boolean = false;
  @Input() popupData: any;
  @Output() closePopup = new EventEmitter();

  countries$: any;
  cities$!: Observable<City[]>;
  editForm!: FormGroup;
  imageUrls: any[] = [];

  constructor(private dialog: MatDialog, private http: HttpClient) {}

  onClosePopup() {
    // this.closePopup.emit();
    this.showPopup = false;
    this.closePopup.emit();
  }

  ngOnInit() {
    console.log('destinacija' + this.popupData);
    this.editForm = new FormGroup({
      name: new FormControl(this.popupData.name, Validators.required),
      describe: new FormControl(this.popupData.describe, Validators.required),
      price: new FormControl(this.popupData.price, Validators.required),
      cityID: new FormControl(this.popupData.city.cityID, Validators.required),
      countryID: new FormControl(
        this.popupData.city.country.countryID,
        Validators.required
      ),
    });
    console.log(this.showPopup);

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

    console.log(this.imageUrls);
  }
  addImagesToBase() {
    this.imageUrls?.forEach((e: any) => {
      const obj: any = {};
      obj.destinationID = this.popupData.destinationID;
      obj.imageBase64 = e;

      this.http
        .post('https://localhost:7272/api/DestinationImage', obj)
        .subscribe(
          (response: any) => {},
          (error) => {
            console.error(error);
            alert('Greška');
          }
        );
    });
  }
  delete(id: number) {
    const result = confirm('Da li želite izbrisati destinaciju?');
    if (result) {
      this.http
        .delete('https://localhost:7272/api/Destination/' + id)
        .subscribe(
          (response: any) => {
            this.onClosePopup();
            alert('Uspjesno izbrisana destinacija');
          },
          (error) => {
            console.error(error);
            alert('Greška');
          }
        );
    } else {
    }
  }
  edit() {
    const destination = {
      destinationID: this.popupData.destinationID,
      name: this.editForm.value.name,
      describe: this.editForm.value.describe,
      rate: 0,
      price: this.editForm.value.price,
      cityID: this.editForm.value.cityID,
    };

    this.http
      .post('https://localhost:7272/api/Destination/Update', destination)
      .subscribe(
        (response: any) => {
          console.log('dodano');
          this.onClosePopup();
          this.addImagesToBase();
          alert('Uspjesno uređeno');

          // this.destinationId=response.destinationID;
          // console.log(this.destinationId);
          // alert('Uspjesno');
          // this.addImagesToBase();
        },
        (error) => {
          console.error(error);
          alert('Greška');
        }
      );
  }
}
