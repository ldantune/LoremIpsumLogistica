import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastrosComponent } from './components/cadastros/cadastros.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { CadastroService } from './services/Cadastro.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsModalService } from 'ngx-bootstrap/modal';
import { DateFormatPipe } from './helpers/DateFormat.pipe';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';
import { EnderecosComponent } from './components/enderecos/enderecos.component';
import { EnderecoService } from './services/Endereco.service';
import { CepService } from './services/Cep.service';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';

@NgModule({
  declarations: [
    AppComponent,
    DateTimeFormatPipe,
    DateFormatPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CadastrosComponent,
    EnderecosComponent,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxMaskDirective
    
  ],
  providers: [
    CadastroService,
    EnderecoService,
    CepService,
    provideAnimationsAsync(),
    BsModalService,
    provideNgxMask({ /* opções de cfg */ })
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
