import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Candidatos',
  templateUrl: './Candidatos.component.html',
  styleUrls: ['./Candidatos.component.scss']
})
export class CandidatosComponent implements OnInit {

  public candidatos: any;

  constructor(private http: HttpClientModule) { }

  ngOnInit() {
    this.getCandidatos();
  }

  public getCandidatos(): void{

    this
    this.candidatos =
      [
        {
          Candidato: 'Pedro',
          Legenda: 'LSP'
        },
        {
          Candidato: 'Barbara',
          Legenda: 'TTT'
        },
        {
          Candidato: 'Barbara',
          Legenda: 'AAA'
        },
        {
          Candidato: 'Barbara',
          Legenda: 'LLL'
        },
      ]

  }

}
