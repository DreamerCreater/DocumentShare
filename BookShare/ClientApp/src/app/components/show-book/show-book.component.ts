import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-show-book',
  templateUrl: './show-book.component.html',
  styleUrls: ['./show-book.component.css']
})
export class ShowBookComponent implements OnInit {
book: Book; 
  constructor(private service: BookService,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.service.getBookById(this.route.snapshot.params.id).subscribe(
      data=>{
        this.book=data;
      }
    )
  }

}
