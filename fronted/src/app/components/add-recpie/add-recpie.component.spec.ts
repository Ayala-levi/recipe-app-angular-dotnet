import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRecpieComponent } from './add-recpie.component';

describe('AddRecpieComponent', () => {
  let component: AddRecpieComponent;
  let fixture: ComponentFixture<AddRecpieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddRecpieComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddRecpieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
