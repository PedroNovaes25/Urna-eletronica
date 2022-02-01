import { Component, OnInit } from '@angular/core';
import { Candidato } from 'src/app/models/Candidato';
import { CandidatoService } from 'src/app/service/Candidato.service';

@Component({
  selector: 'app-Apuracao',
  templateUrl: './Apuracao.component.html',
  styleUrls: ['./Apuracao.component.scss']
})
export class ApuracaoComponent implements OnInit {
  public candidatos: Candidato[] =[];
  constructor(
    private candidatoService: CandidatoService
    ){ }

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



}
