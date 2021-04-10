export interface UserForAuthenticationViewModel {
  username: string;
  password: string;
}

export interface AuthResponseViewModel {
  isAuthSuccessful: boolean;
  errorMessage: string;
  token: string;
}
