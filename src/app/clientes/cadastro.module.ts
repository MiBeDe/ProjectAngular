import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'

import {CommonModule} from '@angular/common'
import {SharedModule} from '../shared/shared.module'

import {CadastroComponent} from './cadastro/cadastro.component'

const ROUTES: Routes = [
  {path: '', component: CadastroComponent}
]

@NgModule({
  declarations: [CadastroComponent],
  imports: [SharedModule, RouterModule.forChild(ROUTES)]
})

export class CadastroModule {}
