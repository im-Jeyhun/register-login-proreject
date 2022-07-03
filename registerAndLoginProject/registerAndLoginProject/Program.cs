using System;
using System.Collections.Generic;

namespace registerAndLoginProject
{
    internal class Program
    {
        public static List<UserRegValidation> users { get; set; } = new List<UserRegValidation>()
        {
            new UserRegValidation("Super", "Admin", "admin@gmail.com", "123321", "123321")
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("/register");
                Console.WriteLine("/login");
                Console.WriteLine("/show-persons");
                Console.Write("Insert command : ");
                string targetCommand = Console.ReadLine();

                if (targetCommand == "/register")
                {
                    Console.Write("Insert name : ");
                    string name = Console.ReadLine();
                    Console.Write("Insert surname : ");
                    string surName = Console.ReadLine();
                    Console.Write("Insert Email : ");
                    string email = Console.ReadLine();
                    Console.Write("Insert Password : ");
                    string password = Console.ReadLine();
                    Console.Write("Insert Password Again : ");
                    string passwordAgain = Console.ReadLine();

                    AddNewUser(name, surName, email, password, passwordAgain);



                }
                else if (targetCommand == "/show-persons")
                {
                    ShowPersons();
                }

                else if (targetCommand == "/login")
                {
                    Console.Write("Insert Email for login : ");
                    string email = Console.ReadLine();
                    Console.Write("Insert Password for password : ");
                    string parol = Console.ReadLine();

                    LoginUser(email, parol);

                }
                else
                {
                    Console.WriteLine("Command not found , pls try again...");
                }
            }

        }
        public static bool AddNewUser(string name, string surNAme, string email, string firspassword, string secondPassword)
        {
            UserRegValidation newuser = new UserRegValidation(name, surNAme, email, firspassword, secondPassword);
            if (newuser.IsRegValidatorsValid(newuser, users))
            {
                users.Add(newuser);
                Console.WriteLine("You successfully registered, now you can login with your new account!");
                return true;

            }
            Console.WriteLine("information entered wrong, pls fill information again");
            return false;

        }

        public static bool LoginUser(string loginEmail, string loginPass)
        {
            UserLogValidation newlogin = new UserLogValidation(loginEmail, loginPass);
            if (IsLogValidatorValid(newlogin))
            {
                Console.WriteLine("You successfully login into system");
                ShowOnlyNameAndSurnam(loginEmail);
  
                return true;
            }
            Console.WriteLine("Informatios of user isnt correct , pls try again... ");
            return false;
        }


        public static void ShowPersons()
        {
            Console.WriteLine("Persons in database : ");
            foreach (UserRegValidation user in users)
            {
                Console.WriteLine(user.GetInfo());
            }
        }

        public static void ShowOnlyNameAndSurnam(string targetmail)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == targetmail)
                {

                    Console.WriteLine($"Welcome to your account {users[i].Name} {users[i].SurName} ");

                }
            }
        }


        public static bool IsLoginMail(string loginemail)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == loginemail)
                {
                    return true;
                }
            }
            Console.WriteLine("Email is not correct..");
            return false;
        }

        public static bool IsLoginPass(string loginPass)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Password == loginPass)
                {
                    return true;
                }
            }
            Console.WriteLine("Passwrods is not correct..");
            return false;
        }

        public static bool IsLogValidatorValid(UserLogValidation newuser)
        {
            return IsLoginMail(newuser.LoginEmail) & IsLoginPass(newuser.LoginPass);
        }

    }


    class Validator
    {
        public bool IsRegValidatorsValid(UserRegValidation newuser, List<UserRegValidation> users)
        {
            return IsFirstNameValid(newuser.Name) & IsSurNameValid(newuser.SurName) & IsEMailValid(newuser.Email) & IsMailSame(newuser.Email, users) & IsPassworValid(newuser.Password, newuser.SecondPassword);
        }

        public static bool IsMailSame(string email, List<UserRegValidation> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == email)
                {
                    Console.WriteLine("This email already was entered in system , try different one.");
                    return false;
                }
            }
            return true;
        }

        public bool IsTextLengthValid(string text, int startLength, int endLength)
        {
            if (text.Length >= startLength && text.Length <= endLength)
            {
                return true;
            }
            return false;
        }

        public bool IsFirstNameValid(string name)
        {
            if (!IsTextLengthValid(name, 3, 30))
            {
                Console.WriteLine("Name isnt correct ");
                return false;
            }
            return true;
        }

        public bool IsSurNameValid(string surName)
        {
            if (!IsTextLengthValid(surName, 5, 50))
            {
                Console.WriteLine("Surname is not correct ");
                return false;
            }
            return true;
        }
        public bool IsEMailValid(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '@')
                {
                    return true;
                }
            }
            Console.WriteLine("Email is not correct , email must be like example@mail.com...");
            return false;
        }

        public bool IsPassworValid(string firstPass, string secondPass)
        {

            if (firstPass == secondPass)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Passwords must be same");
                return false;
            }
        }


    }

    class UserRegValidation : Validator
    {

        public string Name { get; private set; }
        public string SurName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string SecondPassword { get; private set; }

        public UserRegValidation(string name, string surName, string email, string firstpassword, string secondPassword)
        {
            //if (IsFirstNameValid(name) & IsSurNameValid(surName) & IsEMailValid(email) & IsPassworValid(firstpassword, secondPassword))
            //{ Muellim sizden bunu sorusacam deye silmemisem yadimdan cixmayib :)

            Name = name;
            SurName = surName;
            Email = email;
            Password = firstpassword;
            SecondPassword = secondPassword;

            //}


        }

        public string GetInfo()
        {
            return Name + " " + SurName + " " + Email + " " + Password;
        }
    }

    class UserLogValidation
    {
        public string LoginEmail { get; private set; }

        public string LoginPass { get; private set; }
        public UserLogValidation(string loginEmail, string loginPass)

        {

            LoginEmail = loginEmail;
            LoginPass = loginPass;
        }


    }
}
