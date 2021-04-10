import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  templateUrl: 'login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public loginForm!: FormGroup;
  public loading = false;
  public submitted = false;
  public error = '';

  public constructor(
    private _formBuilder: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router,
    private _authenticationService: AuthenticationService
  ) {
    // redirect to home if already logged in
    if (this._authenticationService.currentUserValue) {
      this._router.navigate(['/']);
    }
  }

  public ngOnInit() {
    this.loginForm = this._formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  // convenience getter for easy access to form fields
  public get f() {
    return this.loginForm.controls;
  }

  public onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    this._authenticationService
      .login(this.f.username.value, this.f.password.value)
      .pipe(first())
      .subscribe({
        next: (ee) => {
          console.log(ee);

          // get return url from route parameters or default to '/'
          const returnUrl =
            this._route.snapshot.queryParams['returnUrl'] || '/';
          this._router.navigate([returnUrl]);
        },
        error: (error) => {
          console.log("error:", error);
          this.error = error;
          this.loading = false;
        },
      });
  }
}
