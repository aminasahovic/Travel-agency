import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmMailService } from 'src/app/Services/confirm-mail.service';

@Component({
  selector: 'app-confirm-mail',
  templateUrl: './confirm-mail.component.html',
  styleUrls: ['./confirm-mail.component.css']
})
export class ConfirmMailComponent {
/**
 *
 */
constructor(private activeRure: ActivatedRoute, private mailC: ConfirmMailService, private router: Router) {}
  email!:string;
  done:boolean=false;
ngOnInit(){
  this.activeRure.queryParams.subscribe(val=>{
    let mail=val['email'];
    this.email=mail;
    this.mailC.confirmMail(this.email).subscribe({
      next: (res)=>{
        this.done=true;
      },
      error:(err)=>{
        alert(this.email);
        alert("Greška");
      }
    })

  })
}

Done(){
this.router.navigate(['']);
}
}
