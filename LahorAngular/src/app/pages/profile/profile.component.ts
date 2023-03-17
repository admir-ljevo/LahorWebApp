import { Component, OnInit } from '@angular/core';
import { IndividualConfig, ToastrService } from 'ngx-toastr';
import { AuthAdminGuard } from 'src/app/core/guard/authAdmin.guard';
import { AuthClientGuard } from 'src/app/core/guard/authClient.guard';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';
import { AuthEmployeeGuard } from 'src/app/core/guard/authEmployee.guard';
import { AppUsersService } from 'src/app/services/AppUsersService';
import { TranslationService } from 'src/app/shared/i18n';
import { MyConfig } from 'src/app/shared/MyConfig';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  imgUrl: any;
  user: any;
  file: any;
  message: any;
  constructor(
    private appUsersService: AppUsersService,
    private t: TranslationService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getUserProfile();
  }

  getUserProfile() {
    return this.appUsersService.getUserProfile().subscribe((data: any) => {
      this.user = data;
      console.log(data);
      this.createImageUrl(this.user.person.profilePhoto);
    });
  }

  public createImageUrl = (imgSrc: string) => {
    this.imgUrl = MyConfig.address_server_base + imgSrc;
  };

  onFileSelected(event: any) {
    const file = <File>event.target.files[0];
    const reader = new FileReader();
    reader.onload = (e) => (this.imgUrl = reader.result);
    reader.readAsDataURL(file);
    this.file = file;
  }

  changePhoto() {
    let formData = new FormData();
    formData.append('file', this.file);
    this.appUsersService.changePhoto(formData).subscribe(
      (data) => {
        this.message = this.t.get(data?.toString());
        this.toastr.success('', this.message, {
          timeOut: 2500,
          progressBar: true,
          closeButton: true,
        } as IndividualConfig);
      },
      (error) => {
        this.message = this.t.get(error.error.text);
        if (error.status === 200) {
          this.toastr.success('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        } else {
          this.toastr.error('', this.message, {
            timeOut: 2500,
            progressBar: true,
            closeButton: true,
          } as IndividualConfig);
        }
      }
    );
  }

  get isAdmin() {
    return AuthAdminGuard.isActive();
  }

  get isCompanyOwner() {
    return AuthCompanyOwnerGuard.isActive();
  }

  get isEmployee() {
    return AuthEmployeeGuard.isActive();
  }
  get isClient() {
    return AuthClientGuard.isActive();
  }
}
