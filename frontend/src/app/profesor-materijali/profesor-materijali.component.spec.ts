import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfesorMaterijaliComponent } from './profesor-materijali.component';

describe('ProfesorMaterijaliComponent', () => {
  let component: ProfesorMaterijaliComponent;
  let fixture: ComponentFixture<ProfesorMaterijaliComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfesorMaterijaliComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProfesorMaterijaliComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
