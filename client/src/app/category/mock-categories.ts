import { Category } from './category.model';

const JsonCategories = [
  {
    name: 'Barbershape Women',
    services: [
      'only cut',
      'only brushing',
      'cut and brushing',
      'coloring',
      'makeup',
    ],
    dateAdded: '2020-02-07T18:25:43.511Z',
  },

  {
    name: 'Barbershape Men',
    services: [
      'cut and styling',
      'styling',
      'trim cut',
      'special cut',
      'coloring',
      'beard trim',
      'quick shave',
      'only full shave',
      'head shave',
    ],
    dateAdded: '2020-02-08T16:25:43.511Z',
  },

  {
    name: 'Barber kids boys',
    services: ['0-7 years old', '8-12 yers old', '13-18 years old'],
    dateAdded: '2020-02-08T16:25:43.511Z',
  },

  {
    name: 'Barber kids girls',
    services: ['0-7 years old', '8-12 yers old', '13-18 years old'],
    dateAdded: '2020-02-08T16:25:43.511Z',
  },

  {
    name: 'Barber Students male',
    services: ['cut and styling', 'coloring', 'coloring, cut and styling'],
    dateAdded: '2020-02-08T16:25:43.511Z',
  },

  {
    name: 'Barber Students female',
    services: ['cut and brushing', 'coloring'],
    dateAdded: '2020-02-08T16:25:43.511Z',
  },
];
export const CATEGORIES: Category[] = JsonCategories.map(Category.fromJSON);