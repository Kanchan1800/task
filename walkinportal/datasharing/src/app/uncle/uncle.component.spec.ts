import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UncleComponent } from './uncle.component';

describe('UncleComponent', () => {
  let component: UncleComponent;
  let fixture: ComponentFixture<UncleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UncleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UncleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
