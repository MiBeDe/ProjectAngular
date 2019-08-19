import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { NgModule, LOCALE_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { RouterModule, PreloadAllModules } from '@angular/router';

import {LocationStrategy, HashLocationStrategy, registerLocaleData} from '@angular/common'
import locatePt from '@angular/common/locales/pt'
registerLocaleData(locatePt, 'pt')

//COMPONENTS
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component'
import { AlterarComponent } from './clientes/alterar/alterar.component'
// import { CadastroComponent } from './clientes/cadastro/cadastro.component'

// Imports
import {SharedModule} from './shared/shared.module'
import {ROUTES} from './app.routes';
// import { InputComponent } from './shared/input/input.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    AlterarComponent,
    // CadastroComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    SharedModule.forRoot(),
    RouterModule.forRoot(ROUTES, {preloadingStrategy: PreloadAllModules})
  ],
  providers: [{provide: LocationStrategy, useClass:HashLocationStrategy},{provide: LOCALE_ID, useValue: 'pt'},
              ],
  bootstrap: [AppComponent]
})
export class AppModule { }
