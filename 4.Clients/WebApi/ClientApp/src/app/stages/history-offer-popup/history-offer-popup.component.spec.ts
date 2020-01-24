import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoryOfferPopupComponent } from './history-offer-popup.component';

describe('HistoryOfferPopupComponent', () => {
  let component: HistoryOfferPopupComponent;
  let fixture: ComponentFixture<HistoryOfferPopupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HistoryOfferPopupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HistoryOfferPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
