import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ActivatedRoute} from '@angular/router';
//import {PersonList} from '';
@Component({
  selector: 'app-show-per',
  templateUrl: './show-per.component.html',
  styleUrls: ['./show-per.component.css']
})
export class ShowPerComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private service: SharedService,
     ){}

 // @Input() PersonList:any;
 // PersonID:string=""


    PersonList:any=[];
    ngOnInit(): void {
    //  this.PersonList = this.route.params.subscribe(params => {
     //   this.PersonID = params['id'];
   //   })
      this.refreshPersonList();
    }
  
    refreshPersonList(){
      this.service.getPersonList().subscribe(data=>{
        this.PersonList=data;
    })
    }
    
}

