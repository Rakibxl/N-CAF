import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseRentInformationComponent } from './house-rent-information.component';

describe('HouseRentInformationComponent', () => {
  let component: HouseRentInformationComponent;
  let fixture: ComponentFixture<HouseRentInformationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HouseRentInformationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseRentInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
