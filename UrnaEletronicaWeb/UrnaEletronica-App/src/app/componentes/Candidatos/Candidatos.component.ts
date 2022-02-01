import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Candidato } from 'src/app/models/Candidato';

import { CandidatoService } from 'src/app/service/Candidato.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { VotoService } from 'src/app/service/Voto.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-Candidatos',
  templateUrl: './Candidatos.component.html',
  styleUrls: ['./Candidatos.component.scss']
})
export class CandidatosComponent implements OnInit {
  modalRef?: BsModalRef;
  public candidatos: Candidato[] =[];
  public legendaId: number = 0;

  constructor(
     private candidatoService: CandidatoService,
     private votoService: VotoService,
     private modalService: BsModalService,
     private toastr: ToastrService) { }

  ngOnInit() {
    this.CarregarCandidatos();
  }

  public CarregarCandidatos(): void{

    this.candidatos = [];

   this.candidatoService.Candidatos().subscribe(
     (candidato: Candidato[])=>{

    candidato.forEach(cand =>{
      if(cand.legendaId > 9){
        this.candidatos.push(cand);
      }
    }
     );

      //  this.candidatos = candidato;
     },
     (error: any)=>{console.error(error)}
   ).add()

  }

  public reiniciarVotacao():void{
    this.votoService.reiniciarVotacao().subscribe(
      () => {
        this.toastr.success('Votação reiniciada!', 'Sucesso');
      },
      (error: Error) => {
        this.toastr.error('Não foi possível reiniciar votação!', 'Error');
        console.error(error)
      }
      );
  }


  openModal(event: any,template: TemplateRef<any>, legendaId: number) {
    event.stopPropagation();
    this.legendaId = legendaId;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();

    this.candidatoService.CandidaturaRemover(this.legendaId).subscribe(
      () => {

        this.toastr.success('Candidato deletado com sucesso!', 'Sucesso');
        this.CarregarCandidatos();
      },
      (error: Error) => {
        this.toastr.error('Erro ao deletar candidato!', 'Error');
        console.error(error)
      },
    );
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
