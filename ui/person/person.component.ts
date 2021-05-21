import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent {
  constructor(private service: SharedService) { }
  PersonList:any=[];
  
  ngOnInit(): void {
    this.refreshPersonList();
  }
  
  refreshPersonList(){
    this.service.getPersonList().subscribe(data=>{
      this.PersonList=data;
    })
  }

}
