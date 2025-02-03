import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Params } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpService } from '../../services/http.service';
import { environment } from '../../../environments/environment';
@Component({
  selector: 'app-department-addedit',
  imports: [FormsModule],
  templateUrl: './department-addedit.component.html',
  styleUrl: './department-addedit.component.css'
})
export class DepartmentAddeditComponent implements OnInit {
title='Create New Deparment';
name='';
constructor(private route: ActivatedRoute,private httpService:HttpService ){}
ngOnInit(): void {
  this.route.params.subscribe((data: Params) => {
  
    this.title="Edit Department";
    this.getdata(data['id']);
    console.log(data);
  });
}
getdata(id:any)
{
  this.httpService.get(environment.base_Url,"departments/"+id).subscribe(
      (res:any)=>{
        this.name=res.name;
      }
    );
}
}
