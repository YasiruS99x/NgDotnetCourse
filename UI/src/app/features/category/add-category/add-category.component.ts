import { Component, OnDestroy } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy {

  model: AddCategoryRequest
  addCategorySubscription: Subscription

  constructor(private categoryService: CategoryService, private router: Router) {
    this.addCategorySubscription = new Subscription()
    this.model = {
      name: "",
      urlHandle: ""
    }
  }


  onFormSubmit() {
    this.addCategorySubscription = this.categoryService.createCategory(this.model).subscribe((data) => {
      this.router.navigateByUrl("/admin/categories")
    })
  }


  ngOnDestroy(): void {
    this.addCategorySubscription.unsubscribe()
  }


}
