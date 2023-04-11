using Manager.Domain.Validators;
namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //EF Constructor
        #pragma warning disable CS8618 
        protected User() { }
        #pragma warning restore CS8618 

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }


        public void changeName(string name)
        {
            Name = name;
            Validate();
        }


        public void changeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void changePassword(string password)
        {
            Password = password;
            Validate();
        }


        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }
                throw new Exception($"Alguns campos estão invalidos {_errors[0]}");


            }

            return true;

              
        }
    }
  
}
