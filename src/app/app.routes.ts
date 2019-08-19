import {Routes} from '@angular/router'

import {HomeComponent} from './home/home.component'
import {AlterarComponent} from './clientes/alterar/alterar.component'
export const ROUTES: Routes = [
  {path: '', component: HomeComponent},
  {path: 'clientes', loadChildren: './clientes/clientes.module#ClientesModule'},
  {path: 'cadastro', loadChildren: './clientes/cadastro.module#CadastroModule'},
  {path: 'alterar/:idCliente', component: AlterarComponent },
]
