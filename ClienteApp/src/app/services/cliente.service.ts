import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cliente } from '../models/cliente';
@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) { }
  getClientes(){
    return this.http.get<Cliente[]>("https://localhost:44396/api/Clientes");
  }
  getCliente(id:string){
    return this.http.get<Cliente>("https://localhost:44396/api/Clientes/"+id);
  }
  postCliente(cliente:Cliente){
    return this.http.post<Cliente>("https://localhost:44396/api/Clientes/",cliente);
  }
}
