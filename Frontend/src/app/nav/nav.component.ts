import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SignUpComponent } from '../components/sign-up/sign-up.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private matDialog: MatDialog, private router: Router) { }

  ngOnInit(): void {
  }

  OpenSignIn(){
    this.matDialog.open(SignUpComponent, {width:'50%', height:'68%'});
  }
  onAboutUs(){
    this.router.navigate(['/app-about-us']);
  }
  onHome(){
    this.router.navigate(['']);
  }
  onOffer(){
    this.router.navigate(['/app-offer']);
  }
  onLiveChat(){
    this.router.navigate(['/app-live-chat']);
  }
}
