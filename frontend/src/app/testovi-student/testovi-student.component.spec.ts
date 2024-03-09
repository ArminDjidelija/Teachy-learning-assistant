import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestoviStudentComponent } from './testovi-student.component';

describe('TestoviStudentComponent', () => {
  let component: TestoviStudentComponent;
  let fixture: ComponentFixture<TestoviStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TestoviStudentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TestoviStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
