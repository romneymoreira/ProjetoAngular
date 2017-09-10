using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Dominio
{
    public class Usuario
    {
        public int IdUsuario { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }

        public string Situacao { get; private set; }
        public int IdGrupoUsuario { get; private set; }
        public GrupoUsuario GrupoUsuario { get; private set; }

        public Usuario() { }

        public Usuario(string login, string email, string nome, GrupoUsuario grupoUsuario)
        {
            SetLogin(login);
            SetEmail(email);
            SetNome(nome);
            SetSenha("123456");
            SetSituacao("Ativo");
            SetGrupoUsuario(grupoUsuario);
        }

        public void SetGrupoUsuario(GrupoUsuario grupoUsuario)
        {
            if (grupoUsuario != null)
                this.GrupoUsuario = grupoUsuario;
            else
                throw new Exception("Grupo de Usuário não definido");
        }

        public void SetSenha(string senha)
        {
            if (!string.IsNullOrEmpty(senha))
                this.Senha = senha;
            else
                throw new Exception("Senha não definida");
        }

        public void SetSituacao(string situacao)
        {
            if (!string.IsNullOrEmpty(situacao))
                this.Situacao = situacao;
            else
                throw new Exception("Situação não definida");
        }

        public void SetNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
                this.Nome = nome;
            else
                throw new Exception("Nome Obrigatório");
        }

        public void SetLogin(string login)
        {
            if (!string.IsNullOrEmpty(login))
                this.Login = login;
            else
                throw new Exception("Login Obrigatório");
        }

        public void SetEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
                this.Email = email;
            else
                throw new Exception("Email Obrigatório");
        }

        public void Desativar()
        {
            this.Situacao = "Inativo";
        }

        public void Ativar()
        {
            this.Situacao = "Ativo";
        }

        public void AlterarSenha(string novasenha)
        {
            if (!string.IsNullOrEmpty(novasenha))
                this.Senha = novasenha;
            else
                throw new Exception("Nova Senha Obrigatório");
        }

        public void Excluir()
        {
            this.Situacao = "Excluido";
        }

        public void ResetarSenha()
        {
            /* Random random = new Random();
             return random.Next(0, 6); */
            this.Senha = "123456";
        }
    }
}