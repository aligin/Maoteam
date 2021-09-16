import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  templateUrl: 'user-profile.component.html',
  styleUrls: ['./user-profile.component.scss'],
})
export class UserProfileComponent implements OnInit {
  public managerUserInfoForm: FormGroup;
  public userPasswordForm: FormGroup;

  public user: any;

  constructor(
    private _formBuilder: FormBuilder,
    private _userService: UserService
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


  public async ngOnInit() {
    this.user = await this._userService.getProfile().toPromise();
  }
}
