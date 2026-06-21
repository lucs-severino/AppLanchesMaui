namespace App.Validations
{
    public interface IValidator
    {
        string NomeErro { get; set; }
        string EmailErro { get; set; }
        string SenhaErro { get; set; }
        string TelefoneErro { get; set; }
        Task<bool> Validar(string nome, string email, string senha, string telefone);
    }
}