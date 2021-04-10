import { Component } from '@angular/core';
import { first } from 'rxjs/operators';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    public loading = false;
    public users: User[] = [];

    constructor(private userService: UserService) { }

    ngOnInit() {
        this.loading = true;
        this.userService.getAll().pipe(first()).subscribe(users => {
            this.loading = false;
            this.users = users;
        });
    }
}
