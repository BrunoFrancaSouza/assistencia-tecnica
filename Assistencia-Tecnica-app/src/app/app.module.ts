import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient } from 'selenium-webdriver/http';

import { HttpClientModule } from '@angular/common/http';
import { UsuarioComponent } from './usuario/usuario.component';

@NgModule({
   declarations: [
      AppComponent,
      UsuarioComponent
   ],
   imports: [
      AppRoutingModule,
      BrowserModule,
      HttpClientModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
