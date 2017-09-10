using ProjetoAcessoDados.Dominio;
using ProjetoAcessoDados.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjetoAcessoDados.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class AppContext : DbContext
    {
        static AppContext()
        {
            Database.SetInitializer<AppContext>(null);
        }
        public DbSet<MailQueue> MailQueue { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Financeiro> Financeiroes { get; set; }
        public DbSet<FinanceiroParcela> FinanceiroParcelas { get; set; }
        public DbSet<Remessa> Remessa { get; set; }
        public DbSet<MeioPagamento> MeioPagamentoes { get; set; }
        public DbSet<PlanoConta> PlanoContas { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<TransferenciaConta> Transferencias { get; set; }
        public DbSet<Modulo> Moduloes { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuario { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<DadosPF> DadosPF { get; set; }
        public DbSet<DadosPJ> DadosPJ { get; set; }
        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
        public DbSet<EstadoCivil> EstadoCivil { get; set; }

        public AppContext()
            : base("AppConect")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<MailTemplate>().ToTable("MailTemplate");
            modelBuilder.Entity<MailTemplate>().HasKey(p => p.Id);
            modelBuilder.Entity<MailTemplate>().Property(p => p.Filename)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<MailTemplate>().Property(p => p.Folder)
               .HasMaxLength(50)
               .IsRequired();
            modelBuilder.Entity<MailTemplate>().Property(p => p.Subject)
                .HasMaxLength(120)
                .IsRequired();
            modelBuilder.Entity<MailTemplate>().Property(p => p.Description)
                .HasMaxLength(300);
            modelBuilder.Entity<MailTemplate>().Property(p => p.Identifier)
                .HasMaxLength(50);

            modelBuilder.Entity<MailQueue>().ToTable("MailQueue");
            modelBuilder.Entity<MailQueue>().HasKey(p => p.Id);
            modelBuilder.Entity<MailQueue>()
                .HasRequired(p => p.Template)
                .WithMany()
                .HasForeignKey(p => p.TemplateId);

            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new EstadosMap());
            modelBuilder.Configurations.Add(new CidadesMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new FuncionalidadeMap());
            modelBuilder.Configurations.Add(new GrupoUsuarioMap());
            modelBuilder.Configurations.Add(new ModuloMap());
            modelBuilder.Configurations.Add(new ContaMap());
            modelBuilder.Configurations.Add(new FinanceiroMap());
            modelBuilder.Configurations.Add(new FinanceiroParcelaMap());
            modelBuilder.Configurations.Add(new RemessaMap());
            modelBuilder.Configurations.Add(new ChequeMap());
            modelBuilder.Configurations.Add(new PlanoContaMap());
            modelBuilder.Configurations.Add(new BancoMap());
            modelBuilder.Configurations.Add(new TransferenciaContaMap());
            modelBuilder.Configurations.Add(new MeioPagamentoMap());

            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new DadosPFMap());
            modelBuilder.Configurations.Add(new DadosPJMap());
            modelBuilder.Configurations.Add(new PessoaFisicaMap());
            modelBuilder.Configurations.Add(new PessoaJuridicaMap());
            modelBuilder.Configurations.Add(new EstadoCivilMap());

        }
    }
}