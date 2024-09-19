import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CepService {
  private viacepUrl = 'https://viacep.com.br/ws';

  constructor(private http: HttpClient) {}


  buscarCep(cep: string): Observable<any> {
    const url = `${this.viacepUrl}/${cep}/json`;
    return this.http.get<any>(url);
  }
}
