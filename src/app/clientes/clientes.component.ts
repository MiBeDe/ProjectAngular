// Dependecie Base / Observable
import { Component, OnInit } from '@angular/core';
import {Observable, timer} from 'rxjs'

//Import Model
import {Cliente} from './cliente.model'
import {NotificationService} from '../shared/messages/notification.service'
import {Router} from '@angular/router'

//Import Service
import {ClienteService} from './cliente.service'

import {tap, switchMap} from 'rxjs/operators'

@Component({
  selector: 'mt-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClientesComponent implements OnInit {

   clientes: Cliente[]
   private columnDefs;
   private gridApi;
   private gridColumnApi;
   private rowSelection;

   cliente: Cliente
   teste: boolean = false
   numeroRow: string = ''

  constructor(private clienteService: ClienteService,
              private notificationService: NotificationService,
              private router: Router) {
    //CRIANDO A TABELA PRA USAR
    this.columnDefs = [
      // {headerName: 'Id', field:'idCliente'},
      {headerName: 'Nome', field: 'nome', sortable:true, filter:true},
      {headerName: 'Sobrenome', field:'sobrenome'},
      {headerName: 'RG', field: 'rg', filter: true},
      {headerName: 'CPF', field: 'cpf'},

    ];
    this.rowSelection = "single"

  }
  ngOnInit() {

  }


  onSelectionChanged() {
      var selectedRows = this.gridApi.getSelectedRows();
      var selectedRowsString = "";
      selectedRows.forEach(function(selectedRow, index) {
        if (index !== 0) {
          selectedRowsString += ", ";
        }
        selectedRowsString += selectedRow.idCliente;
      });
      document.querySelector("#selectedRows").innerHTML = selectedRowsString;

      if(selectedRowsString !== undefined)
      {
          this.teste = true
          this.numeroRow = selectedRowsString
      }
    }

    onGridReady(params){
      this.gridApi = params.api
      this.gridColumnApi = params.columnApi;

      //CHAMADA GET PARA PEGAR TODOS OS CLIENTES
      this.clienteService.clientes()
         .subscribe(clientes => this.clientes = clientes)
    }

    // CHAMADA PARA DELETAR CLIENTE POR FUNÇÃO //
    deleteCliente(){
       this.clienteService.deleteCliente(this.numeroRow)
        .pipe(tap((cliente => this.cliente = cliente )),
          switchMap(reload => timer(1000))
       ).subscribe(reload => location.reload())
     }

     load(){
       location.reload()
     }

}
