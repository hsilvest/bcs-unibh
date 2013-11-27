Insert into TIPO_MOVEL (COD_TIPO,NOME_TIPO) values (1,'CASA');
INSERT INTO TIPO_MOVEL (COD_TIPO,NOME_TIPO) VALUES (2,'APARTAMENTO');

Insert into ESTADO (COD_ESTADO,UF) values (1,'MG');
Insert into ESTADO (COD_ESTADO,UF) values (2,'SP');
INSERT INTO ESTADO (COD_ESTADO,UF) VALUES (3,'RJ');

Insert into CIDADE (COD_CIDADE,NOME_CIDADE,COD_ESTADO) values (1,'BELO HORIZONTE',1);
Insert into CIDADE (COD_CIDADE,NOME_CIDADE,COD_ESTADO) values (2,'SAO PAULO',2);
INSERT INTO CIDADE (COD_CIDADE,NOME_CIDADE,COD_ESTADO) VALUES (3,'RIO DE JANEIRO',3);

Insert into IMOVEL (COD_IMOVEL,QTD_QUARTOS,TAMANHO,ELEVADOR,DEP_EMPREGADA,GARAGEM,VALOR,COD_TIPO,LOGRADOURO,NUMERO,COMPLEMENTO,COD_CIDADE) values (1,1,50,'0',0,1,180000,2,'RUA DOIS',432,'AP 107',1);
Insert into IMOVEL (COD_IMOVEL,QTD_QUARTOS,TAMANHO,ELEVADOR,DEP_EMPREGADA,GARAGEM,VALOR,COD_TIPO,LOGRADOURO,NUMERO,COMPLEMENTO,COD_CIDADE) values (2,2,70,'0',0,1,190000,2,'RUA TRES',43,'AP 65',2);
Insert into IMOVEL (COD_IMOVEL,QTD_QUARTOS,TAMANHO,ELEVADOR,DEP_EMPREGADA,GARAGEM,VALOR,COD_TIPO,LOGRADOURO,NUMERO,COMPLEMENTO,COD_CIDADE) values (3,1,70,'0',0,1,220000,2,'RUA QUATRO',443,'AP 34',3);
Insert into IMOVEL (COD_IMOVEL,QTD_QUARTOS,TAMANHO,ELEVADOR,DEP_EMPREGADA,GARAGEM,VALOR,COD_TIPO,LOGRADOURO,NUMERO,COMPLEMENTO,COD_CIDADE) values (4,2,100,'1',1,1,280000,1,'RUA CINCO',54,null,1);
INSERT INTO IMOVEL (COD_IMOVEL,QTD_QUARTOS,TAMANHO,ELEVADOR,DEP_EMPREGADA,GARAGEM,VALOR,COD_TIPO,LOGRADOURO,NUMERO,COMPLEMENTO,COD_CIDADE) VALUES (5,3,120,'1',1,2,350000,1,'RUA SEIS',76,NULL,2);

Insert into COMPRADOR (CPF_CNPJ_COMP,NOME_COMP) values ('1234567890','JOAO DA SILVA');
Insert into COMPRADOR (CPF_CNPJ_COMP,NOME_COMP) values ('0987654321','JOSE DE SOUZA');
Insert into COMPRADOR (CPF_CNPJ_COMP,NOME_COMP) values ('8490234904','CARLOS ALBERTO');
Insert into COMPRADOR (CPF_CNPJ_COMP,NOME_COMP) values ('4329804201','MARIA DA SIVA');
INSERT INTO COMPRADOR (CPF_CNPJ_COMP,NOME_COMP) VALUES ('90943203424','CRISTINA PEREIRA');

INSERT INTO NOTA_FISCAL (NF,DATA,VLR_CORRETAGEM,CPF_CNPJ_COMP) VALUES (1,TO_DATE('25/04/2014','dd/mm/yyyy'),5000,'1234567890');
INSERT INTO NOTA_FISCAL (NF,DATA,VLR_CORRETAGEM,CPF_CNPJ_COMP) VALUES (2,TO_DATE('30/05/2014','dd/mm/yyyy'),5000,'0987654321');
INSERT INTO NOTA_FISCAL (NF,DATA,VLR_CORRETAGEM,CPF_CNPJ_COMP) VALUES (3,TO_DATE('17/06/2014','dd/mm/yyyy'),7000,'8490234904');
INSERT INTO NOTA_FISCAL (NF,DATA,VLR_CORRETAGEM,CPF_CNPJ_COMP) VALUES (4,TO_DATE('28/07/2014','dd/mm/yyyy'),10000,'4329804201');
INSERT INTO NOTA_FISCAL (NF,DATA,VLR_CORRETAGEM,CPF_CNPJ_COMP) VALUES (5,TO_DATE('10/08/2014','dd/mm/yyyy'),15000,'90943203424');

Insert into IMOVEIS_NOTA (NF,COD_IMOVEL,VLR_IMOVEL) values (1,1,185000);
Insert into IMOVEIS_NOTA (NF,COD_IMOVEL,VLR_IMOVEL) values (2,2,195000);
Insert into IMOVEIS_NOTA (NF,COD_IMOVEL,VLR_IMOVEL) values (3,3,227000);
INSERT INTO IMOVEIS_NOTA (NF,COD_IMOVEL,VLR_IMOVEL) VALUES (4,4,290000);
Insert into IMOVEIS_NOTA (NF,COD_IMOVEL,VLR_IMOVEL) values (5,5,365000);
