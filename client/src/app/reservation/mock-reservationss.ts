import { Reservation } from './reservation.model';

const JsonReservations = [
  {
    firstName: 'Stijn',
    lastName: 'Van Riet',
    phoneNumber: '0496512796',
    email: 'stijn.vanriet@student.hogent.be',
    remarks: '',
    services: ['trim cut', 'quick shave'],
    barber: 'Piet',
    date: '2021-07-07T18:25:43.511Z',
  },

  {
    firstName: 'Mia',
    lastName: 'De Smedt',
    phoneNumber: '0488888888',
    email: 'miadesmedt@email.com',
    remarks: '',
    services: ['cut and brushing', 'coloring'],
    barber: 'Jef',
    date: '2021-08-07T18:25:43.511Z',
  },
];
export const RESERVATIONS: Reservation[] = JsonReservations.map(Reservation.fromJSON);