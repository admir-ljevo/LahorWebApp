import { TestBed } from '@angular/core/testing';

import { KlijentFizickoService } from './klijent-fizicko.service';

describe('KlijentFizickoService', () => {
  let service: KlijentFizickoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KlijentFizickoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
