import {Component, OnInit} from '@angular/core';
import {Client} from "../../shared/Api";


@Component({
  selector: 'app-companiesbycountry',
  templateUrl: './companiesbycountry.component.html',
  styleUrls: ['./companiesbycountry.component.css']
})
export class CompaniesbycountryComponent implements OnInit{
  companies: any = [];

  constructor(private service: Client) {
  }
  ngOnInit(): void {
    this.service.getLatestCompany().subscribe(data => {
      this.companies = data;
    })
  }

}
