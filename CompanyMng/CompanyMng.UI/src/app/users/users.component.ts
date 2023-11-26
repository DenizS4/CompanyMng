import {Component, OnInit} from '@angular/core';
import {AddUserCommand, Client, Users, DeleteUserCommand, UpdateUserCommand} from "../shared/Api";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit{
  Us = new Users();
  users: any = [];
  ModalTitle = "";
  ActivateAddEdit = 0;
  constructor(private service: Client){
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(){
    this.service.user().subscribe(data => {
      this.users = data;
    });
  }

  addUsers(item: any){
    const dto = new AddUserCommand({
      user:item
    });
    this.service.addUser(dto).subscribe(data =>{
      window.location.reload();
    });
  }
  updateUsers(item: any){
    debugger;
    const dto = new UpdateUserCommand({
      user: item,
      id: item.id
    });
    this.service.updateUser(dto).subscribe(x => {
      window.location.reload();
    });
  }
  deleteUser(item: any){
    const dto = new DeleteUserCommand({
      user: item,
      id: item.id
    });
    if(confirm("Are you sure?")) {
      this.service.deleteUser(dto).subscribe(data => {
        alert("Deleted successfully");
        this.getUsers();
      });
    }
  }

  addClick() {
    this.ModalTitle = "Add Companies";
    this.ActivateAddEdit = 0;
  }
  editClick(item: any) {
    debugger;
    this.users= item;
    this.ModalTitle = "Edit Companies";
    this.ActivateAddEdit = 1;
  }
  closeClick() {
    this.ActivateAddEdit = 2;
    this.getUsers();
  }
}
