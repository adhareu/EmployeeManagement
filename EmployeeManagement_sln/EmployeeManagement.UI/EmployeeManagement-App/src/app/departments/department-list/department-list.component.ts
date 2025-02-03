import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { environment } from '../../../environments/environment';
import { RouterModule  } from '@angular/router';
@Component({
  selector: 'app-department-list',
  imports: [RouterModule],
  templateUrl: './department-list.component.html',
  styleUrl: './department-list.component.css'
})
export class DepartmentListComponent implements OnInit {
   departments:any;
   constructor(private httpService:HttpService )
   {

   }
  ngOnInit(): void {
   this.loadData();
  }

  loadData()
  {
    this.httpService.get(environment.base_Url,"departments/GetAll").subscribe(
      (res:any)=>{
        this.departments=res;
      }
    );
  }
  deleteData(id:any)
  {
    console.log(id);
    //this.httpService.delete(environment.base_Url,"departments/delete",id).subscribe(
      //(res:any)=>{
      //  this.loadData();
      //}
    //);
  }
}
