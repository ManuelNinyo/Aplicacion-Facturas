import { Component, OnInit } from '@angular/core';
import { Cliente } from '../../models/cliente';
import { ClienteService } from '../../services/cliente.service'
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent implements OnInit {
  cliente: Cliente;

  constructor(private clienteService: ClienteService,
    private router: Router) {
    this.cliente = new Cliente();
  }

  ngOnInit(): void {
  }
  public onSubmit(f: NgForm) {
    this.clienteService.postCliente(this.cliente).subscribe();
    this.router.navigate(['Clientes']);
    alert("Cliente agregado");


  }
}
