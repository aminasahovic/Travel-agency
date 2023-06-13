import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css'],
})
export class CounterComponent {
  counter!: FormGroup;
  constructor(private http: HttpClient){}
  ngOnInit(){
    this.counter=new FormGroup({
      name:new FormControl('',Validators.required)
    });
  }
  OnSubmit() {
    const counters = {
      name: this.counter.value.name,

    };
    this.http
      .post('https://localhost:7272/api/Counter', counters)
      .subscribe(
        (response: any) => {
          alert('Uspjesno');
          this.clearForm();
        },
        (error) => {
          console.error(error);
          alert('Greška');
        }
      );

  }
  clearForm() {
    this.counter.patchValue({
      name: '',
    });
    this.counter.get('name')?.setErrors(null);
  }
}
