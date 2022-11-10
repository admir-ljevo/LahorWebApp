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

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {
  language: LanguageFlag;
  langs = languages;

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private renderer: Renderer2,
    private router: Router,
    private translationService: TranslationService
  ) {}

  ngOnInit(): void {
    this.setLanguage(this.translationService.getSelectedLanguage());
  }

  selectLanguage(lang: string) {
    this.translationService.setLanguage(lang);
    this.setLanguage(lang);
    // document.location.reload();
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

  /**
   * Sidebar toggle on hamburger button click
   */
  toggleSidebar(e: Event) {
    e.preventDefault();
    this.document.body.classList.toggle('sidebar-open');
  }

  /**
   * Logout
   */
  onLogout(e: Event) {
    e.preventDefault();
    localStorage.removeItem('isLoggedin');

    if (!localStorage.getItem('isLoggedin')) {
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
    name: 'Bosnian',
    flag: 'assets/images/flags/bs.svg',
  },
  {
    lang: 'en',
    name: 'English',
    flag: 'assets/images/flags/us.svg',
  },
  {
    lang: 'de',
    name: 'German',
    flag: 'assets/images/flags/de.svg',
  },
  {
    lang: 'es',
    name: 'Spanish',
    flag: 'assets/images/flags/es.svg',
  },
  {
    lang: 'fr',
    name: 'French',
    flag: 'assets/images/flags/fr.svg',
  },
];
