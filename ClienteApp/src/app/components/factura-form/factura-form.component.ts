import { Component, OnInit } from '@angular/core';
import { Factura } from '../../models/factura';
import { FacturaServiceService } from '../../services/factura-service.service';
import { ClienteService } from '../../services/cliente.service'
import { FormControl, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-factura-form',
  templateUrl: './factura-form.component.html',
  styleUrls: ['./factura-form.component.css']
})
export class FacturaFormComponent implements OnInit {
  factura: Factura;
  cliente: Cliente;
  id: string;
  constructor(private route: ActivatedRoute,
    private clienteService: ClienteService,
     private facturaService: FacturaServiceService,
    private router:Router) {
    this.cliente = new Cliente();
    this.factura = new Factura;
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id']
    });
    this.clienteService.getCliente(this.id).subscribe(a => {
      this.cliente = a;
      this.factura.cliente = this.cliente;
    });
    
  }
  onSubmit(f: NgForm) {
    this.facturaService.postFactura(this.factura).subscribe();
    this.router.navigate(['Clientes',this.id]);
    alert("factura creada");


  }

}
