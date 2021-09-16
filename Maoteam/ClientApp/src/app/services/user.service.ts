﻿import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@env/environment';
import { User } from '../models/user';
import { UserViewModel } from '../backmodels/user.model';

@Injectable({ providedIn: 'root' })
export class UserService {
  private _urlPrefix = `${environment.apiUrl}/api/account`;

  constructor(private _http: HttpClient) {}

  public getAll() {
      return this._http.get<User[]>(`${environment.apiUrl}/users`);
  }

  public getProfile() {
    return this._http.get<UserViewModel>(this._urlPrefix);
  }
}
