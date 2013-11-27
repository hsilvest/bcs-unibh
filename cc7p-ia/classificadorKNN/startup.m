function startup
% *************************************************************************
% Centro Universitário de Belo Horizonte - UNIBH
% Trabalho Prático de Inteligencia Artificial
% Professora Ana Paula Ladeira
% Alunos: Henrique Silvestre Souza e Pedro Lucas Cristianos
% Estudo de Técnicas de Aprendizado de Máquina Aplicadas a Problemas de
% Classificação de Padrões
% *************************************************************************
%
clear all;
close all;
clc;
%
addpath C:\classificadorKNN\prt % Indicando diretorio das bibliotecas utilizadas
prtPath; % Inicializando funções
%
%
baseConhecimento = prtDataGenIris; % Carregando dados da flor Iris
baseConhecimento = baseConhecimento.retainFeatures(1:3); % Filtrando 3 dimensões dos dados obtidos para melhor vizualização
%
 baseAmostragem = prtPreProcPca;  % Criando objeto para comportar os valores dos dados processados
 baseAmostragem.nComponents = 2;  % Setando para 2 os componentes a serem utilizados na analise
%
 baseTreino = baseAmostragem.train(baseConhecimento); % criando a base de treino a partir da base de conhecimento
 resultado = baseTreino.run(baseConhecimento);
 classificadorKnn = prtClassKnn; % criando o classificador knn
 classificadorKnn = classificadorKnn.train(resultado); % rodando o algoritmo classificador
%
% Resultados
figure(1); plot(baseConhecimento); % representação dos dados originais em 3 dimensões
figure(2); plot(resultado); % representação dos dados de treinamento
figure(3); plot(classificadorKnn); % representação do algoritmo classificador
%explore(baseConhecimento);
%
% Validando o algoritmo classificador
fatorValidacao = resultado.getTargets; % classes conhecidas
validacaoCruzada = classificadorKnn.kfolds(resultado,10); % dividindo a base de treinamento em 10 subconjuntos para validar a acuracia do algoritmo classificador
[contadorK,classesInferencia] = max(validacaoCruzada.getObservations,[],2);
figure(4); prtScoreConfusionMatrix(classesInferencia,fatorValidacao,resultado.uniqueClasses,resultado.getClassNames);
%