import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { UsuarioComponent } from './usuario/usuario.component';
import { NavComponent } from './nav/nav.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Necessário para o Two Way Data Binding

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
// tslint:disable-next-line:max-line-length
import { MatFormFieldModule, MatInputModule, MatSelectModule, MatSortModule, MatPaginatorModule, MatPaginatorIntl, MatToolbarModule, MatListModule } from '@angular/material';
import {MatCardModule} from '@angular/material/card';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';


import { DateFormatPipePipe } from './_util/pipes/DateFormatPipe.pipe';
import { MatPaginatorIntlPtBR } from 'src/_MaterialTheme/MaterialTable/MatPaginatorIntl/MatPaginatorIntlPtBR';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';


@NgModule({
   declarations: [
      AppComponent,
      UsuarioComponent,
      NavComponent,
      DateFormatPipePipe,
      LoginComponent,
      HomeComponent
   ],
   imports: [
      AppRoutingModule,
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BrowserAnimationsModule,
      ReactiveFormsModule,
      MatButtonModule,
      MatTableModule,
      MatInputModule,
      MatFormFieldModule,
      MatSelectModule,
      MatPaginatorModule,
      MatSortModule,
      MatCardModule,
      MatIconModule,
      MatSidenavModule,
      MatToolbarModule,
      MatListModule
   ],
   providers: [
      { provide: MatPaginatorIntl, useValue: MatPaginatorIntlPtBR() }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
