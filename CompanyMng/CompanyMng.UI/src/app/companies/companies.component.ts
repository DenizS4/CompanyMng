import {Component, OnInit} from '@angular/core';
import {AddCompanyCommand, Client, Companies, DeleteCompanyCommand, UpdateCompanyCommand} from "../shared/Api";

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit{
  Cmp = new Companies();
  companies: any = [];
  ModalTitle = "";
  ActivateAddEdit = 0;
  constructor(private service: Client){
  }

  ngOnInit(): void {
    this.getCompanies();
  }

  getCompanies(){
    this.service.company().subscribe(data => {
      this.companies = data;
    });
  }

  addCompanies(item: any){
    const dto = new AddCompanyCommand({
      company:item
    });
    this.service.addCompany(dto).subscribe(data =>{
      window.location.reload();
    });
  }
  updateCompanies(item: any){
    const dto = new UpdateCompanyCommand({
      company: item,
      id: item.id
    });
    this.service.updateCompany(dto).subscribe(data =>{
      window.location.reload();
    })
  }
  deleteCompany(item: any){
    const dto = new DeleteCompanyCommand({
      company: item,
      id: item.id
    });
    if(confirm("Are you sure?")) {
      this.service.deleteCompany(dto).subscribe(data => {
        alert("Deleted successfully");
        this.getCompanies();

      });
    }
  }

  addClick() {
    this.ModalTitle = "Add Companies";
    this.ActivateAddEdit = 0;
  }
  editClick(item: any) {
    debugger;
    this.companies= item;
    this.ModalTitle = "Edit Companies";
    this.ActivateAddEdit = 1;
  }
  closeClick() {
    this.ActivateAddEdit = 2;
    this.getCompanies();
  }
}
