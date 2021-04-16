import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DocumentCollectionComponent } from './document-collection.component';

describe('DocumentCollectionComponent', () => {
  let component: DocumentCollectionComponent;
  let fixture: ComponentFixture<DocumentCollectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DocumentCollectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DocumentCollectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
