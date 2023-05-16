import { Injectable } from '@angular/core';
import { GoogleAuthProvider, FacebookAuthProvider, TwitterAuthProvider } from 'firebase/auth';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { Router } from '@angular/router';
import firebase from 'firebase/compat';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(
    public afAuth: AngularFireAuth, // Inject Firebase auth service
    private router: Router
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
        console.log(result.user);
        return result.user!.getIdToken();
      }).then((token) => {
        // Aquí puedes obtener el token de acceso de Firebase
        console.log(token);
        // Redireccionar al usuario a la página de inicio
        this.router.navigate(['/index']);
      })
      .catch((error) => {
        console.log(error);
      });
  }

}


