import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetInformationFormComponent } from './asset-information-form.component';

describe('AssetInformationFormComponent', () => {
  let component: AssetInformationFormComponent;
  let fixture: ComponentFixture<AssetInformationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssetInformationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssetInformationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
