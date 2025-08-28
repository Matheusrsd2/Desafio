import { Component, OnInit } from '@angular/core';
import { TituloService } from '../services/Titulo.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  titulos: any[] = []; // Agora espelha o model Titulo do backend

  constructor(private tituloService: TituloService) { }

  ngOnInit(): void {
    this.carregarTitulos();
  }

  carregarTitulos() {
    this.tituloService.listarTitulos().subscribe({
      next: (res) => this.titulos = res,
      error: (err) => console.error('Erro ao carregar títulos', err)
    });
  }
}
