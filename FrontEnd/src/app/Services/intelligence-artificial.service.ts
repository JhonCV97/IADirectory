import { Injectable } from '@angular/core';
import { environment } from "../../environments/environment";
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class IntelligenceArtificialService {

  url: string = environment.url_BackEnd;

  constructor(private router: Router, private _httpClient: HttpClient) { }

  AddAI(title: string, description: string, image: File, url: string, categoryId: string) {

    const formData = new FormData();

    formData.append('Image', image);
    formData.append('ArtificialIntelligencePostDto.Name', title);
    formData.append('ArtificialIntelligencePostDto.Url', url);
    formData.append('ArtificialIntelligencePostDto.Description', description);
    formData.append('ArtificialIntelligencePostDto.IsNew', 'true');
    formData.append('ArtificialIntelligencePostDto.CategoriesAIId', categoryId);
    

    return this._httpClient.post(`${this.url}/api/ArtificialIntelligence`, formData)
      .subscribe(
        (response: any) => {
          if (response.result) {
            this.getAI();
            window.location.reload();
          }
        },
        error => {
          console.error('Error:', error);
        }
      );
  }

  getAI(){
    return this._httpClient.get(`${this.url}/api/ArtificialIntelligence`)
    .subscribe(
      (response: any) => {
        const responseData = JSON.stringify(response.data);
        localStorage.setItem("AIList", responseData);
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  deleteAI(Id: string){
    return this._httpClient.delete(`${this.url}/api/ArtificialIntelligence/${Id}`)
    .subscribe(
      (response: any) => {
        if (response.result) {
          this.getAI();
          window.location.reload();
        }
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  getAIById(Id: string){
    localStorage.removeItem("AI");
    return this._httpClient.get(`${this.url}/api/ArtificialIntelligence/${Id}`)
    .subscribe(
      (response: any) => {
        const responseData = JSON.stringify(response.data);
        localStorage.setItem("AI", responseData);
      },
      error => {
        console.error('Error:', error);
      }
    );
  }

  UpdateAI(title: string, description: string, image: File, Id: string, url: string, categoryId: string) {

    const formData = new FormData();

    formData.append('Image', image);
    formData.append('ArtificialIntelligencePostDto.Id', Id);
    formData.append('ArtificialIntelligencePostDto.Name', title);
    formData.append('ArtificialIntelligencePostDto.Url', url);
    formData.append('ArtificialIntelligencePostDto.Description', description);
    formData.append('ArtificialIntelligencePostDto.IsNew', 'true');
    formData.append('ArtificialIntelligencePostDto.CategoriesAIId', categoryId);

    return this._httpClient.put(`${this.url}/api/ArtificialIntelligence`, formData)
      .subscribe(
        (response: any) => {
          console.log(response);
          
          if (response.result) {
            this.getAI();
            window.location.reload();
          }
        },
        error => {
          console.error('Error:', error);
        }
      );
  }
}
