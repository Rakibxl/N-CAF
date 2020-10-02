import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationUserRoleMappingComponent } from './application-user-role-mapping.component';

describe('ApplicationUserRoleMappingComponent', () => {
  let component: ApplicationUserRoleMappingComponent;
  let fixture: ComponentFixture<ApplicationUserRoleMappingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationUserRoleMappingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationUserRoleMappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
