import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryarragmentComponent } from './historyarragment.component';

describe('HistoryarragmentComponent', () => {
  let component: HistoryarragmentComponent;
  let fixture: ComponentFixture<HistoryarragmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistoryarragmentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HistoryarragmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
