import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppConfig } from 'src/app/configs/app-config';

@Injectable({
  providedIn: 'root'
})


export class UserService {
  private apiUrl = AppConfig.apiUrl;
  constructor(private http: HttpClient) { }

  removeUser(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/UsersControllers/${id}`);
  }
}
