/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CandidatoService } from './Candidato.service';

describe('Service: Candidato', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CandidatoService]
    });
  });

  it('should ...', inject([CandidatoService], (service: CandidatoService) => {
    expect(service).toBeTruthy();
  }));
});
