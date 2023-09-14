import { MatDialog } from "@angular/material/dialog";
import { Component, Input } from '@angular/core';
import { EmployeeListComponent } from '../employee-list/employee-list.component';
import { AuthService } from 'src/app/Services/auth.service';
import { EmployeeFormComponent } from "../employee-form/employee-form.component";
// import { OfferComponent } from "../offer/offer.component";
import { AddDestinationComponent } from "../add-destination/add-destination.component";
import { AdminOfferPageComponent } from "../admin-offer-page/admin-offer-page.component";
import { AdminChatComponent } from "../admin-chat/admin-chat.component";
import { AccomodationComponent } from "../accomodation/accomodation.component";
import { CounterComponent } from "../counter/counter.component";
import { AdminUsersComponent } from "../admin-users/admin-users.component";
import { AdminLocationComponent } from "../admin-location/admin-location.component";
@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})

export class AdminDashboardComponent {
  @Input() name: string ="";
  @Input() imgURL: string ="";

  constructor(private dialog: MatDialog, private auth: AuthService) { }
  fullName = 'John Doe';
  showSettings = false;
  currentComponent: any;
  links: Link[] = [
    { icon: 'people', label: 'Pregled zaposlenika', component: 'employee-list' },
    { icon: 'person_add', label: 'Dodaj zaposlenika', component: 'employee-add' },
    { icon: 'menu_book', label: 'Pregled ponude', component: 'offer-list' },
    { icon: 'add', label: 'Dodaj ponudu', component: 'offer-add' },
    { icon: 'supervised_user_circle', label: 'Korisnici', component: 'admin-users' },
    { icon: 'hotel', label: 'Smještaj', component: 'accomodation' },
    { icon: 'add_location', label: 'Dodaj lokaciju', component: 'admin-location' },
    { icon: 'work', label: 'Šalter', component: 'counter' },
    { icon: 'message', label: 'Chat', component: 'admin-chat' },
    { icon: 'logout', label: 'Odjavi se', component: 'logut-list' },
  ];

  ngOnInit(){
    this.fullName=this.name;
    this.currentComponent = EmployeeListComponent; 
  }

  toggleSettings() {
    //const dialogRef = this.dialog.open();
  }

  onLinkClick(link: Link): void {
    this.showSettings = false;
    switch(link.label) {
      case 'Pregled zaposlenika':
        this.currentComponent = EmployeeListComponent;
        break;
        case 'Dodaj zaposlenika':
        this.currentComponent = EmployeeFormComponent;
        break;
        case 'Pregled ponude':
          this.currentComponent = AdminOfferPageComponent;
        break;
        case 'Korisnici':
          this.currentComponent = AdminUsersComponent;
        break;
        case 'Dodaj ponudu':
          this.currentComponent = AddDestinationComponent;
        break;
        case 'Dodaj lokaciju':
          this.currentComponent = AdminLocationComponent;
        break;
        case 'Odjavi se':
          this.auth.singOut();
        break;
        case 'Chat':
          this.currentComponent = AdminChatComponent;
        break;
        case 'Smještaj':
          this.currentComponent = AccomodationComponent;
        break;
        case 'Šalter':
          this.currentComponent = CounterComponent;
        break;
      default:
        this.currentComponent = null;
    }
  }
}

export interface Link {
  icon: string;
  label: string;
  component: string;
}






