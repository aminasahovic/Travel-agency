import { Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { UserStoreService } from './user-store.service';
import { tap } from 'rxjs';


@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private urlBase: string = 'https://localhost:7272/api/Users/';
  private userPayload: any;
  constructor(private http: HttpClient, private router: Router, private userStore: UserStoreService) {
    this.userPayload = this.decodedToken();
  }
  signUp(userObj: any) {
    return this.http.post<any>(`${this.urlBase}register`, userObj);
  }
  signUpByEmployee(userObj: any) {
    return this.http.post<any>(`${this.urlBase}registerbyEmployee`, userObj);
  }
  registerEmployee(obj:any){
    return this.http.post<any>(`${this.urlBase}registerbyEmployee`, obj);

  }
  login(loginObj: any) {
    return this.http.post<any>(`${this.urlBase}authenticate`, loginObj)
      .pipe(
        tap((response) => {
          // Store the token
          this.storeToken(response.token);
          alert("prijava");
          // Update user information in the UserStoreService
          const fullNameFromToken = this.getFullNameFromToken();
          const roleFromToken = this.getRoleFromToken();
          const idFromToken = this.getIdFromToken();
          this.userStore.setNameFromStore(fullNameFromToken);
          this.userStore.setRoleFromStore(roleFromToken);
          this.userStore.setIdFromStore(idFromToken);
        })
      );
  }
  
  ExistMail(mail: any) {
    return this.http.post<string>(`${this.urlBase}CheckIfItExistEmail`, mail);
  }
  storeToken(tokenValue: string) {
    localStorage.setItem('token', tokenValue);
  }
  getToke() {
    return localStorage.getItem('token');
  }
  isLoggedIn(): boolean {
    //!! provjerava da li nesto postoji ukoliko je null vraca false, a ukoliko postoji vraca true
    return !!localStorage.getItem('token');
  }
  decodedToken() {
    const jwtHelper = new JwtHelperService();
    const token = this.getToke();
    return jwtHelper.decodeToken(token ?? '');
  }
  getFullNameFromToken() {
    if (this.userPayload) {
      return this.userPayload.unique_name;
    }
  }
  getRoleFromToken() {
    if (this.userPayload) {
      return this.userPayload.role;
    }
  }
  getIdFromToken() {
    if (this.userPayload) {
      return this.userPayload.UserID;
    }
  }
  singOut() {
    localStorage.clear();
    this.userStore.clearId();
    this.userStore.clearName();
    this.userStore.clearRole();
    this.router.navigate(['']);
  }
  generateUserPdf(userId: any) {
    return this.http.get(`https://localhost:7272/api/Users/generatePdf?id=`+userId,{observe:'response',responseType:'blob'});
  }
}
