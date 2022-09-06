import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Boat rental';
  boats: any;

  constructor(private http: HttpClient){}

  
ngOnInit(): void {
  this.getBoats();
}

getBoats(){
this.http.get('https://localhost:7142/api/boats').subscribe((response:any)=>{
this.boats = response;
console.log(this.boats);
},(error:any)=>{
    console.error(error);
});
}



}
