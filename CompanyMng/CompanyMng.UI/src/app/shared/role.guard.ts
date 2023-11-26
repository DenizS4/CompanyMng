import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {Client} from "./Api";

export const roleGuard: CanActivateFn = (route, state) => {
  const router = inject(Router)
  const isLogged = JSON.parse(localStorage.getItem('isLogged')!);
  const role = JSON.parse(localStorage.getItem("Role")!);
  const service = inject(Client)

  if(isLogged && role==2)
    return true;
  else {
    router.navigate(["/dashboard"]);
    return false;
  }
};
