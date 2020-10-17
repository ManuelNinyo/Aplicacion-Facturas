import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Cliente } from '../../models/cliente';
import { ClienteService } from '../../services/cliente.service'
import { Factura } from '../../models/factura';
import { FacturaServiceService } from '../../services/factura-service.service';
@Component({
  selector: 'app-facturas',
  templateUrl: './facturas.component.html',
  styleUrls: ['./facturas.component.css']
})
export class FacturasComponent implements OnInit {
  id: string;
  cliente: Cliente;
  facturas: Factura[] = [];
  constructor(private route: ActivatedRoute,
    private clienteService: ClienteService,
     private facturaService: FacturaServiceService,
    private router:Router) {
    this.cliente = new Cliente();
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id']
    });
    this.clienteService.getCliente(this.id).subscribe(a => { this.cliente = a });
    this.facturaService.getfacturas().subscribe((a) => {
      for (let factura of a) {
        if (factura.cliente.id === this.id) {
          this.facturas.push(factura);
        }
      }
    });
  }
  onClick(facturaId:string){
    this.facturaService.putFactura(facturaId).subscribe();
    this.router.navigated = false;
    alert("recordatorio enviado")
    window.location.reload();
  }

}
