namespace OnlineStore.Domain.ValueObjects
{
    public class CPF
    {
        public CPF(string cpf)
        {
            this.cpf = cpf;
        }

        public string cpf { get; set; }
    }
}