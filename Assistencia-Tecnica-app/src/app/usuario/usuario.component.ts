import { Component, OnInit } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { debug } from 'util';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  constructor( private http: HttpClient ) { }

  Usuarios: any = [];
  UsuariosFiltrados: any = [];

  filtro = '';
  get FiltrarPor(): string {
    return this.filtro;
  }

  set FiltrarPor(value: string){
    // value = value.toLocaleLowerCase();
    this.filtro = value;
    this.UsuariosFiltrados = this.FiltrarPor ?  this.FiltrarUsuarios(this.filtro) : this.Usuarios;
  }


  ngOnInit() {
    this.getUsuarios();
  }

  getUsuarios() {
    this.http.get('http://localhost:5000/api/values').subscribe(
      response => { this.Usuarios = response; this.UsuariosFiltrados = response; },
      error => { console.log(error); }
    );
  }

  FiltrarUsuarios(filtro: string) {
    filtro = filtro.toLocaleLowerCase();
    return this.Usuarios.filter(
      usuario => usuario.nome.toLocaleLowerCase().indexOf(filtro) !== -1
    );

  }

}
