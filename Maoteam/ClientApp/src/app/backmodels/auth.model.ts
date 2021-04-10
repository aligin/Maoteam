export interface UserForAuthenticationViewModel {
  email: string;
  password: string;
}

export interface AuthResponseViewModel {
  isAuthSuccessful: boolean;
  errorMessage: string;
  token: string;
}
