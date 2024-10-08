import { Component } from '@angular/core';
import { BlogPost } from '../models/blog-post.model';
import { BlogpostService } from '../services/blog-post.service';

@Component({
  selector: 'app-blogpost-list',
  templateUrl: './blogpost-list.component.html',
  styleUrls: ['./blogpost-list.component.css']
})
export class BlogpostListComponent {
  blogPosts: BlogPost[]
  constructor(private blogpostService: BlogpostService) {
    this.blogPosts = []
  }

  ngOnInit(): void {
    this.blogpostService.getAllBlogPosts().subscribe((data: BlogPost[]) => {
      this.blogPosts = data
    })
  }

}
