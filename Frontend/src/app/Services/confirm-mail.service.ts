import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfirmMailService {
  private baseUrl: string = "https://localhost:7272/api/Users"
  constructor(private http: HttpClient) { }
  //emailconfirm
  confirmMail(mail: string) {
    return this.http.post<any>(`${this.baseUrl}/emailconfirm/${mail}`, {});
  }
}
