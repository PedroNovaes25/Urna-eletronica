import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { ApuracaoComponent } from './componentes/Apuracao/Apuracao.component';
import { CandidatosComponent } from './componentes/Candidatos/Candidatos.component';
import { VotacaoComponent } from './componentes/Votacao/Votacao.component';

@NgModule({
  declarations: [
    AppComponent,

    ApuracaoComponent,
    CandidatosComponent,
    VotacaoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
