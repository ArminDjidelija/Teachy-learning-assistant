import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfesorTestoviComponent } from './profesor-testovi.component';

describe('ProfesorTestoviComponent', () => {
  let component: ProfesorTestoviComponent;
  let fixture: ComponentFixture<ProfesorTestoviComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfesorTestoviComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProfesorTestoviComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
