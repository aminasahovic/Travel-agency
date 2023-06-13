import { NgModule } from '@angular/core';
import {  CheckboxControlValueAccessor, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSliderModule } from '@angular/material/slider';
import {MatButtonModule} from '@angular/material/button';
import { BrowserModule } from '@angular/platform-browser';
import { OfferComponent } from './components/offer/offer.component';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NavComponent} from "./nav/nav.component";
import {MatInputModule} from '@angular/material/input';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTabsModule} from '@angular/material/tabs';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { HttpClientModule } from '@angular/common/http';
import {MatCardModule} from '@angular/material/card';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { AppRoutingModule } from './app-routing.module';
import { BasicUserDashboardComponent } from './components/basic-user-dashboard/basic-user-dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { AboutUsComponent } from './components/pages/about-us/about-us.component';
import {MatIconModule} from '@angular/material/icon';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { ConfirmMailComponent } from './components/confirm-mail/confirm-mail.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { MatTableModule } from '@angular/material/table';
import { EmployeeFormComponent } from './components/employee-form/employee-form.component';
import { MatSelectModule } from '@angular/material/select';
import { DestinationCardComponent } from './components/destination-card/destination-card.component';
import { AddDestinationComponent } from './components/add-destination/add-destination.component';
import { PopUpComponent } from './components/pop-up/pop-up.component';
import { ImgSliderComponent } from './components/img-slider/img-slider.component';
import { OfferPageComponent } from './components/pages/offer-page/offer-page.component';
import { AdminOfferPageComponent } from './components/admin-offer-page/admin-offer-page.component';
import { LiveChatComponent } from './components/pages/live-chat/live-chat.component';
import { AdminChatComponent } from './components/admin-chat/admin-chat.component';
import { AccomodationComponent } from './components/accomodation/accomodation.component';
import { CounterComponent } from './components/counter/counter.component';
import { UserbasicdashboardComponent } from './components/userbasicdashboard/userbasicdashboard.component';
import { ArrangementFormComponentComponent } from './components/arrangement-form-component/arrangement-form-component.component';
import { HistoryarragmentComponent } from './components/historyarragment/historyarragment.component';
import { ImgSliderComponent1 } from './components/location-component/img-slider/img-slider.component';
import { LocationComponent } from './components/location-component/location-component.component';
import { ViewAccommodationComponent } from './components/view-accommodation/view-accommodation.component';
import { LocationPopupComponent } from './components/location-popup/location-popup.component';
import { ViewProfileComponent } from './components/view-profile/view-profile.component';
import { UserOfferComponent } from './components/user-offer/user-offer.component';
import { DestinationDetailComponent } from './components/destination-detail/destination-detail.component';
import { EmployeeDashboardComponent } from './components/employee-dashboard/employee-dashboard.component';
import { EmployeePopupComponent } from './components/employee-popup/employee-popup.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { ReportComponent } from './components/report/report.component';
import {MatExpansionModule} from '@angular/material/expansion';
import {Component, ViewChild} from '@angular/core';
import {MatAccordion, } from '@angular/material/expansion';
import {MatFormFieldModule} from '@angular/material/form-field';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    SignUpComponent,
    BasicUserDashboardComponent,
    HomeComponent,
    AboutUsComponent,
    OfferComponent,
    ResetPasswordComponent,
    ConfirmMailComponent,
    AdminDashboardComponent,
    EmployeeListComponent,
    EmployeeFormComponent,
    DestinationCardComponent,
    AddDestinationComponent,
    AddDestinationComponent,
    PopUpComponent,
    ImgSliderComponent,
    OfferPageComponent,
    AdminOfferPageComponent,
    LiveChatComponent,
    AdminChatComponent,
    AccomodationComponent,
    CounterComponent,
    UserbasicdashboardComponent,
    ArrangementFormComponentComponent,
    HistoryarragmentComponent,
    LocationComponent,
    ImgSliderComponent1,
    ViewAccommodationComponent,
    LocationPopupComponent,
    ViewProfileComponent,
    UserOfferComponent,
    DestinationDetailComponent,
    EmployeeDashboardComponent,
    EmployeePopupComponent,
    RegisterUserComponent,
    ReportComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatDialogModule,
    MatTabsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    HttpClientModule,
    MatCardModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatTableModule,
    MatSelectModule,
    MatSliderModule,
    MatExpansionModule


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
