import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrosComponent } from './components/cadastros/cadastros.component';

const routes: Routes = [
  { path: '', redirectTo: 'cadastros', pathMatch: 'full'},
  {
    path: 'cadastros', component: CadastrosComponent,
    // children: [
    //   { path: 'detalhe/:id', component: EventoDetalheComponent },
    //   { path: 'detalhe', component: EventoDetalheComponent },
    //   { path: 'lista', component: EventoListaComponent },
    // ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
