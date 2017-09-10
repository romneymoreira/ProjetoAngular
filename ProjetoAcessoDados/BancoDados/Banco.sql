-- ----------------------------
-- Table structure for Banco
-- ----------------------------
DROP TABLE IF EXISTS `Banco`;
CREATE TABLE `Banco` (
  `IdBanco` int(11) NOT NULL AUTO_INCREMENT,
  `NmBanco` varchar(60) DEFAULT NULL,
  `Codigo` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`IdBanco`)
) ENGINE=InnoDB AUTO_INCREMENT=122 DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for Cheque
-- ----------------------------
DROP TABLE IF EXISTS `Cheque`;
CREATE TABLE `Cheque` (
  `IdCheque` int(11) NOT NULL AUTO_INCREMENT,
  `DataInclusao` datetime DEFAULT NULL,
  `Emitente` varchar(60) DEFAULT NULL,
  `Banco` varchar(60) DEFAULT NULL,
  `Agencia` varchar(20) DEFAULT NULL,
  `Conta` varchar(20) DEFAULT NULL,
  `BomPara` date DEFAULT NULL,
  `Situacao` enum('Emitido','Depositado','Excluido','Devolvido') DEFAULT NULL,
  `IdFinanceiro` int(11) DEFAULT NULL,
  `IdPessoa` int(11) DEFAULT NULL,
  `Historico` text,
  `Valor` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`IdCheque`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for Cidade
-- ----------------------------
DROP TABLE IF EXISTS `Cidade`;
CREATE TABLE `Cidade` (
  `IdCidade` int(11) NOT NULL AUTO_INCREMENT,
  `IdEstado` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `Ibge` int(7) DEFAULT NULL,
  PRIMARY KEY (`IdCidade`)
) ENGINE=InnoDB AUTO_INCREMENT=11243 DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for ConfigBoleto
-- ----------------------------
DROP TABLE IF EXISTS `ConfigBoleto`;
CREATE TABLE `ConfigBoleto` (
  `IdConfigBoleto` int(11) NOT NULL AUTO_INCREMENT,
  `DiasPrazoPagamento` int(3) NOT NULL,
  `CodigoBanco` varchar(4) NOT NULL,
  `Banco` varchar(60) NOT NULL,
  `Agencia` varchar(4) NOT NULL,
  `Conta` varchar(10) NOT NULL,
  `Convenio` varchar(7) NOT NULL,
  `Carteira` varchar(20) NOT NULL,
  `Registro` varchar(20) NOT NULL,
  `Cedente` varchar(60) NOT NULL,
  `Endereco` varchar(100) NOT NULL,
  `Cidade` varchar(60) NOT NULL,
  `Estado` varchar(2) NOT NULL,
  `InstrucoesCaixa` varchar(255) NOT NULL,
  PRIMARY KEY (`IdConfigBoleto`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for Conta
-- ----------------------------
DROP TABLE IF EXISTS `Conta`;
CREATE TABLE `Conta` (
  `IdConta` int(11) NOT NULL AUTO_INCREMENT,
  `NmConta` varchar(60) DEFAULT NULL,
  `Saldo` decimal(10,2) DEFAULT NULL,
  `Situacao` enum('Ativo','Inativo','Excluido') DEFAULT NULL,
  PRIMARY KEY (`IdConta`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for Estado
-- ----------------------------
DROP TABLE IF EXISTS `Estado`;
CREATE TABLE `Estado` (
  `IdEstado` int(11) NOT NULL DEFAULT '0',
  `Sigla` char(2) CHARACTER SET utf8 DEFAULT NULL,
  `Nome` varchar(60) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`IdEstado`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for Financeiro
-- ----------------------------
DROP TABLE IF EXISTS `Financeiro`;
CREATE TABLE `Financeiro` (
  `IdFinanceiro` int(11) NOT NULL AUTO_INCREMENT,
  `TotalDesconto` decimal(10,2) DEFAULT NULL,
  `Total` decimal(10,2) DEFAULT NULL,
  `TotalAcerto` decimal(10,2) DEFAULT NULL,
  `IdPessoa` int(11) DEFAULT NULL,
  `Tipo` varchar(50) DEFAULT NULL,
  `FormaPagamento` varchar(60) DEFAULT NULL,
  `IdContrato` int(11) DEFAULT NULL,
  `IdClinica` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdFinanceiro`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for FinanceiroParcela
-- ----------------------------
DROP TABLE IF EXISTS `FinanceiroParcela`;
CREATE TABLE `FinanceiroParcela` (
  `IdParcela` int(11) NOT NULL AUTO_INCREMENT,
  `IdFinanceiro` int(11) NOT NULL,
  `Numero` int(11) DEFAULT NULL,
  `DataVencimento` date DEFAULT NULL,
  `IdConta` int(11) DEFAULT NULL,
  `IdPlanoConta` int(11) DEFAULT NULL,
  `IdMeioPagamento` int(11) DEFAULT NULL,
  `Valor` decimal(10,2) DEFAULT NULL,
  `Situacao` enum('Aberto','Baixado','Excluido','Negociada') DEFAULT NULL,
  `DataAcerto` date DEFAULT NULL,
  `DiasAtrazo` int(11) DEFAULT NULL,
  `ValorJuros` decimal(10,2) DEFAULT NULL,
  `ValorMora` decimal(10,2) DEFAULT NULL,
  `ValorAcrescimo` decimal(10,2) DEFAULT NULL,
  `ValorDesconto` decimal(10,2) DEFAULT NULL,
  `TotalAcerto` decimal(10,2) DEFAULT NULL,
  `Observacao` text,
  `NossoNumero` varchar(200) DEFAULT NULL,
  `DataInclusao` datetime DEFAULT NULL,
  `IdUsuarioInclusao` int(11) DEFAULT NULL,
  `DataAlteracao` datetime DEFAULT NULL,
  `IdUsuarioAlteracao` int(11) DEFAULT NULL,
  `DataBaixa` datetime DEFAULT NULL,
  `IdUsuarioBaixa` int(11) DEFAULT NULL,
  `IdUsuarioExclusao` int(11) DEFAULT NULL,
  `DataExclusao` datetime DEFAULT NULL,
  `IdRemessa` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdParcela`)
) ENGINE=InnoDB AUTO_INCREMENT=158 DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for Fornecedor
-- ----------------------------
DROP TABLE IF EXISTS `Fornecedor`;
CREATE TABLE `Fornecedor` (
  `IdFornecedor` int(11) NOT NULL,
  PRIMARY KEY (`IdFornecedor`),
  CONSTRAINT `Fornecedor_ibfk_1` FOREIGN KEY (`IdFornecedor`) REFERENCES `Pessoa` (`IdPessoa`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for Funcionalidade
-- ----------------------------
DROP TABLE IF EXISTS `Funcionalidade`;
CREATE TABLE `Funcionalidade` (
  `IdFuncionalidade` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(60) DEFAULT NULL,
  `Controller` varchar(60) DEFAULT NULL,
  `IdModulo` int(11) DEFAULT NULL,
  `Rota` varchar(60) DEFAULT NULL,
  `Action` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`IdFuncionalidade`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for GrupoFuncionalidade
-- ----------------------------
DROP TABLE IF EXISTS `GrupoFuncionalidade`;
CREATE TABLE `GrupoFuncionalidade` (
  `IdGrupoUsuario` int(11) NOT NULL DEFAULT '0',
  `IdFuncionalidade` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`IdFuncionalidade`,`IdGrupoUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for GrupoUsuario
-- ----------------------------
DROP TABLE IF EXISTS `GrupoUsuario`;
CREATE TABLE `GrupoUsuario` (
  `IdGrupoUsuario` int(11) NOT NULL DEFAULT '0',
  `Nome` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`IdGrupoUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for MailQueue
-- ----------------------------
DROP TABLE IF EXISTS `MailQueue`;
CREATE TABLE `MailQueue` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TemplateId` int(11) NOT NULL,
  `Priority` int(11) NOT NULL,
  `Date` datetime NOT NULL,
  `Scheduled` date DEFAULT NULL,
  `Status` varchar(100) NOT NULL,
  `To` varchar(200) NOT NULL,
  `Parameters` varchar(400) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for MailTemplate
-- ----------------------------
DROP TABLE IF EXISTS `MailTemplate`;
CREATE TABLE `MailTemplate` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Filename` varchar(100) NOT NULL,
  `Folder` varchar(50) NOT NULL,
  `Subject` varchar(120) NOT NULL,
  `Description` varchar(300) NOT NULL,
  `Identifier` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for MeioPagamento
-- ----------------------------
DROP TABLE IF EXISTS `MeioPagamento`;
CREATE TABLE `MeioPagamento` (
  `IdMeioPagamento` int(11) NOT NULL AUTO_INCREMENT,
  `NmMeioPagamento` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`IdMeioPagamento`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for Modulo
-- ----------------------------
DROP TABLE IF EXISTS `Modulo`;
CREATE TABLE `Modulo` (
  `IdModulo` int(11) NOT NULL AUTO_INCREMENT,
  `NmModulo` varchar(60) DEFAULT NULL,
  `Icon` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`IdModulo`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for Pessoa
-- ----------------------------
DROP TABLE IF EXISTS `Pessoa`;
CREATE TABLE `Pessoa` (
  `IdPessoa` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(255) NOT NULL,
  `Sexo` enum('M','F') DEFAULT NULL,
  `RazaoSocial` varchar(255) DEFAULT NULL,
  `Tipo` enum('PF','PJ') NOT NULL,
  `DataNascimento` date DEFAULT NULL,
  `CpfCnpj` varchar(20) DEFAULT NULL,
  `RG` varchar(20) DEFAULT NULL,
  `IE` varchar(20) DEFAULT NULL,
  `Situacao` enum('Ativo','Inativo','Excluido') DEFAULT 'Ativo',
  `Profissao` varchar(60) DEFAULT NULL,
  `Mae` varchar(60) DEFAULT NULL,
  `Pai` varchar(60) DEFAULT NULL,
  `Telefone1` varchar(30) DEFAULT NULL,
  `Telefone2` varchar(30) DEFAULT NULL,
  `Site` varchar(80) DEFAULT NULL,
  `Email` varchar(80) DEFAULT NULL,
  `Observacoes` text,
  `DataInclusao` datetime DEFAULT NULL,
  `IdUsuarioInclusao` int(11) DEFAULT NULL,
  `DataExclusao` datetime DEFAULT NULL,
  `IdUsuarioExclusao` int(11) DEFAULT NULL,
  `DataAlteracao` datetime DEFAULT NULL,
  `IdUsuarioAlteracao` int(11) DEFAULT NULL,
  `Conjuge` varchar(60) DEFAULT NULL,
  `TipoEndereco` enum('Cobranca','Principal') DEFAULT NULL,
  `Cep` varchar(10) DEFAULT NULL,
  `IdEstado` int(11) DEFAULT NULL,
  `IdCidade` int(11) DEFAULT NULL,
  `Bairro` varchar(80) DEFAULT NULL,
  `Logradouro` varchar(100) DEFAULT NULL,
  `Numero` varchar(20) DEFAULT NULL,
  `Complemento` varchar(100) DEFAULT NULL,
  `Referencia` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdPessoa`)
) ENGINE=InnoDB AUTO_INCREMENT=656 DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for PlanoConta
-- ----------------------------
DROP TABLE IF EXISTS `PlanoConta`;
CREATE TABLE `PlanoConta` (
  `IdPlanoConta` int(11) NOT NULL AUTO_INCREMENT,
  `NmPlanoConta` varchar(60) DEFAULT NULL,
  `Situacao` enum('Ativo','Inativo','Excluido') DEFAULT NULL,
  `Tipo` enum('Receita','Despesa','Ativo','Passivo','Patrimonio Liquido') DEFAULT NULL,
  `Codigo` varchar(10) DEFAULT NULL,
  `Categoria` enum('') DEFAULT NULL,
  PRIMARY KEY (`IdPlanoConta`)
) 
-- ----------------------------
-- Table structure for Remessa
-- ----------------------------
DROP TABLE IF EXISTS `Remessa`;
CREATE TABLE `Remessa` (
  `IdRemessa` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(255) DEFAULT NULL,
  `Data` datetime DEFAULT NULL,
  `IdUsuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdRemessa`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for SubFuncionalidade
-- ----------------------------
DROP TABLE IF EXISTS `SubFuncionalidade`;
CREATE TABLE `SubFuncionalidade` (
  `IdSubFuncionalidade` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(60) DEFAULT NULL,
  `IdFuncionalidade` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdSubFuncionalidade`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
-- ----------------------------
-- Table structure for Usuario
-- ----------------------------
DROP TABLE IF EXISTS `Usuario`;
CREATE TABLE `Usuario` (
  `IdUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `Nome` varchar(100) DEFAULT NULL,
  `Login` varchar(60) NOT NULL,
  `Senha` varchar(30) NOT NULL,
  `Email` varchar(200) DEFAULT NULL,
  `Situacao` enum('Ativo','Inativo') NOT NULL,
  `IdGrupoUsuario` int(11) DEFAULT NULL,
  `Tipo` enum('Profissional de Saude','Administrador','Atendente') DEFAULT NULL,
  PRIMARY KEY (`IdUsuario`),
  UNIQUE KEY `Unique_login` (`Login`) USING BTREE,
  UNIQUE KEY `Unique_Email` (`Email`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
