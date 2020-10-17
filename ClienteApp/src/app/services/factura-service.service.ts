import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Factura } from '../models/factura';
@Injectable({
  providedIn: 'root'
})
export class FacturaServiceService {

  constructor(private http: HttpClient) { }
  getfacturas(){
    return this.http.get<Factura[]>("https://localhost:44396/api/Facturas");
  }
  postFactura(factura:Factura){
    return this.http.post<Factura>("https://localhost:44396/api/Facturas",factura);
  }
  putFactura(id:string){
    return this.http.put<Factura>("https://localhost:44396/api/Facturas/"+id,new Factura());
  }
}
