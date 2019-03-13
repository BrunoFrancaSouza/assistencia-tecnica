import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../_Models/Usuario';

@Injectable({
  providedIn: 'root' // Decorator para indicar que o serviço está disponível em toda a aplicação
})
export class UsuarioService {

  private baseURL = 'http://localhost:5000/api/usuarios';

  constructor( private http: HttpClient ) { }

  getAll(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.baseURL);
  }

  getById(id: number): Observable<Usuario> {
    return this.http.get<Usuario>(this.baseURL + '/' + id.toString());
  }

  getByNome(nome: string): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.baseURL + '/GetByNome/' + nome);
  }

}
