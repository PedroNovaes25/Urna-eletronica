import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ApuracaoComponent } from './componentes/Apuracao/Apuracao.component';
import { CandidatosComponent } from './componentes/Candidatos/Candidatos.component';
import { VotacaoComponent } from './componentes/Votacao/Votacao.component';

import {CandidatoService} from './service/Candidato.service';
import {VotoService} from './service/Voto.service';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,

    ApuracaoComponent,
    CandidatosComponent,
    VotacaoComponent,
      NavComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [
        CandidatoService, //Permite a classe ´EventoService´ ser injetada por qualquer um
        VotoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
