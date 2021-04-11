import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CompleteOfferPdfComponent } from './complete-offer-pdf.component';

describe('CompleteOfferPdfComponent', () => {
  let component: CompleteOfferPdfComponent;
  let fixture: ComponentFixture<CompleteOfferPdfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CompleteOfferPdfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompleteOfferPdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
