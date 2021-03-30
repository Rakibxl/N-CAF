import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientProfileCollectionComponent } from './client-profile-collection.component';

describe('ClientProfileCollectionComponent', () => {
  let component: ClientProfileCollectionComponent;
  let fixture: ComponentFixture<ClientProfileCollectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ClientProfileCollectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientProfileCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
