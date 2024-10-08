import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AddCategoryRequest } from '../../category/models/add-category-request.model';
import { AddBlogPostRequest } from '../models/add-blog-post.model';
import { BlogPost } from '../models/blog-post.model';

@Injectable({
  providedIn: 'root'
})
export class BlogpostService {

  constructor(private http: HttpClient) { }

  createBlogPost(model: AddBlogPostRequest): Observable<BlogPost> {
    return this.http.post<BlogPost>(`${environment.apiBaseUrl}/api/blogposts`, model)
  }

  getAllBlogPosts(): Observable<BlogPost[]> {
    return this.http.get<BlogPost[]>(`${environment.apiBaseUrl}/api/blogposts`)
  }

}
