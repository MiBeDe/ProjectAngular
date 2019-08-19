// Import Http / Injectable / Observable dependencies
import {Injectable} from '@angular/core'
import {HttpClient, HttpParams} from '@angular/common/http'
import {Observable} from 'rxjs'
import {map} from 'rxjs/operators'

// Import Model
import {Cliente} from './cliente.model'

//Import API
import {APP_API} from '../app.api'

@Injectable()
export class ClienteService{


  constructor(private http: HttpClient){}

  //LISTAR TODOS OS CLIENTES
  clientes(): Observable<Cliente[]>{
    let params: HttpParams = undefined
    return this.http.get<Cliente[]>(`${APP_API}/Cliente/ListarClientes`, {params: params})
  }

  //CADASTRAR CLIENTE
  cadastrarCliente(cliente: Cliente): Observable<string>{
    return this.http.post<Cliente>(`${APP_API}/Cliente/InserirCliente`, cliente)
      .pipe(map(cliente => cliente.idCliente))

  }
  // PESQUISAR CLIENTE POR ID
  obterClienteById(idCliente: string): Observable<Cliente>{
    return this.http.get<Cliente>(`${APP_API}/Cliente/ObterCliente/${idCliente}`)
  }

  //ALTERAR CLIENTE
  alterarCliente(cliente: Cliente): Observable<string>{
    return this.http.put<Cliente>(`${APP_API}/Cliente/AlterarCliente`, cliente)
      .pipe(map(cliente => cliente.idCliente))
  }


  //EXCLUIR CLIENTE
  deleteCliente(idCliente: string): Observable<Cliente>{
    return this.http.delete<Cliente>(`${APP_API}/Cliente/DeleteCliente/${idCliente}`)
  }
}
