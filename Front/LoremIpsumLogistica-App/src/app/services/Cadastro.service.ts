import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { Cadastro } from '../models/Cadastro';

@Injectable()
export class CadastroService {
  baseURL = environment.apiURL + 'api/cadastros';

  constructor(private http: HttpClient) {}

  public getCadastros(): Observable<Cadastro[]> {
    return this.http.get<Cadastro[]>(`${this.baseURL}`);
  }

  public getCadastroById(id: number): Observable<Cadastro> {
    return this.http.get<Cadastro>(`${this.baseURL}/${id}`);
  }

  public deleteCadastro(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`).pipe(take(1));
  }

  public post(cadastro: Cadastro): Observable<Cadastro> {
    return this.http
      .post<Cadastro>(this.baseURL, cadastro)
      .pipe(take(1));
  }

  public put(id: number, cadastro: Cadastro): Observable<Cadastro> {
    return this.http
      .put<Cadastro>(`${this.baseURL}/${id}`, cadastro)
      .pipe(take(1));
  }
}
