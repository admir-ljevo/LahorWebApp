import { Component, OnInit } from '@angular/core';
import { NewsService } from '../../../services/NewsService';
import { ActivatedRoute, Router } from '@angular/router';
import { MyConfig } from '../../../shared/MyConfig';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { TranslationService } from 'src/app/shared/i18n';
import { IndividualConfig, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-services-edit',
  templateUrl: './news-edit.component.html',
  styleUrls: ['./news-edit.component.scss'],
})
export class NewsEditComponent implements OnInit {
  private id: Number;
  sub: any;
  new: any;
  imgUrl: any;
  form: FormGroup;
  message: any;

  constructor(
    private newsService: NewsService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private t: TranslationService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.sub = this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.getNew();
    });
  }

  loadData(data: any) {
    this.form = new FormGroup({
      id: new FormControl(data.id),
      createdAt: new FormControl(data.createdAt),
      name: new FormControl(data.name, Validators.required),
      public: new FormControl(data.public),
      text: new FormControl(data.text, Validators.required),
      file: new FormControl(null),
      userId: new FormControl(1),
      image: new FormControl(data.image),
      user: new FormControl(
        data.user.person.firstName + ' ' + data.user.person.lastName
      ),
    });
  }

  onChanged($event: any) {
    this.new.public = $event && $event.target && $event.target.checked;
  }

  getNew() {
    this.new = this.newsService.getById(this.id).subscribe((data: any) => {
      this.new = data;
      this.loadData(this.new);
      this.createImageUrl(this.new.image);
    });
  }

  updateNew() {
    const formData: FormData = new FormData();
    formData.append('id', this.form.controls['id'].value);
    formData.append('createdAt', this.form.controls['createdAt'].value);
    formData.append('name', this.form.controls['name'].value);
    formData.append('text', this.form.controls['text'].value);
    formData.append('userId', this.form.controls['userId'].value);
    formData.append('file', this.form.controls['file'].value);
    formData.append('public', this.form.controls['public'].value);
    formData.append('image', this.form.controls['image'].value);
    this.newsService.editNew(formData).subscribe(
      (data) => {
        this.message = this.t.get('NEW.EDIT.EDIT_SUCCESS');
        this.toastr.success('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
        this.router.navigateByUrl('/news');
      },
      (error) => {
        this.message = this.t.get('NEW.EDIT.EDIT_ERROR');
        this.toastr.error('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      }
    );
  }

  public createImageUrl = (serverPath: string) => {
    this.imgUrl = MyConfig.address_server + serverPath;
  };

  onFileSelected(event: any) {
    const file = <File>event.target.files[0];
    const reader = new FileReader();
    reader.onload = (e) => (this.imgUrl = reader.result);
    reader.readAsDataURL(file);
    this.form?.controls['file'].setValue(file);
  }

  get name() {
    return this.form.get('name');
  }

  get text() {
    return this.form.get('text');
  }
}
