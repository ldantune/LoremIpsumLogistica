import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrosComponent } from './components/cadastros/cadastros.component';
import { EnderecosComponent } from './components/enderecos/enderecos.component';

const routes: Routes = [
  { path: '', redirectTo: 'cadastros', pathMatch: 'full' },
  {
    path: 'cadastros',
    component: CadastrosComponent,
  },
  {
    path: 'cadastros/enderecos/:id',
    component: EnderecosComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
