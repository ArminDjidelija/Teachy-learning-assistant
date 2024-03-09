import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VirtualMentorComponent } from './virtual-mentor.component';

describe('VirtualMentorComponent', () => {
  let component: VirtualMentorComponent;
  let fixture: ComponentFixture<VirtualMentorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VirtualMentorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VirtualMentorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
