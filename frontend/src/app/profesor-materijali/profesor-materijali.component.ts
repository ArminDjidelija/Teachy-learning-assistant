import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {PredmetiGetAll, PredmetiGetAllResponse} from "./get-all-predmeti";
import {MojConfig} from "../moj-config";
import {NgForOf, NgIf} from "@angular/common";
import {FormsModule} from "@angular/forms";
import {Oblast, OblastResp, OblastResponse} from "./get-oblasti-by-predmet";
import {DialogService} from "../services/dialog-service";

@Component({
  selector: 'app-profesor-materijali',
  standalone: true,
  imports: [
    NgForOf,
    FormsModule,
    NgIf
  ],
  templateUrl: './profesor-materijali.component.html',
  styleUrl: './profesor-materijali.component.css'
})
export class ProfesorMaterijaliComponent implements OnInit {


  constructor(private httpClient: HttpClient, private dialogService:DialogService) {
  }

  predmeti: PredmetiGetAllResponse[] = [];
  odabraniPredmet: number = 1;

  ngOnInit(): void {
    this.dohvatiPredmete();
    this.ucitajOblast(this.odabraniPredmet);
  }

  dohvatiPredmete() {
    let url = MojConfig.adresa_servera + `/Predmeti`;
    this.httpClient.get<PredmetiGetAll>(url).subscribe(x => {
      this.predmeti = x;
    })
  }

  oblasti: OblastResponse[] = [];

  ucitajOblast(id: number) {
    let url = MojConfig.adresa_servera + `/Oblast?PredmetId=${id}`;
    this.httpClient.get<OblastResponse[]>(url).subscribe(x => {
      this.oblasti = x;
      console.log(this.oblasti);
    })
  }
  odabranaOblast!:number;
  sendData(id: number) {
    this.odabranaOblast=id;
    this.sendFile(this.selectedFiles)

  }

  public selectedFiles: File[] = [];
  public fileUrl: string = "";

  handleFileInput(event: Event) {
    let files = (event.target as HTMLInputElement).files;
    if (files) {
      this.fileUrl = window.URL.createObjectURL(files[0]);

      for (let index = 0; index < files.length; index++) {
        if (files.item(index)) {
          this.addFileToQueue(files.item(index) as File);
        }
      }
    }
  }

  private addFileToQueue(file: File) {
    this.selectedFiles.push(file);
  }

  file: any = null;

  postFile(fileToUpload:File, id:string){
    const formData=new FormData();
    formData.append('File', fileToUpload);
    formData.append('Id', id);

    const headers=new HttpHeaders().append('Content-Disposition', 'multipart/form-data'); //Disposition
    let url=MojConfig.adresa_servera+`/MaterijalOblast`;

    this.httpClient.post(url, formData, {headers}).subscribe(x=>{
      this.dohvatiPredmete();
      this.dialogService.openOkDialog("Uspješno dodan materijal!").afterClosed().subscribe(x=>{
        this.ucitajOblast(this.odabranaOblast);
      });
    })
  }

  sendFile(files: File[]) {
    if (files) {
      for (let index = 0; index < files.length; index++) {
        if (files[index]) {
          this.postFile(files[index],this.odabranaOblast.toString());
          }
        }
      }
    this.selectedFiles = [];

    }


}
