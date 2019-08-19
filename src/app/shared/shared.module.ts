import {NgModule, ModuleWithProviders} from '@angular/core'
import {CommonModule} from '@angular/common'
import {FormsModule, ReactiveFormsModule} from '@angular/forms'

// INPUTS (FORMS)
import {InputComponent} from './input/input.component'

// SERVICES
import {ClienteService} from '../clientes/cliente.service';
import { SnackbarComponent } from './messages/snackbar/snackbar.component'
import {NotificationService} from './messages/notification.service'

@NgModule({
  declarations: [InputComponent, SnackbarComponent],
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  exports: [InputComponent, CommonModule, FormsModule, ReactiveFormsModule,SnackbarComponent]
})

export class SharedModule {
  static forRoot(): ModuleWithProviders{
    return{
      ngModule: SharedModule,
      providers: [ClienteService, 
                  NotificationService]
    }
  }
}
