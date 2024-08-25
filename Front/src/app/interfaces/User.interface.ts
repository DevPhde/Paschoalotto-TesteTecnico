import { Login } from "./Login.interface";
import { Picture } from "./Picture.interface";

export interface User {
  idName: string | null;
  idValue: string | null;
  gender: string;
  title: string;
  fullName: string;
  email: string;
  dateOfBirthday: Date;
  age: number;
  registeredDate: Date;
  ageRegistration: number;
  phone: string;
  cell: string;
  nat: string;
  login: Login;
  location: Location;
  picture: Picture;
  id: number;
}
