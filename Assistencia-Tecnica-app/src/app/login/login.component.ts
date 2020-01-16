import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { Router, RouterLink } from '@angular/router';
import { AuthService } from './Auth.service';
import { UsuarioService } from '../_Services/Usuario.service';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  router: Router;
  constructor(private usuarioService: UsuarioService, router: Router) { this.router = router; }

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  hide = true;

  ngOnInit() {
  }

  exibirUsuarios() {
    this.router.navigate(['/usuarios']);
  }

}
