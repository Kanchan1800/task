import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardsmainComponent } from './cardsmain.component';

describe('CardsmainComponent', () => {
  let component: CardsmainComponent;
  let fixture: ComponentFixture<CardsmainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardsmainComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardsmainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
