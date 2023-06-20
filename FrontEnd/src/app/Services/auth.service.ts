import { Injectable } from '@angular/core';
import { GoogleAuthProvider, FacebookAuthProvider, TwitterAuthProvider } from 'firebase/auth';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import firebase from 'firebase/compat';
import { catchError, map } from 'rxjs';
import { environment } from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  url: string = environment.url_BackEnd;
  headers = new HttpHeaders({ 'Content-Type': 'application/json-patch+json' });

  constructor(
    public afAuth: AngularFireAuth, // Inject Firebase auth service
    private router: Router,
    private _httpClient: HttpClient
  ) {}
  // Sign in with Google
  GoogleAuth() {
    return this.AuthLogin(new GoogleAuthProvider());
  }

  FacebookAuth() {
    return this.AuthLogin(new FacebookAuthProvider());
  }

  TwitterAuth() {
    return this.AuthLogin(new TwitterAuthProvider());
  }

  // Auth logic to run auth providers
  AuthLogin(provider: any) {
    return this.afAuth
      .signInWithPopup(provider)
      .then((result) => {
        console.log('You have been successfully logged in!');
        return result.user!.getIdToken();
      }).then((token) => {
        console.log(token);
        
        // Aquí puedes obtener el token de acceso de Firebase
        localStorage.setItem("token", token);
        // Redireccionar al usuario a la página de inicio
        this.router.navigate(['/index']);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  Login(email: string, password: string) {

    const headers = this.headers;

    const request = {
      "login": email,
      "password": password
    };

    return this._httpClient.post(`${this.url}/api/auth-token`, request, { headers })
      .subscribe(
        response => {

          const responseData = JSON.parse(JSON.stringify(response));

          localStorage.setItem("token", responseData.token);
          localStorage.setItem('Login', JSON.stringify(responseData.user));
          this.router.navigate(['/index']);
          
        },
        error => {
          console.error('Error:', error);
        }
      );
  }

  getUserById(Id: string){
    localStorage.removeItem("User");
    return this._httpClient.get(`${this.url}/api/User/${Id}`)
    .subscribe(
      (response: any) => {
        const responseData = JSON.stringify(response.data);
        localStorage.setItem("User", responseData);
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  UpdateUser(email: string, password: string, Id: string, name: string, lastname: string, role: number) {

    const headers = this.headers;

    const request = {
      "userDto": {
        "id": Id,
        "name": name,
        "lastname": lastname,
        "email": email,
        "login": email,
        "password": password,
        "roleId": role,
      }
    };

    console.log(request);
    
    
    return this._httpClient.put(`${this.url}/api/User`, request)
      .subscribe(
        (response: any) => {
          if (response.result) {
            this.getUserById(Id);
            if (Id == '0' && role == 0) {
              this.router.navigate(['/']);
            }else{
              window.location.reload();
            }
          }
        },
        error => {
          console.error('Error:', error);
        }
      );
  }


  AddUser(email: string, password: string, name: string, lastname: string) {

    const headers = this.headers;

    const request = {
      "userPostDto": {
        "name": name,
        "lastname": lastname,
        "email": email,
        "login": email,
        "password": password,
        "roleId": 2,
      }
    };

    return this._httpClient.post(`${this.url}/api/User`, request)
      .subscribe(
        (response: any) => {
          if (response.result) {
            this.router.navigate(['/']);
          }
        },
        error => {
          console.error('Error:', error);
        }
      );
  }

  SendEmail(email: string) {

    const headers = this.headers;

    const request = {
      "email": email
    };

    return this._httpClient.post(`${this.url}/api/User/RecoverPassword`, request)
      .subscribe(
        (response: any) => {
          const responseData = JSON.stringify(response.result);
          localStorage.setItem("SendEmail", responseData);
          if (response.result) {
            this.router.navigate(['/']);
          }
        },
        error => {
          console.error('Error:', error);
        }
      );
  }

}


