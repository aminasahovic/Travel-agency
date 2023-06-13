import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminOfferPageComponent } from './admin-offer-page.component';

describe('AdminOfferPageComponent', () => {
  let component: AdminOfferPageComponent;
  let fixture: ComponentFixture<AdminOfferPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminOfferPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminOfferPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
