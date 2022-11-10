import { Component, OnInit } from '@angular/core';
import { NewModel } from '../../../models/new-model';
import { NewsService } from '../../../services/NewsService';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { TranslationService } from 'src/app/shared/i18n';
@Component({
  selector: 'app-services-add',
  templateUrl: './news-add.component.html',
  styleUrls: ['./news-add.component.scss'],
})
export class NewsAddComponent implements OnInit {
  new: NewModel = new NewModel();
  message: string;
  user: any;
  imgSrc: any = '../../../assets/images/others/default_new.webp';
  form = new FormGroup({
    name: new FormControl('', Validators.required),
    text: new FormControl('', Validators.required),
    file: new FormControl(null),
    public: new FormControl(false),
    userId: new FormControl(1),
    image: new FormControl(null),
    user: new FormControl('Amir Karaga'),
  });

  constructor(
    private newsService: NewsService,
    private router: Router,
    private toastr: ToastrService,
    private t: TranslationService
  ) {}

  ngOnInit(): void {
    this.user = 'Amir Karaga';
    // localStorage.getItem('user-firstName') +
    // ' ' +
    // localStorage.getItem('user-lastName');
  }

  addNew() {
    if (!this.form.invalid) {
      this.form.controls['userId'].setValue(1);
      const formData: FormData = new FormData();
      formData.append('name', this.form.controls['name'].value);
      formData.append('text', this.form.controls['text'].value);
      formData.append('userId', this.form.controls['userId'].value);
      formData.append('file', this.form.controls['file'].value);
      formData.append('public', this.form.controls['public'].value);
      formData.append('image', '');
      this.newsService.addNew(formData).subscribe(
        (data: any) => {
          this.message = this.t.get('NEW.CREATE.ADD_SUCCESS');
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
          this.router.navigateByUrl('/news');
        },
        (error) => {
          this.message = this.t.get('NEW.CREATE.ADD_ERROR');
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      );
    }
  }

  get name() {
    return this.form.get('name');
  }

  get text() {
    return this.form.get('text');
  }

  onFileSelected(event: any) {
    const file = <File>event.target.files[0];
    const reader = new FileReader();
    reader.onload = (e) => (this.imgSrc = reader.result);
    reader.readAsDataURL(file);
    this.form?.controls['file'].setValue(file);
  }

  onChanged($event: any) {
    this.new.public = $event && $event.target && $event.target.checked;
  }
}
