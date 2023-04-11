

namespace Manager.Domain.Entities
{
    public abstract class Base
    {

        public Base() {
            _errors = new List<string>();
            id = Guid.NewGuid();
            CreateAt = DateTime.Now; 
        }


      public Guid id { get; set; }
      public DateTime CreateAt { get; set; }

      internal List<string> _errors;
      public IReadOnlyCollection<string> Erros => _errors;

      public abstract bool Validate();

    }
}
