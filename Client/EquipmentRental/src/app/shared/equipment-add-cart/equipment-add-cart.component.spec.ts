import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentAddCartComponent } from './equipment-add-cart.component';

describe('EquipmentAddCartComponent', () => {
  let component: EquipmentAddCartComponent;
  let fixture: ComponentFixture<EquipmentAddCartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EquipmentAddCartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EquipmentAddCartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
