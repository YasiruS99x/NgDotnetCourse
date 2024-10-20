import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BlogPost } from '../../blogpost/models/blog-post.model';
import { BlogpostService } from '../../blogpost/services/blog-post.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  blogs$?: Observable<BlogPost[]>;
  constructor(private blogPostService: BlogpostService) {

  }
  ngOnInit(): void {
    this.blogs$ = this.blogPostService.getAllBlogPosts();
  }
}
