import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ApuracaoComponent } from './componentes/Apuracao/Apuracao.component';
import { CandidatosComponent } from './componentes/Candidatos/Candidatos.component';
import { VotacaoComponent } from './componentes/Votacao/Votacao.component';

import { CandidatoService } from './service/Candidato.service';
import { VotoService } from './service/Voto.service';
import { NavComponent } from '../shared/nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TituloComponent } from 'src/shared/titulo/titulo.component';

import { ToastrModule } from 'ngx-toastr';
import { CadastroCandidatoComponent } from './componentes/cadastroCandidato/cadastroCandidato.component';

@NgModule({
  declarations: [
    AppComponent,

    ApuracaoComponent,
    CandidatosComponent,
    TituloComponent,
    VotacaoComponent,
    CadastroCandidatoComponent,
      NavComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
  ],
  providers: [
        CandidatoService, //Permite a classe ´EventoService´ ser injetada por qualquer um
        VotoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
