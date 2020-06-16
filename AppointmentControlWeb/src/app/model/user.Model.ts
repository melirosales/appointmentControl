 
export class UserModel {
  password: string; 
  user_Name: string; 
  full_Name: string;  
  pk_User: number; 

  constructor() {
    this.pk_User = 0;
    this.password = '';
    this.user_Name = '';
    this.full_Name = ''; 
  }
}
