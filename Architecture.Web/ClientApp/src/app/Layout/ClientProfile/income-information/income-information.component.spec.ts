import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncomeInformationComponent } from './income-information.component';

describe('IncomeInformationComponent', () => {
  let component: IncomeInformationComponent;
  let fixture: ComponentFixture<IncomeInformationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncomeInformationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncomeInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
