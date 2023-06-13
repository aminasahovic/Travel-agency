import { Injectable } from '@angular/core';
import { CanActivate} from '@angular/router';
import { AuthService } from '../Services/auth.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService) {
  }
  canActivate():boolean{
    return this.auth.isLoggedIn();
  }
  canAdmin(): boolean{
    return this.auth.isLoggedIn() && this.auth.getRoleFromToken()==='Admin';
  }
  
}
