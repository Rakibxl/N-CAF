import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationUserRoleComponent } from './application-user-role.component';

describe('ApplicationUserRoleComponent', () => {
  let component: ApplicationUserRoleComponent;
  let fixture: ComponentFixture<ApplicationUserRoleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationUserRoleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationUserRoleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
