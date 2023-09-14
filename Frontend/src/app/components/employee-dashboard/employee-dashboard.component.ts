import { Component, Input } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { UserStoreService } from 'src/app/Services/user-store.service';

@Component({
  selector: 'app-employee-dashboard',
  templateUrl: './employee-dashboard.component.html',
  styleUrls: ['./employee-dashboard.component.css'],
})
export class EmployeeDashboardComponent {
  public role: string = '';
  @Input() name: string = '';
  @Input() imgURL: string = '';
  @Input() userid: any = '';
  showPopup = false;
  functionality: any = [
    { func: 'reservation', name: 'Kreiraj rezervaciju' },
    { func: 'registration', name: 'Registruj korisnika' },
    { func: 'add-destination', name: 'Dodaj destinaciju' },
    { func: 'reprot', name: 'Kreiraj izvještaj' },
  ];
  func!: any;
  constructor(private userStore: UserStoreService, private auth: AuthService) {}
  ngOnInit() {
    this.userStore.getRoleFromStore().subscribe((val) => {
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = roleFromToken || val;
    });
  }
  logOut() {
    this.auth.singOut();
  }
  openPopup(func: any) {
    this.showPopup = true;
    this.func = func;
  }
  onClosePopup() {
    this.showPopup = false;
  }
}
