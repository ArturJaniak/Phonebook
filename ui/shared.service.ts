import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
//readonly APIUrl="https://localhost:64166/api";
readonly APIUrl="https://localhost:44383/api";

  constructor(private http:HttpClient) { }
  
  getPersonList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Person');
  }

  addPerson(val:any){
    return this.http.post(this.APIUrl+'/Person',val)
  }

  updatePerson(val:any){
    return this.http.put(this.APIUrl+'/Person',val)
  }

  deletePerson(val:any){
    return this.http.delete(this.APIUrl+'/Person'+val)
  }
  //getDetailsList():Observable<any[]>{
    //return this.http.get<any>(this.APIUrl+'/persondetail');
  //}

  //getAllLanguageNames():Observable<any[]>{
   // return this.http.get<any[]>(this.APIUrl+'/languages/GetAllLanguagesNames')
  //}
  /*  getLangList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/languages');
  }

  addLanguage(val:any){
    return this.http.post(this.APIUrl+'/Languages',val)
  }
  updateLanguage(val:any){
    return this.http.put(this.APIUrl+'/Languages',val)
  }
  deleteLanguage(val:any){
    return this.http.delete(this.APIUrl+'/Languages',val)
  }
  UploadPhoto(val:any){
    return this.http.post(this.APIUrl+'/Employee/SaveFile,val)
  }

  GetAllDepartmentName():Observable<any[]>
  */
}
