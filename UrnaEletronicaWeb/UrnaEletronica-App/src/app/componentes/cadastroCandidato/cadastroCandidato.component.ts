import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastroCandidato',
  templateUrl: './cadastroCandidato.component.html',
  styleUrls: ['./cadastroCandidato.component.scss']
})
export class CadastroCandidatoComponent implements OnInit {
  form!: FormGroup;

  constructor(private fb: FormBuilder) { }

  get f() : any{
    return this.form.controls;
  }


  ngOnInit() {
    this.Validation();
  }

  private Validation():void{
    this.form = this.fb.group({
      nome : ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      vice : ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      legenda : ['',[Validators.required, Validators.minLength(2), Validators.maxLength(4)]],
    })
  }

}
