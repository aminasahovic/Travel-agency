import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BasicUserDashboardComponent } from './components/basic-user-dashboard/basic-user-dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { AboutUsComponent } from './components/pages/about-us/about-us.component';
//import { OfferComponent } from './components/pages/offer/offer.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { ConfirmMailComponent } from './components/confirm-mail/confirm-mail.component';
import { OfferPageComponent } from './components/pages/offer-page/offer-page.component';
import { LiveChatComponent } from './components/pages/live-chat/live-chat.component';
import { LocationComponent } from './components/location-component/location-component.component';

const routes: Routes = [
  {
    path: 'user-dashboard',
    component: BasicUserDashboardComponent,
    canActivate: [AuthGuard],
  },
  { path: 'app-about-us', component: AboutUsComponent },
  { path: 'app-live-chat', component: LiveChatComponent },
  { path: 'app-offer', component: OfferPageComponent }, //dodaj nanovo ovu kompnentu svakko je bila prazna :))
  { path: '', component: HomeComponent },
  { path: 'reset', component: ResetPasswordComponent },
  { path: 'confirm', component: ConfirmMailComponent },
  { path: 'user-dashboard/test/:id', component: LocationComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
