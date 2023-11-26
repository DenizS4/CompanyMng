import { Injectable } from '@angular/core';
import {Client} from "./Api";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private isLogged = false;
  private authSecretKey = 'Bearer Token';

  constructor(private service: Client) {
    debugger;
    this.isLogged = JSON.parse(localStorage.getItem('isLogged')!);;
  }

  login(username: string, password: string): boolean {
    if (this.service.authUser(username, password).subscribe()) {
      this.isLogged = true;
      return true;
    } else {
      return false;
    }
  }

  isAuthenticatedUser(): boolean {
    return this.isLogged;
  }

  logout(): void {
    localStorage.removeItem("isLogged");
    this.isLogged = false;
  }

}
