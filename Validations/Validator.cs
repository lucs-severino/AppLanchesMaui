using App.Validations;

namespace Application.Validations
{
    public class Validator : IValidator
    {
        public string NomeErro { get; set; } = string.Empty;
        public string EmailErro { get; set; } = string.Empty;
        public string SenhaErro { get; set; } = string.Empty;
        public string TelefoneErro { get; set; } = string.Empty;

        private const string NomeVazioErroMsg = "Por favor, informe o seu nome.";
        private const string NomeInvalidoErroMsg = "Por favor, informe um nome válido.";
        private const string EmailVazioErroMsg = "Por favor, informe o seu email.";
        private const string EmailInvalidoErroMsg = "Por favor, informe um email válido.";
        private const string SenhaVazioErroMsg = "Por favor, informe a sua senha.";
        private const string SenhaInvalidaErroMsg = "A senha deve conter pelo menos 8 caracteres, incluindo letras maiúsculas, minúsculas, números e caracteres especiais.";
        private const string TelefoneVazioErroMsg = "Por favor, informe o seu telefone.";
        private const string TelefoneInvalidoErroMsg = "Por favor, informe um telefone válido.";

        public Task<bool> Validar(string nome, string email, string senha, string telefone)
        {
            var insNomeValido = ValidarNome(nome);
            var insEmailValido = ValidarEmail(email);
            var insSenhaValida = ValidarSenha(senha);
            var insTelefoneValido = ValidarTelefone(telefone);

            return Task.FromResult(insNomeValido && insEmailValido && insSenhaValida && insTelefoneValido);
        }

        private bool ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                NomeErro = NomeVazioErroMsg;
                return false;
            }

            if (nome.Length < 2)
            {
                NomeErro = NomeInvalidoErroMsg;
                return false;
            }

            NomeErro = string.Empty;
            return true;
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                EmailErro = EmailVazioErroMsg;
                return false;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                EmailErro = EmailInvalidoErroMsg;
                return false;
            }

            EmailErro = string.Empty;
            return true;
        }

        private bool ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                TelefoneErro = TelefoneVazioErroMsg;
                return false;
            }

            if (telefone.Length < 12)
            {
                TelefoneErro = TelefoneInvalidoErroMsg;
                return false;
            }

            TelefoneErro = string.Empty;
            return true;
        }

        private bool ValidarSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
            {
                SenhaErro = SenhaVazioErroMsg;
                return false;
            }

            if (senha.Length < 8 ||
                !senha.Any(char.IsUpper) ||
                !senha.Any(char.IsLower) ||
                !senha.Any(char.IsDigit) ||
                !senha.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                SenhaErro = SenhaInvalidaErroMsg;
                return false;
            }

            SenhaErro = string.Empty;
            return true;
        }

    }
}