import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasicUserDashboardComponent } from './basic-user-dashboard.component';

describe('BasicUserDashboardComponent', () => {
  let component: BasicUserDashboardComponent;
  let fixture: ComponentFixture<BasicUserDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BasicUserDashboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BasicUserDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
