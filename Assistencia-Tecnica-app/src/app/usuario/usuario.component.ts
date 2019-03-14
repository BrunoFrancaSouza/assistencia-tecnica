import { Component, OnInit, ViewChild } from '@angular/core';

import { debug } from 'util';
import { UsuarioService } from '../_Services/Usuario.service';
import { Usuario } from '../_Models/Usuario';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  constructor( private usuarioService: UsuarioService ) { }

  Usuarios: Usuario[];
  UsuariosFiltrados: Usuario[];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource = new MatTableDataSource(this.UsuariosFiltrados);

  displayedColumns: string[] = ['id', 'userName', 'nome', 'sobrenome', 'empresa', 'email', 'perfil', 'ativo', 'dataAlteracao',
                                'alteradoPor'
                               ];

  filtro = '';
  get FiltrarPor(): string {
    return this.filtro;
  }

  set FiltrarPor(value: string) {
    this.filtro = value;
    this.UsuariosFiltrados = this.FiltrarPor ?  this.FiltrarUsuarios(this.filtro) : this.Usuarios;
  }


  ngOnInit() {
    this.dataSource.sort = this.sort;
    this.getAllUsuarios();
    // this.getUsuarioByID(6);
    // this.getUsuarioByNome('Bruno');
  }

  getAllUsuarios() {
    this.usuarioService.getAll().subscribe(
      (response: Usuario[]) => { this.Usuarios = response; this.UsuariosFiltrados = response; },
      error => { console.log(error); }
    );
  }

  getUsuarioByID(id: number) {
    // this.usuarioService.getById(id).subscribe(
    //   (response: Usuario) => { this.Usuarios = response; this.UsuariosFiltrados = response; },
    //   error => { console.log(error); }
    // );
  }

  getUsuarioByNome(nome: string) {
    // this.usuarioService.getByNome(nome).subscribe(
    //   (response: Usuario[]) => { this.Usuarios = response; this.UsuariosFiltrados = response; },
    //   error => { console.log(error); }
    // );
  }

  FiltrarUsuarios(filtro: string): Usuario[] {
    filtro = filtro.toLocaleLowerCase();
    return this.Usuarios.filter(
      usuario => usuario.nome.toLocaleLowerCase().indexOf(filtro) !== -1
    );

  }

}
