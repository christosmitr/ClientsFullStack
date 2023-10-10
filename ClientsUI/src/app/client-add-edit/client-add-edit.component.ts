import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ClientService } from '../services/client.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription } from 'rxjs';




@Component({
  selector: 'app-client-add-edit',
  templateUrl: './client-add-edit.component.html',
  styleUrls: ['./client-add-edit.component.scss']
})
export class ClientAddEditComponent implements OnInit,OnDestroy{
  
 clientForm: FormGroup;
 private sub!: Subscription;

  constructor(
    private _fb:FormBuilder ,
    private _clientService:ClientService,
    private _dialogRef: MatDialogRef<ClientAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any
  ) {
    
    this.clientForm = this._fb.group({
      firstName: '',
      lastName: '',
      phones :this._fb.group({
        homePhone: '',
        workPhone: '',
        mobilePhone: '',
      }),
      address: '',
      email: ''
    });


  }

  ngOnInit(): void {
      this.clientForm.patchValue(this.data);
  }

  onFormSubmit() {
    if(this.clientForm.valid) {
      if(this.data){
        this.sub = this._clientService.updateClient(this.data.id,this.clientForm.value)
        .subscribe({
          next: (val:any) => {
            this._dialogRef.close(true);
            
          },
          error: (err:any) => {
            console.log(err);
          }
        });
      } 
      else
      {
        this.sub =this._clientService.addClient(this.clientForm.value)
        .subscribe({
          next: (val:any) =>{
            this._dialogRef.close(true);
            
          },
          error: (err:any) => {
            console.log(err);
          }
        });
      }
    }
  }

  onCancel() {
    this._dialogRef.close(false);
  }

  ngOnDestroy(): void {
      this.sub.unsubscribe();
  }

}
