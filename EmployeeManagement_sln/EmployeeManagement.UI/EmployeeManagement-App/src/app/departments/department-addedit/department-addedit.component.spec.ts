import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepartmentAddeditComponent } from './department-addedit.component';

describe('DepartmentAddeditComponent', () => {
  let component: DepartmentAddeditComponent;
  let fixture: ComponentFixture<DepartmentAddeditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DepartmentAddeditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepartmentAddeditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
