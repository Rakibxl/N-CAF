import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentOfferComponent } from './current-offer.component';

describe('CurrentOfferComponent', () => {
  let component: CurrentOfferComponent;
  let fixture: ComponentFixture<CurrentOfferComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrentOfferComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
