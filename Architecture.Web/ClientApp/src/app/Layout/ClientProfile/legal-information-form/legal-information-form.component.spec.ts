import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LegalInformationFormComponent } from './legal-information-form.component';

describe('LegalInformationFormComponent', () => {
  let component: LegalInformationFormComponent;
  let fixture: ComponentFixture<LegalInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LegalInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LegalInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
