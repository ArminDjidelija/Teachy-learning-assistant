import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentPocetnaComponent } from './student-pocetna.component';

describe('StudentPocetnaComponent', () => {
  let component: StudentPocetnaComponent;
  let fixture: ComponentFixture<StudentPocetnaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentPocetnaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StudentPocetnaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
