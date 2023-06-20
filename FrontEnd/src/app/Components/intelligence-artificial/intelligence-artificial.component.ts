import { AfterViewInit, Component, ElementRef, Injectable, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NavBarComponent } from '../nav-bar/nav-bar.component';
import { BehaviorSubject, timer } from 'rxjs';
import { FormBuilder, FormControl } from '@angular/forms';
import { IntelligenceArtificialService } from '../../Services/intelligence-artificial.service';
import { environment } from "../../../environments/environment";

export interface intelligenceArtificial {
  id: number;
  name: string;
  image: string;
  description: string;
  url: string;
  categoriesAIId: number;
}

declare let M: any;

@Injectable()
export class DataSharingService {
    public isUserLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
}

@Component({
  selector: 'app-intelligence-artificial',
  templateUrl: './intelligence-artificial.component.html',
  styleUrls: ['./intelligence-artificial.component.css']
})

export class IntelligenceArtificialComponent implements OnInit{
  
  @ViewChild('textarea') textareaRef: ElementRef | undefined;
  @ViewChild('title') titleElement: ElementRef | undefined;
  
  IAForCategory: intelligenceArtificial[] = [];
  idCategory: number | undefined;
  NameCategory: string | undefined;
  viewIA: intelligenceArtificial | undefined;
  nameSelected: string | undefined;
  UserLogin: any;
  roleId: number | undefined;
  formForSubmit: any;
  file: any;
  IdSelected: string | undefined;
  IntelligenceArtificial: intelligenceArtificial[] = [];
  IArtificial: any;
  url: string = environment.url_BackEnd;
  inputTitle: string | undefined;
  inputDescription: string | undefined;
  inputUrl: string | undefined;

  constructor(private _route: ActivatedRoute, 
              private navBarComponent: NavBarComponent, 
              private formBuilder: FormBuilder,
              private intelligenceArtificialService: IntelligenceArtificialService){
  }

  ngOnInit(): void {

    this.intelligenceArtificialService.getAI();

    this.formForSubmit = this.formBuilder.group({
      Title: '',
      Description: '',
      Url: '',
      Image: new FormControl(null),
    });

    this.idCategory = parseInt(localStorage.getItem("IdCategory")!);
    this.NameCategory = localStorage.getItem("NameCategory")!;

    this.IntelligenceArtificial = JSON.parse(localStorage.getItem('AIList')!);

    console.log(this.IntelligenceArtificial);
    
    this.IAForCategory = this.IntelligenceArtificial.filter(x => x.categoriesAIId == this.idCategory!);

    if (localStorage.getItem("token")) {
      this.navBarComponent.refreshComponent();
    }

    if (localStorage.getItem("Login")) {
      
      this.UserLogin = localStorage.getItem('Login');

      this.UserLogin = JSON.parse(this.UserLogin);

      this.roleId! = this.UserLogin.roleId;

    }

  }

  OpenModal(position:number, name:string, Id: any){
    const elems = document.querySelectorAll('.modal');
    M.Modal.init(elems[position]);

    if (name != "") {
      this.nameSelected = name;
    }

    if (Id != "") {
      this.IdSelected = Id;
    }
  }

  getIntelligenceArtificial(name:string){
    this.viewIA = this.IntelligenceArtificial.find(x => x.name == name);

    localStorage.setItem('IntelligenceArtificial', JSON.stringify(this.viewIA));
  }

  HiddenBtn(variable1:any, variable2:any){
    let btnAdd = document.getElementById("AIAdd");
    btnAdd!.style.display = variable1;
    

    let btnSave = document.getElementById("AISave");
    btnSave!.style.display = variable2;

    this.inputTitle = "";
    this.inputUrl = "";
    this.inputDescription = "";

  }

  onFileSelected(event: any) {
    this.file = event.target.files[0];
  }

  onFormSubmit(event: any) {
    const clickedButton = event.submitter as HTMLButtonElement;

    console.log(clickedButton.name);
    
    if (clickedButton.name === 'btn-send') {
      this.AddAI();
    } else if (clickedButton.name === 'btn-update') {
      this.UpdateAI();
    }


  }


  async editAI(Id:number){
    this.intelligenceArtificialService.getAIById(Id.toString());
    
    await this.waitForCategory();

    this.IArtificial = JSON.parse(this.IArtificial);
    console.log(this.IArtificial);

    M.updateTextFields();
    this.inputTitle = this.IArtificial.name;
    this.titleElement!.nativeElement.focus();
    this.inputUrl = this.IArtificial.url;
    this.inputDescription = this.IArtificial.description;
    this.adjustTextareaSize();
    this.IdSelected = Id.toString();
  }

  adjustTextareaSize() {
    const textarea = this.textareaRef!.nativeElement;
    textarea.style.height = 'auto';
    textarea.style.height = textarea.scrollHeight + 'px';
  }

  waitForCategory(): Promise<void> {
    return new Promise<void>((resolve) => {
      const checkInterval = setInterval(() => {
        this.IArtificial = localStorage.getItem('AI');
        if (this.IArtificial !== null) {
          clearInterval(checkInterval);
          resolve();
        }
      }, 100);
    });
  }

  AddAI(){
    if(this.formForSubmit.valid) {
      this.intelligenceArtificialService.AddAI(this.formForSubmit.controls["Title"].value, this.formForSubmit.controls["Description"].value, this.file, this.formForSubmit.controls["Url"].value, this.idCategory!.toString());      
    }
  }

  UpdateAI(){
    if(this.formForSubmit.valid) {
      this.intelligenceArtificialService.UpdateAI(this.formForSubmit.controls["Title"].value, this.formForSubmit.controls["Description"].value, this.file, this.IdSelected!, this.formForSubmit.controls["Url"].value, this.idCategory!.toString()); 
    }
  }

  deleteAI(){
    this.intelligenceArtificialService.deleteAI(this.IdSelected!);
  }

}

