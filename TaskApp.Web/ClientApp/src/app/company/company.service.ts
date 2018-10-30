import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Company } from './company.model';

@Injectable()
export class CompanyService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  create(company: Company){
    return this.http.post<Company>(this.baseUrl + 'api/Companies', company);
  }

  update(company: Company){
    return this.http.put<Company>(this.baseUrl + `api/Companies/${company.companyId}`, company);
  }

  delete(id: number){
    return this.http.delete<Company>(this.baseUrl + `api/Companies/${id}`);
  }

  all(){
    return this.http.get<Company[]>(this.baseUrl + 'api/Companies');
  }

  get(id: number){
    return this.http.get<Company>(this.baseUrl + `api/Companies/${id}`);
  }
}
