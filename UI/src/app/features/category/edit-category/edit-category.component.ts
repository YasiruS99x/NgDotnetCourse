import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { EditCategoryRequest } from '../models/edit-category-request.model';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit, OnDestroy {

  id: string | null = null
  routerSubscription: Subscription | null = null
  editSubscription: Subscription | null = null
  category: Category | null = null

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get("id")
      if (this.id) {
        this.categoryService.getCategoryById(this.id).subscribe({
          next: (value) => {
            this.category = value
          },
          error: (err) => {
            console.log(err)
          },
        })
      }
    })
  }

  onFormSubmit() {
    const editCategoryRequest: EditCategoryRequest = {
      name: this.category?.name ?? "",
      urlHandle: this.category?.urlHandle ?? ""
    }

    if (this.id) {
      this.editSubscription = this.categoryService.editCategory(this.id, editCategoryRequest).subscribe((data) => {
        this.router.navigateByUrl("/admin/categories")
      })
    }
  }

  onDelete(){
    if (this.id) {
      this.editSubscription = this.categoryService.deleteCategory(this.id).subscribe((data) => {
        this.router.navigateByUrl("/admin/categories")
      })
    }
  }

  ngOnDestroy(): void {

    if (this.routerSubscription) this.routerSubscription.unsubscribe()
    if (this.editSubscription) this.editSubscription.unsubscribe()
  }



}
