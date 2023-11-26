import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";

export const notAuthGuard: CanActivateFn = (route, state) => {
  const router = inject(Router)
  const isLogged = JSON.parse(localStorage.getItem('isLogged')!);

  if(!isLogged)
    return true;
  else {
    router.navigate(["/dashboard"]);
    return false;
  }
};
