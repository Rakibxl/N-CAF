import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EducationalInformationFormComponent } from './educational-information-form.component';

describe('EducationalInformationFormComponent', () => {
  let component: EducationalInformationFormComponent;
  let fixture: ComponentFixture<EducationalInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EducationalInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EducationalInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
