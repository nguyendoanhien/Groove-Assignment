import { TestBed } from '@angular/core/testing';

import { UserProfileService } from './userprofile.service';

describe('UserProfileService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UserProfileService = TestBed.get(UserProfileService);
    expect(service).toBeTruthy();
  });
});
