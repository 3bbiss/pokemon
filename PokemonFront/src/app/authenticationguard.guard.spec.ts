import { TestBed } from '@angular/core/testing';

import { AuthenticationguardGuard } from './authenticationguard.guard';

describe('AuthenticationguardGuard', () => {
  let guard: AuthenticationguardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AuthenticationguardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
