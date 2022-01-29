import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()

export class CandidatoService {

  baseURL = 'https://localhost:5001/api/Candidato';

  constructor(private http: HttpClient) {}



}
