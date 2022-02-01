import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Candidato } from '../models/Candidato';

@Injectable()

export class CandidatoService {
  baseURL = 'https://localhost:5001/api/Candidato';

  constructor(private http: HttpClient) {}

  public Candidato(legendaId: number): Observable<Candidato>{
    return this.http.get<Candidato>(`${this.baseURL}/${legendaId}`);
  }

  public Candidatos (): Observable<Candidato[]>{
    return this.http.get<Candidato[]>(`${this.baseURL}`);
  }

  public Candidatar (candidato: Candidato): Observable<Candidato>{
    return this.http.post<Candidato>(`${this.baseURL}`, candidato);
    // return this.http.put<boolean>(`${this.baseUrl}`, voto).pipe(take(1));
  }

  public CandidaturaRemover (legendaId: number): Observable<boolean>{
    return this.http.delete<boolean>(`${this.baseURL}/${legendaId}`);
    // return this.http.delete<any>(`${this.baseUrl}/${eventoId}/${id}`).pipe(take(1));
  }

}
