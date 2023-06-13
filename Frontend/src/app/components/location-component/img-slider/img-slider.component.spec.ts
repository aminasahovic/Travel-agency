import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImgSliderComponent1 } from './img-slider.component';

describe('ImgSliderComponent', () => {
  let component: ImgSliderComponent1;
  let fixture: ComponentFixture<ImgSliderComponent1>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImgSliderComponent1 ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ImgSliderComponent1);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
