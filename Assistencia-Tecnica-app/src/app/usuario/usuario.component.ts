import { Component, OnInit, ViewChild } from '@angular/core';

import { debug } from 'util';
import { UsuarioService } from '../_Services/Usuario.service';
import { Usuario } from '../_Models/Usuario';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  constructor( private usuarioService: UsuarioService ) { }

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  // isMobile = this.currentDisplay === 'mobile';

  // usuario = new Usuario();
  usuarios: Usuario[];
  usuariosFiltrados: Usuario[];

  filtrarPor: string;
  valorFiltro: string;

  dataSource: any;

  displayedColumns: string[] = ['id', 'userName', 'nome', 'sobrenome', 'empresa', 'email', 'perfil', 'ativo', 'dataAlteracao',
                                'alteradoPor'
                               ];

  ngOnInit() {
    this.getAllUsuarios();
    // this.getUsuarioByID(6);
    // this.getUsuarioByNome('Bruno');
  }

  get FiltrarPor(): string {
    return this.filtrarPor;
  }

  set FiltrarPor(value: string) {
    this.filtrarPor = value;
    this.dataSource = this.FiltrarPor ?  this.filtrarUsuarios(this.filtrarPor, this.valorFiltro) : this.usuarios;
  }

  get ValorFiltro(): string {
    return this.valorFiltro;
  }

  set ValorFiltro(value: string) {
    this.valorFiltro = value;
    this.dataSource = this.valorFiltro ?  this.filtrarUsuarios(this.filtrarPor, this.valorFiltro) : this.usuarios;
  }

  getAllUsuarios() {
    this.usuarioService.getAll().subscribe((response: Usuario[]) => {
      this.usuarios = response;
      this.usuariosFiltrados = response;

      this.dataSource = new MatTableDataSource(this.usuariosFiltrados);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    },
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

  filtrarUsuarios(filtro: string, valor: string): Usuario[] {
    if (!valor) {
      return this.usuarios;
    }

    if (valor) {
      valor = valor.toLocaleLowerCase();
    }
    if (filtro && valor) {
      return this.usuarios.filter(
        usuario =>  usuario.hasOwnProperty(filtro) &&
                    // usuario[filtro].toString().toLocaleLowerCase() === valor
                    usuario[filtro].toString().toLocaleLowerCase().indexOf(valor) !== -1
      );
    } else {
      return this.usuarios.filter(
        usuario =>  usuario.userName.toLocaleLowerCase().indexOf(valor) !== -1 ||
                    usuario.nome.toLocaleLowerCase().indexOf(valor) !== -1 ||
                    usuario.sobrenome.toLocaleLowerCase().indexOf(valor) !== -1 ||
                    (usuario.empresa && usuario.empresa.nomeFantasia.toLocaleLowerCase().indexOf(valor) !== -1) ||
                    usuario.email.toLocaleLowerCase().indexOf(valor) !== -1 ||
                    usuario.perfil.toLocaleLowerCase().indexOf(valor) !== -1 ||
                    // usuario.ativo.toLocaleLowerCase().indexOf(filtro) !== -1 ||
                    usuario.dataAlteracao.toString().toLocaleLowerCase().indexOf(valor) !== -1 ||
                    usuario.alteradoPor.toLocaleLowerCase().indexOf(valor) !== -1
      );
    }

  }
}
