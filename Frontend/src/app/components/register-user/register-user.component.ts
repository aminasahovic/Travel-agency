import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent {

  constructor(private auth: AuthService){}
  signUpForm = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
    ]),
    username: new FormControl('', Validators.required),
    birthDate: new FormControl('', Validators.required),
    profileImageBase64:new FormControl(''),
    profileImageBase64Url:new FormControl('')
  }); 
  
  onSignUp() {

    if (this.signUpForm.valid) {
      this.auth.signUpByEmployee(this.signUpForm.value)
      .subscribe({
        next: (r) => {
          alert("Uspjenso ste registrovani!");
          this.signUpForm.reset();
        },
        error: (r) => {
          alert("Doslo je do greske! Neko već koristi email ili username");
        },

      });
    } else {
      alert("Provjerite polja")
    }
  }
}
