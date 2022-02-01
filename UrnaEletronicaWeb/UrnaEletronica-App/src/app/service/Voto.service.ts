import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Voto } from '../models/Voto';

@Injectable()
export class VotoService {

  baseUrl = 'https://localhost:5001/api/Voto';

  constructor(private http: HttpClient) { }


  public Votos(legendaId: number): Observable<Voto[]>{
    return this.http.get<Voto[]>(`${this.baseUrl}/${legendaId}`);
  }

  public Votar(voto: Voto): Observable<boolean>{
    return this.http.post<boolean>(`${this.baseUrl}`, voto);
    // return this.http.put<boolean>(`${this.baseUrl}`, voto).pipe(take(1));
  }

  public reiniciarVotacao (): Observable<boolean>{
    return this.http.delete<boolean>(`${this.baseUrl}/reiniciar`);
    // return this.http.delete<any>(`${this.baseUrl}/${eventoId}/${id}`).pipe(take(1));
  }

}
