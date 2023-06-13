import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArrangementFormComponentComponent } from './arrangement-form-component.component';

describe('ArrangementFormComponentComponent', () => {
  let component: ArrangementFormComponentComponent;
  let fixture: ComponentFixture<ArrangementFormComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArrangementFormComponentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArrangementFormComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
