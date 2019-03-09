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
  FiltroLista = '';

  ngOnInit() {
    this.getUsuarios();
  }

  getUsuarios() {
    this.http.get('http://localhost:5000/api/values').subscribe(
      response => { this.Usuarios = response; },
      error => { console.log(error); }
      );
  }

}
