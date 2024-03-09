import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterijaliStudentComponent } from './materijali-student.component';

describe('MaterijaliStudentComponent', () => {
  let component: MaterijaliStudentComponent;
  let fixture: ComponentFixture<MaterijaliStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MaterijaliStudentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MaterijaliStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
