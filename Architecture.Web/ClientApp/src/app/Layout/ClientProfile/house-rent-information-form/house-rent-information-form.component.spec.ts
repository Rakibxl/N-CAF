import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HouseRentInformationFormComponent } from './house-rent-information-form.component';

describe('HouseRentInformationFormComponent', () => {
  let component: HouseRentInformationFormComponent;
  let fixture: ComponentFixture<HouseRentInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HouseRentInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HouseRentInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
