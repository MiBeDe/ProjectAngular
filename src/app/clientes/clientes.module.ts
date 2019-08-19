import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'
//Common module para renderizar
import {CommonModule} from '@angular/common'

import {ClientesComponent} from './clientes.component';

import {AgGridModule} from 'ag-grid-angular'

const ROUTES: Routes = [
  {path: '', component: ClientesComponent}
]

@NgModule({
  declarations:[ClientesComponent],
  imports: [CommonModule, AgGridModule.withComponents([]),
            RouterModule.forChild(ROUTES)]
})

export class ClientesModule {}
