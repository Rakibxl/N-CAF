import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionInformationFormComponent } from './question-information-form.component';

describe('QuestionInformationFormComponent', () => {
  let component: QuestionInformationFormComponent;
  let fixture: ComponentFixture<QuestionInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuestionInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
