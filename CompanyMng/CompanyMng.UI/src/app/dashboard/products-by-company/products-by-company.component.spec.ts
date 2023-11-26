import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsByCompanyComponent } from './products-by-company.component';

describe('ProductsByCompanyComponent', () => {
  let component: ProductsByCompanyComponent;
  let fixture: ComponentFixture<ProductsByCompanyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductsByCompanyComponent]
    });
    fixture = TestBed.createComponent(ProductsByCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
