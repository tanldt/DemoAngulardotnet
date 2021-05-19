import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from './employee';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  public employees: Employee[];//
  constructor(
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string //
  ) { }

  ngOnInit() {
    this.http.get<Employee[]>(this.baseUrl + 'api/Employees')
      .subscribe(result => {
        this.employees = result;
      }, error => console.error(error));
  }

}
