import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import { Player } from '../models/player';


@Injectable({
  providedIn: 'root'
})
export class PlayerService {

  private baseUri: string;
  private headers: HttpHeaders;
  constructor(private _http: HttpClient) {
    this.baseUri = environment.api + 'Player';
    this.headers = new HttpHeaders().append('Content-Type', 'application/json');

  }

  getList(): Observable<Player[]> {
    return this._http.get<Player[]>(this.baseUri);
  }

  get(id: string): Observable<Player> {
    return this._http.get<Player>(`${this.baseUri}/${id}`);
  }

  insert(player: Player): Observable<Player> {
    return this._http.post<Player>(this.baseUri, player);
  }

  update(id: string, player: Player): Observable<any> {
    return this._http.put(`${this.baseUri}/${id}`, player);
  }

  delete(id: string): Observable<any> {
    return this._http.delete(`${this.baseUri}/${id}`);
  }
}
