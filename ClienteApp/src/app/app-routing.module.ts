import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FacturasComponent } from './components/facturas/facturas.component';
import { ClienteFormComponent } from './components/cliente-form/cliente-form.component';
import { FacturaFormComponent } from './components/factura-form/factura-form.component';
import { ClientesComponent } from './components/clientes/clientes.component';
const routes: Routes = [
  {path:"Clientes",component:ClientesComponent},
  {path:"Clientes/:id",component:FacturasComponent},
  {path:"Clientes/crearFactura/:id",component:FacturaFormComponent},
  {path:"clientes/crearCliente",component:ClienteFormComponent},
  {path:"**",redirectTo: 'Clientes', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
