import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FamilyInformationFormComponent } from './family-information-form.component';

describe('FamilyInformationFormComponent', () => {
  let component: FamilyInformationFormComponent;
  let fixture: ComponentFixture<FamilyInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FamilyInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FamilyInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
