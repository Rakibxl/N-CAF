import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationAccessPermissionComponent } from './application-access-permission.component';

describe('ApplicationAccessPermissionComponent', () => {
  let component: ApplicationAccessPermissionComponent;
  let fixture: ComponentFixture<ApplicationAccessPermissionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationAccessPermissionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationAccessPermissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
