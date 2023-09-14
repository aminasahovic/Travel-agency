import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css'],
})
export class EmployeeFormComponent implements OnInit {
  employeeForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.employeeForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      birthdate: ['', Validators.required],
      password: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      role: ['', Validators.required],
      phoneNumber:''
    });
  }

  onSubmit() {
    if (this.employeeForm.valid) {
      this.auth.signUp(this.employeeForm.value).subscribe({
        next: (r) => {
          alert('Uspjesno ste registrovani!');
          this.employeeForm.reset();
        },
        error: (r) => {
          alert('Doslo je do greske! Neko već koristi email ili username');
        },
      });
    } else {
      alert('Provjerite polja');
    }
  }
}
