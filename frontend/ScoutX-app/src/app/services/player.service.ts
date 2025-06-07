import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

export interface PlayerDto{
  id: string;
  firstName: string;
  lastName: string;
  position: string;
  marketValue: number;
}

@Injectable({
  providedIn: 'root'
})

export class PlayerService {
  private apiUrl = 'http://localhost:5001/api/players';

  constructor(private http: HttpClient) { }

  getAllPlayers(): Observable<PlayerDto[]> {
    return this.http.get<PlayerDto[]>(this.apiUrl);
  }
}
