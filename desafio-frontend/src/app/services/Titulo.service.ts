import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TituloService {

  private apiUrl = 'http://localhost:5175/api/titulo'; // <-- substitua pela URL real

  constructor(private http: HttpClient) { }

  listarTitulos(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  cadastrarTitulo(titulo: any) {
  return this.http.post<any>(this.apiUrl, titulo);
}

  // futuramente podemos adicionar métodos: criarDivida(), atualizarDivida(), deletarDivida()
}
