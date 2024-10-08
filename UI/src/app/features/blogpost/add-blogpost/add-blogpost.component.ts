import { Component } from '@angular/core';
import { AddBlogPostRequest } from '../models/add-blog-post.model';
import { Subscription } from 'rxjs';
import { BlogpostService } from '../services/blog-post.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent {

  model: AddBlogPostRequest;

  addBlogPostSubscription: Subscription

  constructor(private blogpostService: BlogpostService, private router: Router) {
    this.addBlogPostSubscription = new Subscription()
    this.model = {
      author: "",
      content: "",
      featuredImageUrl: "",
      isVisible: true,
      publishedDate: new Date(),
      shortDescription: "",
      title: "",
      urlHandle: ""
    }
  }



  onFormSubmit() {
    this.addBlogPostSubscription = this.blogpostService.createBlogPost(this.model).subscribe((data) => {
      this.router.navigateByUrl("/admin/blogposts")
    })
  }


  ngOnDestroy(): void {
    this.addBlogPostSubscription.unsubscribe()
  }

}
