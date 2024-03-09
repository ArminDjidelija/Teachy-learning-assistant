import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfesorPocetnaComponent } from './profesor-pocetna.component';

describe('ProfesorPocetnaComponent', () => {
  let component: ProfesorPocetnaComponent;
  let fixture: ComponentFixture<ProfesorPocetnaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfesorPocetnaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProfesorPocetnaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
