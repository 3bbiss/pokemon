import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamTestComponent } from './team-test.component';

describe('TeamTestComponent', () => {
  let component: TeamTestComponent;
  let fixture: ComponentFixture<TeamTestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeamTestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeamTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
