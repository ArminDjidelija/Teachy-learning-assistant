import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentZavrseniTestoviComponent } from './student-zavrseni-testovi.component';

describe('StudentZavrseniTestoviComponent', () => {
  let component: StudentZavrseniTestoviComponent;
  let fixture: ComponentFixture<StudentZavrseniTestoviComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentZavrseniTestoviComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StudentZavrseniTestoviComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
