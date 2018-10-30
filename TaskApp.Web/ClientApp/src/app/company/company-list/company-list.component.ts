import { Component, OnInit } from '@angular/core';
import { CompanyService } from '../company.service';
import { Company } from '../company.model';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css']
})
export class CompanyListComponent implements OnInit {
  companies: Company[];

  constructor(private service: CompanyService) {
    this.service.all()
    .subscribe((result: Company[]) =>{
      this.companies = result;
      console.log(this.companies);
      console.log(result);
    }, error => console.log(error));
   }

  ngOnInit() {
  }

}
