import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IseeInformationFormComponent } from './isee-information-form.component';

describe('IseeInformationFormComponent', () => {
  let component: IseeInformationFormComponent;
  let fixture: ComponentFixture<IseeInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IseeInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IseeInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
