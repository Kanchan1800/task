import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WalkinInfoComponent } from './walkin-info.component';

describe('WalkinInfoComponent', () => {
  let component: WalkinInfoComponent;
  let fixture: ComponentFixture<WalkinInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WalkinInfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WalkinInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
