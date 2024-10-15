import { Component, OnInit } from '@angular/core';
import { AddBlogPostRequest } from '../models/add-blog-post.model';
import { Observable, Subscription } from 'rxjs';
import { BlogpostService } from '../services/blog-post.service';
import { Router } from '@angular/router';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnInit {

  model: AddBlogPostRequest;
  addBlogPostSubscription: Subscription
  categories$: Observable<Category[]>;

  constructor(
    private blogpostService: BlogpostService,
    private router: Router,
    private categoryService: CategoryService
  ) {
    this.addBlogPostSubscription = new Subscription()
    this.model = {
      author: "",
      content: "",
      featuredImageUrl: "",
      isVisible: true,
      publishedDate: new Date(),
      shortDescription: "",
      title: "",
      urlHandle: "",
      categories: []
    }
    this.categories$ = new Observable<Category[]>()
  }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories()
  }

  onFormSubmit() {
    this.addBlogPostSubscription = this.blogpostService.createBlogPost(this.model).subscribe((data) => {
      this.router.navigateByUrl("/admin/blogposts")
    })
  }
  onChange(event: Event) {
    const selectedOptions = Array.from((event.target as HTMLSelectElement).selectedOptions);
    const selectedIds = selectedOptions.map(option => (option as HTMLOptionElement).value);
    console.log('Selected IDs:', selectedOptions);
    console.log('Selected IDs:', selectedIds);
  }

  ngOnDestroy(): void {
    this.addBlogPostSubscription.unsubscribe()
  }

}
