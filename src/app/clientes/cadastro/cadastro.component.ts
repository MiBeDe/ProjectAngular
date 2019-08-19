import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, FormControl, Validators, AbstractControl, ReactiveFormsModule} from '@angular/forms'

import {Router} from '@angular/router'

import {Cliente} from '../cliente.model'
import {ClienteService} from '../cliente.service'

import {tap} from 'rxjs/operators'

//Notification SnackBar
import {NotificationService} from '../../shared/messages/notification.service'

@Component({
  selector: 'mt-cadastro',
  templateUrl: './cadastro.component.html'
})
export class CadastroComponent implements OnInit {

  cadastroForm: FormGroup

  clienteId: string

  constructor(private formBuilder: FormBuilder,
              private clienteService: ClienteService,
              private router: Router, private notificationService: NotificationService) { }

  ngOnInit() {
    this.cadastroForm = new FormGroup({
      // name: new FormControl('',{validators: [Validators.required, Validators.minLength(5)],
      // }),
      nome: this.formBuilder.control('',[Validators.required, Validators.minLength(2)]),
      sobrenome: this.formBuilder.control('',[Validators.required, Validators.minLength(2)]),
      rg: this.formBuilder.control('',[Validators.required, Validators.minLength(5)]),
      cpf: this.formBuilder.control('',[Validators.required, Validators.minLength(5)])
    }, {updateOn: 'blur'})
  }

  cadastrarCliente(cliente: Cliente){
    this.clienteService.cadastrarCliente(cliente)
      .pipe(tap((clienteId: string) => {
        this.clienteId = clienteId
      }))
        .subscribe((clienteId: string) => {
          this.router.navigate(['/clientes'])
        })
        this.notificationService.notify(`Cliente cadastrado com Sucesso!`)
  }

}
