import { Injectable, Inject } from '@angular/core';
import { Employee } from './employee.model';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EmployeeService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  create(employee: Employee){
    return this.http.post<Employee>(this.baseUrl + 'api/Employees', employee);
  }

  update(employee: Employee){
    return this.http.put<Employee>(this.baseUrl + `api/Employees/${employee.employeeId}`, employee);
  }

  delete(id: number){
    return this.http.delete<Employee>(this.baseUrl + `api/Employees/${id}`);
  }

  all(){
    return this.http.get<Employee[]>(this.baseUrl + 'api/Employees');
  }

  allByCompany(id: number){
    return this.http.get<Employee[]>(this.baseUrl + `api/Employees/Company/${id}`);
  }

  get(id: number){
    return this.http.get<Employee>(this.baseUrl + `api/Employees/${id}`);
  }
}
