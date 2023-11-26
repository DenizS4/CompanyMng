import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {Client} from "./shared/Api";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'CompanyMng.UI';
  isLogged = false;
  role: any;

  constructor(private router: Router,private service: Client) {
  }
  ngOnInit(): void {
    this.isLogged = JSON.parse(localStorage.getItem('isLogged')!);
    this.role = JSON.parse(localStorage.getItem("Role")!);
    this.service.getUserByRole(localStorage.getItem("username")!).subscribe(data => {
      this.role = data;
      localStorage.setItem("Role", this.role);
    })
  }

logout(){
    this.isLogged = false;
    localStorage.setItem('isLogged', JSON.stringify(this.isLogged));
    this.router.navigate([""]);
}

}
