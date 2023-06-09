import { AuthGuard } from 'src/app/core/guard/auth.guard';
import { AuthAdminGuard } from 'src/app/core/guard/authAdmin.guard';
import { AuthClientGuard } from 'src/app/core/guard/authClient.guard';
import { AuthCompanyOwnerGuard } from 'src/app/core/guard/authCompanyOwner.guard';
import { AuthEmployeeGuard } from 'src/app/core/guard/authEmployee.guard';
import { MenuItem } from './menu.model';

export const MENU: MenuItem[] = [
  {
    label: 'Main',
    isTitle: true
  },
  {
    label: 'Dashboard',
    icon: 'home',
    link: '/dashboard'
  },
  {
    label: 'News',
    icon: 'home',
    link:'/news'
  },
  {
    label: 'Services',
    icon: 'home',
    link:'/services'
  },
  {
    label: 'Price List',
    icon: 'home',
    link:'/price-list-preview'
  },
  {
    label: 'Orders',
    icon: 'file-text',
    link:'/orders'
  },
  {
    label: 'Devices',
    icon: 'smartphone',
    link: '/device',
  },
  {
    label: 'Purchase requests',
    icon: 'shopping-cart',
    link: '/purchase-requests'
  },
  {
    label: 'Materials',
    icon: 'folder-minus',
    link: 'materials'
  },
  {
    label: 'Web Apps',
    isTitle: true
  },
  {
    label: 'Email',
    icon: 'mail',
    subItems: [
      {
        label: 'Inbox',
        link: '/apps/email/inbox',
      },
      {
        label: 'Read',
        link: '/apps/email/read'
      },
      {
        label: 'Compose',
        link: '/apps/email/compose'
      },
    ]
  },
  {
    label: 'Chat',
    icon: 'message-square',
    link: '/apps/chat',
  },
  {
    label: 'Calendar',
    icon: 'calendar',
    link: '/apps/calendar',
    badge: {
      variant: 'primary',
      text: 'Event',
    }
  },
  {
    label: 'Components',
    isTitle: true
  },
  {
    label: 'UI Kit',
    icon: 'feather',
    subItems: [
      {
        label: 'Accordion',
        link: '/ui-components/accordion',
      },
      {
        label: 'Alerts',
        link: '/ui-components/alerts',
      },
      {
        label: 'Badges',
        link: '/ui-components/badges',
      },
      {
        label: 'Breadcrumbs',
        link: '/ui-components/breadcrumbs',
      },
      {
        label: 'Buttons',
        link: '/ui-components/buttons',
      },
      {
        label: 'Button group',
        link: '/ui-components/button-group',
      },
      {
        label: 'Cards',
        link: '/ui-components/cards',
      },
      {
        label: 'Carousel',
        link: '/ui-components/carousel',
      },
      {
        label: 'Collapse',
        link: '/ui-components/collapse',
      },
      {
        label: 'Datepicker',
        link: '/ui-components/datepicker',
      },
      {
        label: 'Dropdowns',
        link: '/ui-components/dropdowns',
      },
      {
        label: 'List group',
        link: '/ui-components/list-group',
      },
      {
        label: 'Media object',
        link: '/ui-components/media-object',
      },
      {
        label: 'Modal',
        link: '/ui-components/modal',
      },
      {
        label: 'Navs',
        link: '/ui-components/navs',
      },
      {
        label: 'Navbar',
        link: '/ui-components/navbar',
      },
      {
        label: 'Pagination',
        link: '/ui-components/pagination',
      },
      {
        label: 'Popovers',
        link: '/ui-components/popovers',
      },
      {
        label: 'Progress',
        link: '/ui-components/progress',
      },
      {
        label: 'Rating',
        link: '/ui-components/rating',
      },
      {
        label: 'Scrollbar',
        link: '/ui-components/scrollbar',
      },
      {
        label: 'Spinners',
        link: '/ui-components/spinners',
      },
      {
        label: 'Timepicker',
        link: '/ui-components/timepicker',
      },
      {
        label: 'Tooltips',
        link: '/ui-components/tooltips',
      },
      {
        label: 'Typeadhed',
        link: '/ui-components/typeahead',
      },
    ]
  },
  {
    label: 'Advanced UI',
    icon: 'anchor',
    subItems: [
      {
        label: 'Cropper',
        link: '/advanced-ui/cropper',
      },
      {
        label: 'Owl carousel',
        link: '/advanced-ui/owl-carousel',
      },
      {
        label: 'Sweet alert',
        link: '/advanced-ui/sweet-alert',
      },
    ]
  },
  {
    label: 'Forms',
    icon: 'file-text',
    subItems: [
      {
        label: 'Basic elements',
        link: '/form-elements/basic-elements'
      },
      {
        label: 'Advanced elements',
        subItems: [
          {
            label: 'Form validation',
            link: '/advanced-form-elements/form-validation'
          },
          {
            label: 'Input mask',
            link: '/advanced-form-elements/input-mask'
          },
          {
            label: 'Ng-select',
            link: '/advanced-form-elements/ng-select'
          },
          {
            label: 'Ngx-chips',
            link: '/advanced-form-elements/ngx-chips'
          },
          {
            label: 'Ngx-color-picker',
            link: '/advanced-form-elements/ngx-color-picker'
          },
          {
            label: 'Ngx-dropzone',
            link: '/advanced-form-elements/ngx-dropzone-wrapper'
          },
        ]
      },
      {
        label: 'Editors',
        link: '/form-elements/editors'
      },
      {
        label: 'Wizard',
        link: '/form-elements/wizard'
      },
    ]
  },
  {
    label: 'Charts & graphs',
    icon: 'pie-chart',
    subItems: [
      {
        label: 'ApexCharts',
        link: '/charts-graphs/apexcharts',
      },
      {
        label: 'ChartJs',
        link: '/charts-graphs/chartjs',
      },
    ]
  },
  {
    label: 'Tables',
    icon: 'layout',
    subItems: [
      {
        label: 'Basic tables',
        link: '/tables/basic-table',
      },
      {
        label: 'Data table',
        link: '/tables/data-table',
      },
      {
        label: 'Ngx-datatable',
        link: '/tables/ngx-datatable'
      }
    ]
  },
  {
    label: 'Icons',
    icon: 'smile',
    subItems: [
      {
        label: 'Feather icons',
        link: '/icons/feather-icons',
      },
      {
        label: 'Mdi icons',
        link: '/icons/mdi-icons',
      }
    ]
  },
  {
    label: 'Pages',
    isTitle: true
  },
  {
    label: 'Special pages',
    icon: 'book',
    subItems: [
      {
        label: 'Blank page',
        link: '/general/blank-page',
      },
      {
        label: 'Faq',
        link: '/general/faq',
      },
      {
        label: 'Invoice',
        link: '/general/invoice',
      },
      {
        label: 'Profile',
        link: '/general/profile',
      },
      {
        label: 'Pricing',
        link: '/general/pricing',
      },
      {
        label: 'Timeline',
        link: '/general/timeline',
      }
    ]
  },
  {
    label: 'Authentication',
    icon: 'unlock',
    subItems: [
      {
        label: 'Login',
        link: '/auth/login',
      },
      {
        label: 'Register',
        link: '/auth/register',
      },
    ]
  },
  {
    label: 'Error',
    icon: 'cloud-off',
    subItems: [
      {
        label: '404',
        link: '/error/404',
      },
      {
        label: '500',
        link: '/error/500',
      },
    ]
  },
];
export class getMenu {
  getMenuItems(): any {
    return this.menuItems;
  }

  menuItems: MenuItem[] = [
    {
      label: 'MENU.TITLE',
      isTitle: true,
      display: true,
    },
    {
      label: 'MENU.DASHBOARD',
      icon: 'home',
      link: '/dashboard',
      display: true,
    },
    {
      label: 'MENU.NEWS',
      icon: 'bookmark',
      link: '/news',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'Uređaji',
      icon: 'smartphone',
      link:'/device',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'Narudžbe',
      icon: 'file-text',
      link: '/orders',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),

    },
    {
      label: 'Nabavke',
      icon: 'shopping-cart',
      link: '/purchase-requests',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },

    {
      label: 'Materijali',
      icon: 'folder-minus',
      link: '/materials',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },

    {
      label: 'MENU.SERVICES',
      icon: 'shopping-cart',
      link: '/services',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.PRICE_LIST',
      icon: 'book-open',
      link: '/price-list-preview',
      display: AuthGuard.isActive(),
    },
    {
      label: 'MENU.REPORTING',
      icon: 'file-text',
      link: '/reporting',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.EMPLOYEES',
      icon: 'users',
      link: '/employees',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() || AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.CLIENTS',
      icon: 'users',
      link: '/clients',
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() ||
          AuthEmployeeGuard.isActive() ||
          AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.REGIONAL_SETTINGS',
      isTitle: true,
      display:
        AuthGuard.isActive() &&
        (AuthAdminGuard.isActive() || AuthCompanyOwnerGuard.isActive()),
    },
    {
      label: 'MENU.COUNTRIES',
      icon: 'globe',
      link: '/countries',
      display: AuthGuard.isActive() && AuthAdminGuard.isActive(),
    },
    {
      label: 'MENU.CITIES',
      icon: 'globe',
      link: '/cities',
      display: AuthGuard.isActive() && AuthAdminGuard.isActive(),
    },
  ];
}
