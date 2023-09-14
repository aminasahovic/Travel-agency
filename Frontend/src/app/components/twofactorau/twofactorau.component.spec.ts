import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwofactorauComponent } from './twofactorau.component';

describe('TwofactorauComponent', () => {
  let component: TwofactorauComponent;
  let fixture: ComponentFixture<TwofactorauComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TwofactorauComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TwofactorauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
