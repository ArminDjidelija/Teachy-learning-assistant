import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfesorPageComponent } from './profesor-page.component';

describe('ProfesorPageComponent', () => {
  let component: ProfesorPageComponent;
  let fixture: ComponentFixture<ProfesorPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProfesorPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProfesorPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
