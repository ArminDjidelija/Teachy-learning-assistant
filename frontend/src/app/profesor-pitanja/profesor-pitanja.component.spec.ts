import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfesorPitanjaComponent } from './profesor-pitanja.component';

describe('ProfesorPitanjaComponent', () => {
  let component: ProfesorPitanjaComponent;
  let fixture: ComponentFixture<ProfesorPitanjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfesorPitanjaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProfesorPitanjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
