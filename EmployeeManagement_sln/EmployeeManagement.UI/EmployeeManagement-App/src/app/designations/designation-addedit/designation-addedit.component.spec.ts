import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesignationAddeditComponent } from './designation-addedit.component';

describe('DesignationAddeditComponent', () => {
  let component: DesignationAddeditComponent;
  let fixture: ComponentFixture<DesignationAddeditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DesignationAddeditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DesignationAddeditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
