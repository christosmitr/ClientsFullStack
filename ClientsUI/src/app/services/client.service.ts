import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private _http: HttpClient) { }

  addClient(data:any): Observable<any> {
    return this._http.post(`https://localhost:7299/api/Client
    `,data)
  }

  getClientList(): Observable<any> {
    return this._http.get(`https://localhost:7299/api/Client`);
  }

  updateClient(id: string,data: any): Observable<any> {
    return this._http.put(`https://localhost:7299/api/Client/${id}`,data);
  }

  deleteClient(id: string): Observable<any> {
    return this._http.delete(`https://localhost:7299/api/Client/${id}`);
  }
}
