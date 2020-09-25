import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PDFModifyComponent } from './pdfmodify.component';

describe('PDFModifyComponent', () => {
  let component: PDFModifyComponent;
  let fixture: ComponentFixture<PDFModifyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PDFModifyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PDFModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
