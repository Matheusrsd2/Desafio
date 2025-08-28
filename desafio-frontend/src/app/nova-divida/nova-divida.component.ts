import { Component } from '@angular/core';
import { TituloService } from '../services/Titulo.service';
import { Router } from '@angular/router';
declare var bootstrap: any;

@Component({
  selector: 'app-nova-divida',
  templateUrl: './nova-divida.component.html',
  styleUrls: ['./nova-divida.component.css']
})
export class NovaDividaComponent {

  
  titulo: any = {
    numero: '',
    devedor: '',
    cpf: '',
    valorOriginal: 0,
    valorAtualizado: 0,
    juros: 0,
    multa: 0,
    parcelas: [
      { numero: 1, valorParcela: 0, vencimento: '', diasAtraso: 0 }
    ]
  };

  constructor(private tituloService: TituloService, private router: Router) {}
  
  salvar() {
    this.tituloService.cadastrarTitulo(this.titulo).subscribe({
      next: () => {
        alert('Dívida cadastrada com sucesso!');
        // Fecha o modal manualmente
        const modalEl = document.getElementById('novaDividaModal');
        const modal = bootstrap.Modal.getInstance(modalEl!);
        modal?.hide();

        // Reset form
        this.titulo = { numero: null, devedor: '', cpf: '', juros: null, multa: null, parcelas: [] };
      },
      error: err => console.error(err)
    });
  }

  adicionarParcela() {
    this.titulo.parcelas.push({ numero: this.titulo.parcelas.length + 1, valorParcela: 0, vencimento: '', diasAtraso: 0 });
  }
}
