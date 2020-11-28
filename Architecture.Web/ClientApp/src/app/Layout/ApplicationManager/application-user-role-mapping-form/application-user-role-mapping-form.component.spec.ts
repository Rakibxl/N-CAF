import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationUserRoleMappingFormComponent } from './application-user-role-mapping-form.component';

describe('ApplicationUserRoleMappingFormComponent', () => {
  let component: ApplicationUserRoleMappingFormComponent;
  let fixture: ComponentFixture<ApplicationUserRoleMappingFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationUserRoleMappingFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationUserRoleMappingFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
