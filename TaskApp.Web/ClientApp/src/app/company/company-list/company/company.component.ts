import { Component, OnInit, Input } from '@angular/core';
import { Company } from '../../company.model';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent implements OnInit {
  @Input() company: Company;
  constructor() { }

  ngOnInit() {
  }
}
