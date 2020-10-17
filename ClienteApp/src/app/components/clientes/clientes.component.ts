import { Component, OnInit,Pipe ,PipeTransform } from '@angular/core';
import {ClienteService} from '../../services/cliente.service'
import { Cliente } from '../../models/cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  clientes:Cliente[];
  constructor(private fs:ClienteService) { }

  ngOnInit(): void {
    this.fs.getClientes().subscribe(a=>{this.clientes=a});

  }

}
