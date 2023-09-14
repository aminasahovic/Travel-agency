import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResetPassword } from 'src/app/models/reset-password.model';
import { ResetPasswordService } from 'src/app/Services/reset-password.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent {

  newPassword: string = '';
  confirmPassword: string = '';
  done: boolean= false;
  emailToReset!:string;
  emailToken!: string;
  resetPasswordObj=new ResetPassword();

  constructor(private activateRoute: ActivatedRoute, private resetService: ResetPasswordService, private router: Router ){}
  resetPassword() {
    if (this.newPassword === this.confirmPassword) {
      this.activateRoute.queryParams.subscribe(val=>{
        this.emailToReset=val['email'];
        let emailToken1=val['code'];
        this.emailToken=emailToken1.replace(/ /g, '+');
        this.resetPasswordObj.email=this.emailToReset;
        this.resetPasswordObj.newPassword=this.newPassword;
        this.resetPasswordObj.confirmPassword=this.confirmPassword;
        this.resetPasswordObj.emailToken=this.emailToken;
        this.resetService.resetPassword(this.resetPasswordObj).subscribe({
          next:(res)=>{
            this.done=true;
          },
          error:(err)=>{
            alert("GREŠKA");
          }
        })
      })
    } else {
      alert('Lozinke se ne poklapaju');
    }
  }

  closePopup() {
    this.router.navigate(['']);
  }
}
