import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserbasicdashboardComponent } from './userbasicdashboard.component';

describe('UserbasicdashboardComponent', () => {
  let component: UserbasicdashboardComponent;
  let fixture: ComponentFixture<UserbasicdashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserbasicdashboardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserbasicdashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
