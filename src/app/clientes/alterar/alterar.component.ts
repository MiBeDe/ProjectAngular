import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, FormControl, Validators, AbstractControl, ReactiveFormsModule} from '@angular/forms'

import {Router, ActivatedRoute} from '@angular/router'

import {Cliente} from '../cliente.model'

import {timer} from 'rxjs'

import {ClienteService} from  '../cliente.service'
import {NotificationService} from '../../shared/messages/notification.service'


import {tap, switchMap} from 'rxjs/operators'

@Component({
  selector: 'mt-alterar',
  templateUrl: './alterar.component.html'
})
export class AlterarComponent implements OnInit {

  cliente: Cliente
  alterarForm: FormGroup
  idCliente: string

  constructor(private clienteService: ClienteService,
              private actRoute: ActivatedRoute,
              private router: Router,
              private formBuilder: FormBuilder,
              private notificationService: NotificationService) { }

  ngOnInit() {

    //Pega uma foto das propriedades passadas sobre o Id recebido consultado o Service buscando dados do Backend
      this.clienteService.obterClienteById(this.actRoute.snapshot.params['idCliente'])
        .pipe(tap((cliente => this.cliente = cliente)),
          switchMap(loadData => timer(100))
        ).subscribe(loadData => this.dadosCarregados())



    this.alterarForm = new FormGroup({
      idCliente: this.formBuilder.control(''),
      nome: this.formBuilder.control(''),
      sobrenome: this.formBuilder.control(''),
      rg: this.formBuilder.control(''),
      cpf: this.formBuilder.control('')
    }, {updateOn: 'blur'})

  }

  //Carregar dados para preencher o form
  dadosCarregados(){
    this.alterarForm.setValue({
      idCliente: this.cliente.idCliente,
      nome: this.cliente.nome,
      sobrenome: this.cliente.sobrenome,
      rg: this.cliente.rg,
      cpf: this.cliente.cpf
    })

  }


  alterarCliente(cliente){
    this.clienteService.alterarCliente(cliente)
     .pipe(tap((idCliente: string) => {
       this.idCliente = this.cliente.idCliente
     }))
     .subscribe(() =>{
       this.router.navigate(['/clientes'])
     })
  }


}
