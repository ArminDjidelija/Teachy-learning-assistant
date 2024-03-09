import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";
import {DialogService} from "../services/dialog-service";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-virtual-mentor',
  standalone: true,
  imports: [
    FormsModule
  ],
  providers:[HttpClient],
  templateUrl: './virtual-mentor.component.html',
  styleUrl: './virtual-mentor.component.css'
})
export class VirtualMentorComponent {
  public VM_pitanje: string = '';
  public GPT_response:string = "Kako vam mogu pomoći?";
  public shrinkedChat = true;
  constructor(private dialogService: DialogService, private httpClient:HttpClient){}
  Pretraga() {
    this.GPT_response = "Učitavanje...";
    let url = 'https://localhost:7020/VirtuelniMentor';
    this.httpClient.post(url, {request:this.VM_pitanje}).subscribe((response:any)=>
    {
      this.GPT_response = response.response;
    })
    this.VM_pitanje = '';
  }

  ToogleMentor() {
    this.shrinkedChat = !this.shrinkedChat;
    if(this.shrinkedChat)
    {
      document.getElementById('search')!.style.display = 'none';
      document.getElementById('main')!.style.height = '20%';
      document.getElementById('toggleIcon')!.style.transform = 'rotate(0deg)';
      document.getElementById('response')!.style.transform = 'rotate(0deg)';
    }
    else if(!this.shrinkedChat)
    {
      document.getElementById('search')!.style.display = 'flex';
      document.getElementById('main')!.style.height = '83%';
      document.getElementById('toggleIcon')!.style.transform = 'rotate(180deg)';
    }

  }
}
