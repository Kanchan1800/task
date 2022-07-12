import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WalkinInitialComponent } from './walkin-initial.component';

describe('WalkinInitialComponent', () => {
  let component: WalkinInitialComponent;
  let fixture: ComponentFixture<WalkinInitialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WalkinInitialComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WalkinInitialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
