import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  templateUrl: 'user-profile.component.html',
  styleUrls: ['./user-profile.component.scss'],
})
export class UserProfileComponent implements OnInit {
  public managerUserInfoForm: FormGroup;
  public userPasswordForm: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
  ) {
    this.managerUserInfoForm = this._formBuilder.group({
      name: ["", Validators.required],
      surname: ["", Validators.required],
      fullName: ["", Validators.required],
      email: ["", Validators.required],
      phone: ["", Validators.required],
    });

    this.userPasswordForm = this._formBuilder.group({
      oldPassword: ["", Validators.required],
      newPassword: ["", Validators.required],
    });
  }


  public ngOnInit() {}
}
