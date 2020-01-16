import { Injectable } from '@angular/core';

import { UsuarioService } from '../_Services/Usuario.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private usuarioService: UsuarioService) { }

  getUsuario(userName: string) {
    this.usuarioService.getByUserName(userName);
  }

}
