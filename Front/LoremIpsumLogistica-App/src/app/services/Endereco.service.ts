import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { Endereco } from '../models/Endereco';

@Injectable({
  providedIn: 'root',
})
export class EnderecoService {
  baseURL = environment.apiURL + 'api/enderecos';

  constructor(private http: HttpClient) {}

  public getEnderecosByIdCadastro(id: number): Observable<Endereco[]> {
    return this.http.get<Endereco[]>(`${this.baseURL}/cadastro-id/${id}`);
  }

  public getEnderecoById(id: number): Observable<Endereco> {
    return this.http.get<Endereco>(`${this.baseURL}/${id}`);
  }

  public deleteEndereco(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }

  public post(endereco: Endereco): Observable<Endereco> {
    return this.http
      .post<Endereco>(this.baseURL, endereco)
      .pipe(take(1));
  }

  public put(id: number, endereco: Endereco): Observable<Endereco> {
    return this.http
      .put<Endereco>(`${this.baseURL}/${id}`, endereco)
      .pipe(take(1));
  }
}
