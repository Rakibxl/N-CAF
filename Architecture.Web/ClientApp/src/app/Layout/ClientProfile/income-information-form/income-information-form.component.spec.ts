import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncomeInformationFormComponent } from './income-information-form.component';

describe('IncomeInformationFormComponent', () => {
  let component: IncomeInformationFormComponent;
  let fixture: ComponentFixture<IncomeInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncomeInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncomeInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
