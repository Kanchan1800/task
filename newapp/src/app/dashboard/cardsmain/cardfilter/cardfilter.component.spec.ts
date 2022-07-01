import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardfilterComponent } from './cardfilter.component';

describe('CardfilterComponent', () => {
  let component: CardfilterComponent;
  let fixture: ComponentFixture<CardfilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CardfilterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CardfilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
