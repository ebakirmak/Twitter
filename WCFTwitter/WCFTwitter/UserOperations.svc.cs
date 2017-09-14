using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTwitter.Operations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserOperations" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserOperations.svc or UserOperations.svc.cs at the Solution Explorer and start debugging.
    public class UserOperations : IUserOperations
    {
        //EntityFramework Nesnemiz
        private TwitterEntities userEdmx = new TwitterEntities();

        //Kayıt Olma
        public bool SignUp(string Name, string Surname, string Email, string Password)
        {
            Users newUser = new Users();
            Users current = new Users();
            try
            {
                //Veritabbanında mail var mı yok mu...
                current = userEdmx.Users.Where(x => x.Email == Email).FirstOrDefault();
                if (current != null)
                    return false;
                //Yeni nesne değerleri gir.
                newUser.Name = Name;
                newUser.Surname = Surname;
                newUser.Email = Email;
                newUser.Password = Password;
                newUser.CreatedDate = DateTime.Now;
                //Veritabanına nesnemizi ekle
                userEdmx.Users.Add(newUser);
            }
            catch (Exception ex)
            {
                //Hata Yakalama
                Console.Write(ex.Message);
                return false;
            }
            finally
            {
                //Değişiklikleri kaydet...
                userEdmx.SaveChanges();

            }

            return true;
        }
     
        //Username oluşturma
        public bool UsernameCreate(int userID, string Username)
        {
            try
            {
                Users UpdateUser = new Users();
                UpdateUser = userEdmx.Users.Where(x => x.ID == userID).FirstOrDefault();
                UpdateUser.Username = Username;
            }
            catch (Exception ex)
            {

                Console.Write(ex.Message);
                return false;
            }
            finally
            {
                userEdmx.SaveChanges();

            }
            return true;

        }

        //Giriş Yapma
        public int Login(string Email, string Password)
        {

            Users login = new Users();
           
            try
            {
                login = userEdmx.Users.Where(x => x.Email == Email).FirstOrDefault();
                if (login == null)
                    return 0;
                if (Password==login.Password)
                {
                    return login.ID;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;                
            }
            finally
            {

            }
            return 0;
        }

        //Password Değiştirme
        public bool PasswordChange(int ID, string CurrentPassword, string NewPassoword)
        {
            Users login = new Users();
            try
            {
                login = userEdmx.Users.Where(x => x.ID == ID).FirstOrDefault();
                if (login.Password == CurrentPassword)
                {
                    login.Password = NewPassoword;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                userEdmx.SaveChanges();            
            }

            return true;
        }

        //Password değişikliği için mail gönderme
        public bool PasswordChangeMailSend(string Email)
        {
            throw new NotImplementedException();
        }      

        public List<GetUsers_Result> GetUsers()
        {
            List<GetUsers_Result> users = new List<GetUsers_Result>();
            //Sql serverda procedür yazdık ve liste olarak döndürdük..
            users = userEdmx.GetUsers().ToList();
            return users;
        }


      
    }
}
