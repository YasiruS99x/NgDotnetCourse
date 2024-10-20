import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { BlogPost } from '../../blogpost/models/blog-post.model';
import { BlogpostService } from '../../blogpost/services/blog-post.service';

@Component({
  selector: 'app-blog-details',
  templateUrl: './blog-details.component.html',
  styleUrls: ['./blog-details.component.css']
})
export class BlogDetailsComponent implements OnInit {
  url: string | null = null;
  blogPost$? : Observable<BlogPost>;

  constructor(private route: ActivatedRoute,
    private blogPostService: BlogpostService) {

  }
  ngOnInit(): void {
    this.route.paramMap
    .subscribe({
      next: (params) => {
        this.url = params.get('url');
      }
    });

    // Fetch blog details by url
    if (this.url) {
      this.blogPost$ = this.blogPostService.getBlogPostByUrlHandle(this.url);
    }
  }
}
