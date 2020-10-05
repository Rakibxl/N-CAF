import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuranceInformationFormComponent } from './insurance-information-form.component';

describe('InsuranceInformationFormComponent', () => {
  let component: InsuranceInformationFormComponent;
  let fixture: ComponentFixture<InsuranceInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsuranceInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsuranceInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
