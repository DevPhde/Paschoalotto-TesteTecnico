import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailUserModalComponent } from './detail-user-modal.component';

describe('DetailUserModalComponent', () => {
  let component: DetailUserModalComponent;
  let fixture: ComponentFixture<DetailUserModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DetailUserModalComponent]
    });
    fixture = TestBed.createComponent(DetailUserModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
