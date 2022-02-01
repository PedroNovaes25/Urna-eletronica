import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Candidato } from 'src/app/models/Candidato';
import { CandidatoService } from 'src/app/service/Candidato.service';

@Component({
  selector: 'app-cadastroCandidato',
  templateUrl: './cadastroCandidato.component.html',
  styleUrls: ['./cadastroCandidato.component.scss']
})
export class CadastroCandidatoComponent implements OnInit {
  form!: FormGroup;

  constructor(private fb: FormBuilder,
    private candidatoService: CandidatoService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.Validation();
  }

  get f() : any{
    return this.form.controls;
  }

  public Validation():void{

    this.form = this.fb.group({
      nome : ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      nomeVice : ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      legenda : ['',[Validators.required, Validators.minLength(2), Validators.maxLength(4)]],
    });
  }

  private _candidato = {} as Candidato;

  public registrarCandidato(): void{
    if(this.form.valid){

      this._candidato.legenda = this.form.value.legenda;
      this._candidato.nome = this.form.value.nome;
      this._candidato.nomeVice = this.form.value.nomeVice;

      this.candidatoService.Candidatar(this._candidato).subscribe(
        () => {
          this.toastr.success('Candidato registrado!', 'Sucesso');
          this.router.navigate([`candidatos`]);

        },
        (error: Error) => {
          this.toastr.error('Erro ao registrar candidato', 'Sucesso');
          this.form.reset();
          console.error(error)
        }
        )
    }

  }

}
