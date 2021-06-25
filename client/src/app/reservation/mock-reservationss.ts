import { Reservation } from './reservation.model';

const JsonReservations = [
  {
    firstName: 'Stijn',
    lastName: 'Van Riet',
    phoneNumber: '0496512796',
    email: 'stijn.vanriet@student.hogent.be',
    remarks: 'This is a remark.',
    services: [
      { name: 'trim cut', price: 30 },
      { name: 'quick shave', price: 20 },
    ],
    date: '2021-07-07T18:25:43.511Z',
  },

  {
    firstName: 'Mia',
    lastName: 'De Smedt',
    phoneNumber: '0488888888',
    email: 'miadesmedt@email.com',
    remarks: 'This is also a remark.',
    services: [
      { name: 'cut and brushing', price: 60 },
      { name: 'coloring', price: 70 },
    ],
    date: '2021-08-07T18:25:43.511Z',
  },
];
export const RESERVATIONS: Reservation[] = JsonReservations.map(Reservation.fromJSON);