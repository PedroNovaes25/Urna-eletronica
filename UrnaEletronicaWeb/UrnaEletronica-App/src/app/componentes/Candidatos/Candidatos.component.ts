import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Candidato } from 'src/app/models/Candidato';

import { CandidatoService } from 'src/app/service/Candidato.service';

@Component({
  selector: 'app-Candidatos',
  templateUrl: './Candidatos.component.html',
  styleUrls: ['./Candidatos.component.scss']
})
export class CandidatosComponent implements OnInit {

  public candidatos: Candidato[] =[];

  constructor(
    private http: HttpClientModule,
     private candidatoService: CandidatoService) { }

  ngOnInit() {
    this.CarregarCandidatos();
  }

  public CarregarCandidatos(): void{

   this.candidatoService.Candidatos().subscribe(
     (candidato: Candidato[])=>{
       this.candidatos = candidato;
     },
     (error: any)=>{console.error(error)}
   ).add()

  }

  private _filtroCandidato: string = '';

  private _filtroA: string = '';
  private _filtroDeCandidatoA: string = '';
  public set filtroDeCandidatoA(filtro: string){
    this._filtroA = filtro;
    this._filtroCandidato = filtro + this._filtroB;
    this.buscarCandidato(parseInt(this._filtroCandidato));
  }

  public get filtroDeCandidatoA(){
    return this.filtroDeCandidatoB;
  }

  private _filtroB: string = '';
  private _filtroDeCandidatosB: string = '';
  public set filtroDeCandidatoB(filtro: string){
    this._filtroB = filtro;
    this._filtroCandidato = this._filtroA + filtro;
    this.buscarCandidato(parseInt(this._filtroCandidato));
  }


  public get filtroCandidato(){
    return this._filtroCandidato;
  }

  canditoFiltrado = {} as Candidato;
  buscarCandidato(filterId: number): any{
    this.canditoFiltrado = {} as Candidato;
    this.candidatoService.Candidato(filterId).subscribe(
      (candidato: Candidato) => {
          this.canditoFiltrado = candidato;
      },
      (error: Error) => {console.error(error)}
    ).add(()=>{});
  }

}
