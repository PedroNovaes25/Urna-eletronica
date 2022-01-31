import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApuracaoComponent } from './componentes/Apuracao/Apuracao.component';
import { CadastroCandidatoComponent } from './componentes/cadastroCandidato/cadastroCandidato.component';
import { CandidatosComponent } from './componentes/Candidatos/Candidatos.component';
import { VotacaoComponent } from './componentes/Votacao/Votacao.component';

const routes: Routes = [
    {path: 'candidatos', component: CandidatosComponent},
    {path: 'votacao', component: VotacaoComponent},
    {path: 'apuracao', component: ApuracaoComponent},
    {path: 'cadastroCandidato', component: CadastroCandidatoComponent},
    {path: '', redirectTo:'candidatos', pathMatch: 'full'},
    {path: '**', redirectTo:'candidatos', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
