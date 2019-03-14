import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { UsuarioComponent } from './usuario/usuario.component';
import { NavComponent } from './nav/nav.component';

import { FormsModule } from '@angular/forms'; // Necessário para o Two Way Data Binding

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';

import { DateFormatPipePipe } from './_util/pipes/DateFormatPipe.pipe';


@NgModule({
   declarations: [
      AppComponent,
      UsuarioComponent,
      NavComponent,
      DateFormatPipePipe
   ],
   imports: [
      AppRoutingModule,
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      MatButtonModule,
      MatTableModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
