import { Component, OnInit,AfterViewInit,ViewChild, OnDestroy } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ClientAddEditComponent } from './client-add-edit/client-add-edit.component';
import { ClientService } from './services/client.service';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {MatSort, MatSortModule} from '@angular/material/sort';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit,OnDestroy {
  title = "/ClientsUI";
  private sub!: Subscription;

  displayedColumns: string[] = [
    'id', 
    'firstName', 
    'lastName', 
    'phones.homePhone',
    'phones.workPhone',
    'phones.mobilePhone', 
    'address',
    'email',
    'action'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _dialog: MatDialog, private _clientService: ClientService) {

  }

  ngOnInit(): void {
      this.getClientList();
  }

  openAddClientForm() {
    const dialogRef = this._dialog.open(ClientAddEditComponent);
    this.sub = dialogRef.afterClosed().subscribe({
      next: (val) => {
        if(val) {
          this.getClientList();
        }
      }
    });

  }

  getClientList() {
    this.sub = this._clientService.getClientList().
    subscribe({
      next: (res) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deleteClient(id: string) {
    this.sub = this._clientService.deleteClient(id).subscribe({
      next: (res) => {
        this.getClientList();
      },
      error: (err) =>{ 
        console.log(err)
      }
      
    });
  }

  openEditClientForm(data:any) {
    const dialogRef= this._dialog.open(ClientAddEditComponent,{data});
    this.sub = dialogRef.afterClosed().subscribe({
      next: (val) => {
        if(val) {
          this.getClientList();
        }
      }
    });
  }

  ngOnDestroy(): void {
      this.sub.unsubscribe();
  }


}
