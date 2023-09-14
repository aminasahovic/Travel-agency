import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserStoreService {
  private fullName$ = new BehaviorSubject<string>("");
  private role$ = new BehaviorSubject<string>("");
  private id$ = new BehaviorSubject<string>("");

  constructor() { }

  public getRoleFromStore() {
    return this.role$.asObservable();
  }

  public getIdFromStore() {
    return this.id$.asObservable();
  }

  public setRoleFromStore(role: string) {
    this.role$.next(role);
  }

  public getNameFromStore() {
    return this.fullName$.asObservable();
  }

  public setNameFromStore(name: string) {
    this.fullName$.next(name);
  }

  public setIdFromStore(id: string) {
    this.id$.next(id);
  }

  // Clear user information methods
  public clearRole() {
    this.role$.next("");
  }

  public clearName() {
    this.fullName$.next("");
  }

  public clearId() {
    this.id$.next("");
  }
}
