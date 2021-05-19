import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

import { Employee } from './Employee';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent {
  // the view title
  title: string;
  // the form model
  form: FormGroup;
  // the city object to edit
  employee: Employee;

  // the object id, as fetched from the active route:
  // It's NULL when we're adding a new employee,
  // and not NULL when we're editing an existing one.
  id?: number;
  
  constructor(
    private fb: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
    this.loadData();
  }
  ngOnInit() {
    this.form = this.fb.group({
      name: ['',
        Validators.required,
        this.isDupeField("name")
      ],
      address: ['',
        [
          Validators.required
        ]
      ]
      
    });

  }
  loadData() {
    // retrieve the ID from the 'id'
    this.id = +this.activatedRoute.snapshot.paramMap.get('id');
    if (this.id) {
      // EDIT MODE

      // fetch the country from the server
      var url = this.baseUrl + "api/employees/" + this.id;
      this.http.get<Employee>(url).subscribe(result => {
        this.employee = result;
        this.title = "Edit - " + this.employee.name;

        // update the form with the employee value
        this.form.patchValue(this.employee);
      }, error => console.error(error));
    }
    else {
      // ADD NEW MODE

      this.title = "Create a new Employee";
    }
  }
  onSubmit() {
    var employee = (this.id) ? this.employee : <Employee>{};

    employee.name = this.form.get("name").value;
    employee.address = this.form.get("address").value;
    

    if (this.id) {
      // EDIT mode

      var url = this.baseUrl + "api/employees/" + this.employee.id;
      this.http
        .put<Employee>(url, employee)
        .subscribe(result => {

          console.log("Employee " + employee.id + " has been updated.");

          // go back to cities view
          this.router.navigate(['/employees']);
        }, error => console.error(error));
    }
    else {
      // ADD NEW mode
      var url = this.baseUrl + "api/employees";
      this.http
        .post<Employee>(url, employee)
        .subscribe(result => {

          console.log("Employee " + result.id + " has been created.");

          // go back to cities view
          this.router.navigate(['/employees']);
        }, error => console.error(error));
    }
  }

  isDupeField(fieldName: string): AsyncValidatorFn {
    return (control: AbstractControl): Observable<{ [key: string]: any } | null> => {

      var params = new HttpParams()
        .set("employeeId", (this.id) ? this.id.toString() : "0")
        .set("fieldName", fieldName)
        .set("fieldValue", control.value);
      var url = this.baseUrl + "api/employees/IsDupeField";
      return this.http.post<boolean>(url, null, { params })
        .pipe(map(result => {
          return (result ? { isDupeField: true } : null);
        }));
    }
  }

}
