import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Message from '../assets/messages';

import { HttpRestService } from '../service/rest-service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  trainingForm: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private httpRestService: HttpRestService,
    )
  
  { }

  ngOnInit() {
    this.trainingForm = this.formBuilder.group({
      name: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
    },
      {
        validator: this.dateLessThan('startDate', 'endDate')
      }
    );
  }

  // convenience getter for easy access to form fields
  get f() { return this.trainingForm.controls; }

  dateLessThan(from: string, to: string) {
    return (group: FormGroup): { [key: string]: any } => {
      let f = group.controls[from];
      let t = group.controls[to];
      if (f.value > t.value) {
        return {
          dates: Message.StartDateEndDate
        };
      }
      return {};
    }
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.trainingForm.invalid) {
      return;
    }

    let trainingDto = { name : this.f.name.value, startDate : this.f.startDate.value, endDate : this.f.endDate.value};
    this.httpRestService.AddDataRecord('training', trainingDto).subscribe(
      res => alert('SUCCESS!! :-)\n\n There total training days is ' + res),
      err => console.log('Server Error:' + JSON.stringify(err))
    );

    this.submitted = false;
  }
}
