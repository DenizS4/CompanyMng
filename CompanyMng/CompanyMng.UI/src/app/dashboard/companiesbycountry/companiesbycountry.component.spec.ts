import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompaniesbycountryComponent } from './companiesbycountry.component';

describe('CompaniesbycountryComponent', () => {
  let component: CompaniesbycountryComponent;
  let fixture: ComponentFixture<CompaniesbycountryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CompaniesbycountryComponent]
    });
    fixture = TestBed.createComponent(CompaniesbycountryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
