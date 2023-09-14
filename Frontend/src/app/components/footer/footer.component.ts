import { Component, HostListener, ElementRef } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css'],
})
export class FooterComponent {
  showFooter: boolean = false;

  constructor(private elementRef: ElementRef, private router: Router) {}

  @HostListener('window:scroll')
  onScroll() {
    this.checkFooterVisibility();
  }

  private checkFooterVisibility() {
    const scrollPosition =
      window.pageYOffset ||
      document.documentElement.scrollTop ||
      document.body.scrollTop;
    const windowHeight =
      window.innerHeight ||
      document.documentElement.clientHeight ||
      document.body.clientHeight;
    const bodyHeight =
      this.elementRef.nativeElement.ownerDocument.documentElement.scrollHeight;

    if (scrollPosition + windowHeight >= bodyHeight) {
      this.showFooter = true;
    } else {
      this.showFooter = false;
    }
  }

  onAboutUs(event: Event) {
    event.preventDefault();
    this.router.navigate(['/app-about-us']);
    window.scrollTo(0, 0); 
  }
  onHome(event: Event) {
    event.preventDefault();
    window.scrollTo(0, 0); 
    this.router.navigate(['']);
    window.scrollTo(0, 0); 
  }
  onOffer(event: Event) {
    event.preventDefault();
    this.router.navigate(['/app-offer']);
    window.scrollTo(0, 0); 
  }
  onLiveChat(event: Event) {
    event.preventDefault();
    this.router.navigate(['/app-live-chat']);
    window.scrollTo(0, 0); 
  }
}
