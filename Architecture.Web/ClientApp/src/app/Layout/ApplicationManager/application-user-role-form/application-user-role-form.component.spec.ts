import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationUserRoleFormComponent } from './application-user-role-form.component';

describe('ApplicationUserRoleFormComponent', () => {
  let component: ApplicationUserRoleFormComponent;
  let fixture: ComponentFixture<ApplicationUserRoleFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationUserRoleFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationUserRoleFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
