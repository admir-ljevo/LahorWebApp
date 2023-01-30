import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  Inject,
  Renderer2,
} from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Router } from '@angular/router';
import { TranslationService } from 'src/app/shared/i18n';
import { AuthentificationHelper } from 'src/app/helpers/authentification-helper';
import { MyConfig } from 'src/app/shared/MyConfig';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { SignalRService } from 'src/app/services/signalRService';
import { NotificationsService } from 'src/app/services/NotificationsService';
import { AuthEmployeeGuard } from 'src/app/core/guard/authEmployee.guard';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';
import { AuthAdminGuard } from 'src/app/core/guard/authAdmin.guard';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  language: LanguageFlag;
  langs = languages;
  userName: any;
  email: any;
  profilePhoto: any;
  notifications: any;
  sidebarComponent: SidebarComponent = new SidebarComponent(
    this.document,
    this.renderer,
    this.router,
    this.translationService
  );
  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2,
    private router: Router,
    private translationService: TranslationService,
    public signalRService: SignalRService,
    private notificationsService: NotificationsService
  ) {}

  ngOnInit(): void {
    this.signalRService.startConnection();
    this.signalRService.notifications();
    this.getUnreadNotifications();
    this.setLanguage(this.translationService.getSelectedLanguage());
    this.userName =
      localStorage.getItem('user-firstName') +
      ' ' +
      localStorage.getItem('user-lastName');
    this.email = localStorage.getItem('user-email');
    this.profilePhoto =
      MyConfig.address_server_base + localStorage.getItem('user-profilePhoto');
  }

  getUnreadNotifications() {
    this.notificationsService
      .getUnreadNotifications()
      .subscribe((data: any) => {
        this.signalRService.unreadNotifications = data;
        if (data.length === 0) {
          this.signalRService.hasUnreadNotifications = false;
        } else {
          this.signalRService.hasUnreadNotifications = true;
        }
      });
  }

  markAllNotificationAsRead() {
    this.notificationsService.MarkAllAsRead().subscribe((data: any) => {
      this.getUnreadNotifications();
    });
  }

  selectLanguage(lang: string) {
    this.translationService.setLanguage(lang);
    this.setLanguage(lang);
    this.sidebarComponent.setLabelMenuItems();
  }

  setLanguage(lang: string) {
    this.langs.forEach((language: LanguageFlag) => {
      if (language.lang === lang) {
        language.active = true;
        this.language = language;
      } else {
        language.active = false;
      }
    });
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

  toggleSidebar(e: Event) {
    e.preventDefault();
    this.document.body.classList.toggle('sidebar-open');
  }

  onLogout(e: Event) {
    e.preventDefault();
    localStorage.removeItem('auth-token');
    localStorage.clear();

    if (!localStorage.getItem('auth-token')) {
      this.router.navigate(['/auth/login']);
    }
  }
}

interface LanguageFlag {
  lang: string;
  name: string;
  flag: string;
  active?: boolean;
}

const languages = [
  {
    lang: 'bs',
    name: 'LANGUAGE.BOSNIAN',
    flag: 'assets/images/flags/bs.svg',
  },
  {
    lang: 'en',
    name: 'LANGUAGE.ENGLISH',
    flag: 'assets/images/flags/us.svg',
  },
  {
    lang: 'de',
    name: 'LANGUAGE.GERMAN',
    flag: 'assets/images/flags/de.svg',
  },
  {
    lang: 'es',
    name: 'LANGUAGE.SPANISH',
    flag: 'assets/images/flags/es.svg',
  },
  {
    lang: 'fr',
    name: 'LANGUAGE.FRANCE',
    flag: 'assets/images/flags/fr.svg',
  },
];
