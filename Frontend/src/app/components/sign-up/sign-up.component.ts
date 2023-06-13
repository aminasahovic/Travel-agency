import { identifierName } from '@angular/compiler';
import { Component } from '@angular/core';
import {
  FormGroup,
  FormControl,
  NgForm,
  ValidatorFn,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { ResetPasswordService } from 'src/app/Services/reset-password.service';
import { UserStoreService } from 'src/app/Services/user-store.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
})
export class SignUpComponent {
  constructor(private auth: AuthService, private fb: FormBuilder, private router: Router, private matDialog: MatDialog, private userStore: UserStoreService, private resetService: ResetPasswordService) {}
  log: any = {
    username: '',
    password: '',
  };
  
  error: boolean = false;
  validMail:boolean=false;
  firstCheck: boolean=false;
  errorMessage: string = '';
  reset: boolean = false;
  showPopup: boolean=false;
  mailReset: string="";
  selectedFile: any ;
  selectedFileInBase64: string | null = null;


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

  cleanForms(inputUsername: any, inputPassword: any) {
    inputPassword.value = '';
    inputUsername.value = '';
    this.error = false;
  }

  onLogin() {
    console.log(this.log);
    let inputUsername = document.getElementById(
      'LoginMail'
    ) as HTMLInputElement;
    let inputPassword = document.getElementById(
      'LoginPassword'
    ) as HTMLInputElement;
    this.log.username = inputUsername.value;
    this.log.password = inputPassword.value;
    this.auth.login(this.log).subscribe({
      next: (r) => {
        alert(r.message);
        this.auth.storeToken(r.token);
        const tokenPayload=this.auth.decodedToken();
        this.userStore.setNameFromStore(tokenPayload.name);
        this.userStore.setRoleFromStore(tokenPayload.role);
        this.userStore.setIdFromStore(tokenPayload.UserID);
        this.router.navigate(['/user-dashboard']);
        this.CloseSignIn();
        this.cleanForms(inputUsername, inputPassword);
      },
      error: (r) => {
        // alert(r?.error.message);
        this.error = true;
        this.errorMessage = r?.error.message;
        if (r.status == 400) this.errorMessage = r?.error.message;
      },
    });
  }
  CheckIfMailExist(control: FormControl) {
    this.auth.ExistMail(control.value).subscribe({
      next: (r) => {
        return true;
      },
      error: (r) => {
        return false;
      },
    });
  }
  clearForms(signUpForm:FormGroup) {
  }

  onFileSelected(event: any) {
    const files = event.target.files;

    const file = files.item(0);
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.selectedFileInBase64 = e.target.result;
  
        this.signUpForm.patchValue({ profileImageBase64Url: e.target.result});
        this.signUpForm.patchValue({ profileImageBase64: e.target.result.split(',')[1] });
      };
      reader.readAsDataURL(file);
    }
  }

  onSignUp() {
    if (this.signUpForm.valid) {
      console.log(this.signUpForm.value);
      this.auth.signUp(this.signUpForm.value)
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
  CloseSignIn(){
    this.matDialog.closeAll();
  }
  zab() {
    this.reset = true;
  }
  zatvoriR(){
    this.reset = false;
    this.showPopup=false;
    this.mailReset="";
    this.firstCheck=false;
  }
  checkValidMail(){
    const value=this.mailReset;
    const mailPatern=/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;//regex pater za mail :) 
    this.validMail=mailPatern.test(value);
    return this.validMail;

  }
  Test(){
    this.firstCheck=true;
    if(this.checkValidMail()==true){
      
      //PozivamoAPI
      this.resetService.sendResetPasswordLink(this.mailReset).subscribe({
        next:(res)=>{
          this.showPopup=true;
        },
        error:(err)=>{
          alert("Greška");
        }
      })

    }
  }
}
