/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { VotoService } from './Voto.service';

describe('Service: Voto', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [VotoService]
    });
  });

  it('should ...', inject([VotoService], (service: VotoService) => {
    expect(service).toBeTruthy();
  }));
});
