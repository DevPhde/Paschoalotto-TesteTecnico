import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InteractionService {

  constructor() { }

  public users = new BehaviorSubject<any[]>([]);
  setUsers(users: any[]) {
    this.users.next(users);
  }
}
