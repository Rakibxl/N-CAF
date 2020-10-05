import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BankInformationFormComponent } from './bank-information-form.component';

describe('BankInformationFormComponent', () => {
  let component: BankInformationFormComponent;
  let fixture: ComponentFixture<BankInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BankInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BankInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
