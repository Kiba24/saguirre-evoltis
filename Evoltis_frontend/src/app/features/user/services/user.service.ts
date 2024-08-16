import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
    private apiUrl = 'https://localhost:7250/api/user';

    constructor(private http: HttpClient) {}
  
    getUserById(userId: string): Observable<User> {
      return this.http.get<User>(`${this.apiUrl}/${userId}`);
    }
  
    getUsers(): Observable<User[]> {
      return this.http.get<{ response: User[] }>(this.apiUrl).pipe(
        map(response => response.response) 
      );
    }

    createUser(user: User): Observable<any>{
      return this.http.post(this.apiUrl,user);
    }
  
}
