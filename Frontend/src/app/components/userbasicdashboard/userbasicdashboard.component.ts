import { Component, ComponentFactoryResolver, ComponentRef, Injector, Input, ViewContainerRef } from '@angular/core';
import { Link } from '../admin-dashboard/admin-dashboard.component';
import { AdminOfferPageComponent } from '../admin-offer-page/admin-offer-page.component';
import { ArrangementFormComponentComponent } from '../arrangement-form-component/arrangement-form-component.component';
import { HttpClient } from '@angular/common/http';
import { AuthService } from 'src/app/Services/auth.service';
import { HistoryarragmentComponent } from '../historyarragment/historyarragment.component';
import { OfferComponent } from '../offer/offer.component';
import { LiveChatComponent } from '../pages/live-chat/live-chat.component';
import { AdminChatComponent } from '../admin-chat/admin-chat.component';
import { LocationComponent } from '../location-component/location-component.component';
import { ViewAccommodationComponent } from '../view-accommodation/view-accommodation.component';
import { SignalRService } from 'src/app/service/SignalRService';
import { ViewProfileComponent } from '../view-profile/view-profile.component';
import { UserOfferComponent } from '../user-offer/user-offer.component';
@Component({
  selector: 'app-userbasicdashboard',
  templateUrl: './userbasicdashboard.component.html',
  styleUrls: ['./userbasicdashboard.component.css']
})
export class UserbasicdashboardComponent {
  @Input() name: string = "";
  @Input() imgURL: string = "";
  @Input() userid: any = "";

  constructor(private auth: AuthService, public https: HttpClient,
    public s: SignalRService, private componentFactoryResolver: ComponentFactoryResolver,
    private injector: Injector, private viewContainerRef: ViewContainerRef) { }

  currentComponent: any;
  links: Link[] = [
    { icon: 'card_travel', label: 'Pregled ponude', component: 'employee-list' },
    { icon: 'history', label: 'Historija aranžmana', component: 'employee-add' },
    { icon: 'create', label: 'Kreiraj ponudu za sebe', component: 'offer-add' },
    { icon: 'forum', label: 'Pitaj agenciju', component: 'offer-list' },
    { icon: 'hotel', label: 'Smještaji', component: 'offer-list' },
    { icon: 'recent_actors', label: 'Moj profil', component: 'offer-list' },
    { icon: 'logout', label: 'Odjavi se', component: 'logut-list' },
  ];

  ngOnInit(): void {
    this.currentComponent = UserOfferComponent; 
  }

  onLinkClick(link: Link): void {

    switch (link.label) {

      case 'Pregled ponude':
        this.viewContainerRef.clear();
        this.currentComponent = UserOfferComponent;
        break;
      case 'Kreiraj ponudu za sebe':
        this.viewContainerRef.clear();
        this.currentComponent = ArrangementFormComponentComponent;
        break;
      case 'Historija aranžmana':
        this.viewContainerRef.clear();
        this.currentComponent = HistoryarragmentComponent;
        break;
      case 'Pitaj agenciju':
        this.viewContainerRef.clear();
        this.currentComponent = AdminChatComponent;
        break;
      case 'Smještaji':
        this.viewContainerRef.clear();
        this.currentComponent = ViewAccommodationComponent;
        this.viewContainerRef.clear();
        break;
      case 'Moj profil':
        this.currentComponent = null;
        this.viewContainerRef.clear();
        const userId = this.userid;
        const componentFactory = this.componentFactoryResolver.resolveComponentFactory(ViewProfileComponent);
        this.viewContainerRef.clear();
        const componentRef: ComponentRef<ViewProfileComponent> = this.viewContainerRef.createComponent(componentFactory);
        componentRef.instance.userId = userId;
        break;

      case 'Odjavi se':
        this.auth.singOut();
        break;
      default:
        this.viewContainerRef.clear();
        this.currentComponent = null;
    }


  }

}
