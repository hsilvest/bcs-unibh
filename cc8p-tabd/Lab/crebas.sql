/*==============================================================*/
/* DBMS name:      ORACLE Version 10g                           */
/* Created on:     29/08/2013 21:37:03                          */
/*==============================================================*/


ALTER TABLE BAIRRO
   DROP CONSTRAINT FK_BAIRRO_REFERENCE_CIDADE;

ALTER TABLE CIDADE
   DROP CONSTRAINT FK_CIDADE_REFERENCE_ESTADO;

ALTER TABLE COMPRADOR
   DROP CONSTRAINT FK_COMPRADO_REFERENCE_BAIRRO;

ALTER TABLE MODELO
   DROP CONSTRAINT FK_MODELO_REFERENCE_MARCA;

ALTER TABLE PROPOSTA_COMPRA
   DROP CONSTRAINT FK_PROPOSTA_REFERENCE_COMPRADO;

ALTER TABLE PROPOSTA_COMPRA
   DROP CONSTRAINT FK_PROPOSTA_REFERENCE_PROPOSTA;

ALTER TABLE PROPOSTA_COMPRA
   DROP CONSTRAINT FK_PROPOSTA_REFERENCE_FORMA_PG;

ALTER TABLE PROPOSTA_VENDA
   DROP CONSTRAINT FK_PROPOSTA_REFERENCE_VEICULO;

ALTER TABLE PROPOSTA_VENDA
   DROP CONSTRAINT FK_PROPOSTA_REFERENCE_PG;

ALTER TABLE PROPRIETARIO
   DROP CONSTRAINT FK_PROPRIET_REFERENCE_BAIRRO;

ALTER TABLE VEICULO
   DROP CONSTRAINT FK_VEICULO_REFERENCE_PROPRIET;

ALTER TABLE VEICULO
   DROP CONSTRAINT FK_VEICULO_REFERENCE_MODELO;

DROP TABLE BAIRRO CASCADE CONSTRAINTS;

DROP TABLE CIDADE CASCADE CONSTRAINTS;

DROP TABLE COMPRADOR CASCADE CONSTRAINTS;

DROP TABLE ESTADO CASCADE CONSTRAINTS;

DROP TABLE FORMA_PGTO CASCADE CONSTRAINTS;

DROP TABLE MARCA CASCADE CONSTRAINTS;

DROP TABLE MODELO CASCADE CONSTRAINTS;

DROP TABLE PROPOSTA_COMPRA CASCADE CONSTRAINTS;

DROP TABLE PROPOSTA_VENDA CASCADE CONSTRAINTS;

DROP TABLE PROPRIETARIO CASCADE CONSTRAINTS;

DROP TABLE VEICULO CASCADE CONSTRAINTS;

/*==============================================================*/
/* Table: BAIRRO                                                */
/*==============================================================*/
CREATE TABLE BAIRRO  (
   COD_BAIRRO           NUMBER                          NOT NULL,
   COD_CIDADE           VARCHAR(50),
   NOME_BAIRRO          VARCHAR(50),
   CONSTRAINT PK_BAIRRO PRIMARY KEY (COD_BAIRRO)
);

/*==============================================================*/
/* Table: CIDADE                                                */
/*==============================================================*/
CREATE TABLE CIDADE  (
   UF                   VARCHAR(2),
   COD_CIDADE           VARCHAR(50)                     NOT NULL,
   NOME_CIDADE          VARCHAR(50),
   CONSTRAINT PK_CIDADE PRIMARY KEY (COD_CIDADE)
);

/*==============================================================*/
/* Table: COMPRADOR                                             */
/*==============================================================*/
CREATE TABLE COMPRADOR  (
   COD_BAIRRO           NUMBER,
   CPF_COMPRADOR        VARCHAR(11)                     NOT NULL,
   NOME_COMPRADOR       VARCHAR(50),
   LOGRADOURO_COMPRADOR VARCHAR(50),
   NUMERO_COMPRADOR     NUMBER,
   COMPLEMENTO_COMPRADOR VARCHAR(50),
   CEP_COMPRADOR        VARCHAR(50),
   CONSTRAINT PK_COMPRADOR PRIMARY KEY (CPF_COMPRADOR)
);

/*==============================================================*/
/* Table: ESTADO                                                */
/*==============================================================*/
CREATE TABLE ESTADO  (
   UF                   VARCHAR(2)                      NOT NULL,
   NOME_ESTADO          VARCHAR(50),
   CONSTRAINT PK_ESTADO PRIMARY KEY (UF)
);

/*==============================================================*/
/* Table: FORMA_PGTO                                            */
/*==============================================================*/
CREATE TABLE FORMA_PGTO  (
   COD_FORMA            NUMBER                          NOT NULL,
   DESC_FORMA           VARCHAR(50),
   CONSTRAINT PK_FORMA_PGTO PRIMARY KEY (COD_FORMA)
);

/*==============================================================*/
/* Table: MARCA                                                 */
/*==============================================================*/
CREATE TABLE MARCA  (
   COD_MARCA            NUMBER                          NOT NULL,
   DESC_MARCA           VARCHAR(50),
   CONSTRAINT PK_MARCA PRIMARY KEY (COD_MARCA)
);

/*==============================================================*/
/* Table: MODELO                                                */
/*==============================================================*/
CREATE TABLE MODELO  (
   COD_MARCA            NUMBER                          NOT NULL,
   COD_MODELO           NUMBER                          NOT NULL,
   DESC_MODELO          VARCHAR(50),
   CONSTRAINT PK_MODELO PRIMARY KEY (COD_MODELO)
);

/*==============================================================*/
/* Table: PROPOSTA_COMPRA                                       */
/*==============================================================*/
CREATE TABLE PROPOSTA_COMPRA  (
   COD_PROPOSTA_COMPRA  NUMBER                          NOT NULL,
   COD_FORMA            NUMBER,
   CPF_COMPRADOR        VARCHAR(11),
   COD_PROP_VENDA       NUMBER,
   VALOR_PROP_COMPRA    NUMBER,
   STATUS               VARCHAR(50),
   CONSTRAINT PK_PROPOSTA_COMPRA PRIMARY KEY (COD_PROPOSTA_COMPRA)
);

/*==============================================================*/
/* Table: PROPOSTA_VENDA                                        */
/*==============================================================*/
CREATE TABLE PROPOSTA_VENDA  (
   COD_PROP_VENDA       NUMBER                          NOT NULL,
   COD_VEICULO          NUMBER,
   COD_FORMA            NUMBER,
   VALOR_PROPOSTA       NUMBER,
   CONSTRAINT PK_PROPOSTA_VENDA PRIMARY KEY (COD_PROP_VENDA)
);

/*==============================================================*/
/* Table: PROPRIETARIO                                          */
/*==============================================================*/
CREATE TABLE PROPRIETARIO  (
   CPF                  VARCHAR(11)                          NOT NULL,
   COD_BAIRRO           NUMBER,
   NOME_PROPRIETARIO    VARCHAR(50),
   LOGRADOURO           VARCHAR(50),
   NUMERO               NUMBER,
   COMPLEMENTO          VARCHAR(50),
   CEP                  NUMBER,
   CONSTRAINT PK_PROPRIETARIO PRIMARY KEY (CPF)
);

/*==============================================================*/
/* Table: VEICULO                                               */
/*==============================================================*/
CREATE TABLE VEICULO  (
   COD_VEICULO          NUMBER                          NOT NULL,
   COD_MODELO           NUMBER,
   CPF                  VARCHAR(11),
   CARACTERISTICAS      VARCHAR(50),
   STATUS_VEICULO       VARCHAR(30),
   CONSTRAINT PK_VEICULO PRIMARY KEY (COD_VEICULO)
);

ALTER TABLE BAIRRO
   ADD CONSTRAINT FK_BAIRRO_REFERENCE_CIDADE FOREIGN KEY (COD_CIDADE)
      REFERENCES CIDADE (COD_CIDADE);

ALTER TABLE CIDADE
   ADD CONSTRAINT FK_CIDADE_REFERENCE_ESTADO FOREIGN KEY (UF)
      REFERENCES ESTADO (UF);

ALTER TABLE COMPRADOR
   ADD CONSTRAINT FK_COMPRADO_REFERENCE_BAIRRO FOREIGN KEY (COD_BAIRRO)
      REFERENCES BAIRRO (COD_BAIRRO);

ALTER TABLE MODELO
   ADD CONSTRAINT FK_MODELO_REFERENCE_MARCA FOREIGN KEY (COD_MARCA)
      REFERENCES MARCA (COD_MARCA);

ALTER TABLE PROPOSTA_COMPRA
   ADD CONSTRAINT FK_PROPOSTA_REFERENCE_COMPRADO FOREIGN KEY (CPF_COMPRADOR)
      REFERENCES COMPRADOR (CPF_COMPRADOR);

ALTER TABLE PROPOSTA_COMPRA
   ADD CONSTRAINT FK_PROPOSTA_REFERENCE_PROPOSTA FOREIGN KEY (COD_PROP_VENDA)
      REFERENCES PROPOSTA_VENDA (COD_PROP_VENDA);

ALTER TABLE PROPOSTA_COMPRA
   ADD CONSTRAINT FK_PROPOSTA_REFERENCE_FORMA_PG FOREIGN KEY (COD_FORMA)
      REFERENCES FORMA_PGTO (COD_FORMA);

ALTER TABLE PROPOSTA_VENDA
   ADD CONSTRAINT FK_PROPOSTA_REFERENCE_VEICULO FOREIGN KEY (COD_VEICULO)
      REFERENCES VEICULO (COD_VEICULO);

ALTER TABLE PROPOSTA_VENDA
   ADD CONSTRAINT FK_PROPOSTA_REFERENCE_PG FOREIGN KEY (COD_FORMA)
      REFERENCES FORMA_PGTO (COD_FORMA);

ALTER TABLE PROPRIETARIO
   ADD CONSTRAINT FK_PROPRIET_REFERENCE_BAIRRO FOREIGN KEY (COD_BAIRRO)
      REFERENCES BAIRRO (COD_BAIRRO);

ALTER TABLE VEICULO
   ADD CONSTRAINT FK_VEICULO_REFERENCE_PROPRIET FOREIGN KEY (CPF)
      REFERENCES PROPRIETARIO (CPF);

ALTER TABLE VEICULO
   ADD CONSTRAINT FK_VEICULO_REFERENCE_MODELO FOREIGN KEY (COD_MODELO)
      REFERENCES MODELO (COD_MODELO);

