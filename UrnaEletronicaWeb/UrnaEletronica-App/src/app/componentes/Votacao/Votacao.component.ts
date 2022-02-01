import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Candidato } from 'src/app/models/Candidato';
import { Voto } from 'src/app/models/Voto';
import { CandidatoService } from 'src/app/service/Candidato.service';
import { VotoService } from 'src/app/service/Voto.service';

@Component({
  selector: 'app-Votacao',
  templateUrl: './Votacao.component.html',
  styleUrls: ['./Votacao.component.scss']
})
export class VotacaoComponent implements OnInit {

  constructor(private candidatoService: CandidatoService,
    private router: Router,
    private votoService: VotoService,
    private toastr: ToastrService
    ) { }

  ngOnInit() {
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


  votoValido = false;
  public get filtroCandidato(){
    return this._filtroCandidato;
  }

  candidatoFiltrado = {} as Candidato;
  buscarCandidato(filterId: number): any{
    this.candidatoFiltrado = {} as Candidato;
    this.candidatoService.Candidato(filterId).subscribe(
      (candidato: Candidato) => {
          this.candidatoFiltrado = candidato;
          this.votoValido = true;
      },
      (error: Error) => {
        this.votoValido = false,
        console.error(error)
      }
    ).add(()=>{});
  }

  voto = {} as Voto;
  public votoEmbranco(): void{
  var votoEmBranco = 8;

  this.voto.CandidatoId = votoEmBranco;

    if(this.candidatoFiltrado != null){
      this.votoService.Votar(this.voto).subscribe(
        () => {
          this.toastr.success('Voto confirmado!', 'Sucesso');
          this.router.navigate([`apuracao`]);
        },
        (error: Error) => {
          this.toastr.error('Erro ao votar', 'Error');
          console.error(error);

        }
      );
    }
  }

  public corrigir():void{

    this.router.navigate(['votacao'])
  .then(() => {
    window.location.reload();
  });
  }

  public votar():void{
    var legendaid = parseInt(this._filtroCandidato);
    this.voto.CandidatoId = legendaid;

    if(this.candidatoFiltrado != null){
      this.votoService.Votar(this.voto).subscribe(
        () => {
          this.toastr.success('Voto confirmado!', 'Sucesso');
          this.router.navigate([`apuracao`]);
        },
        (error: Error) => {
          this.toastr.error('Erro ao votar', 'Error');
          console.error(error);

        }
      );
    }
  }

}
