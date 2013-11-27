%%   Dayanne Gouveia Coelho
%	UNIBH - Departamento de Ciencias Exatas e Tecnológicas
%	e-mail: dayanne.coelho@prof.unibh.br  
%%
%=================== Aula 2 ==================== %
clear all; clc;
%format short  % 4 casas decimais
format bank   % 2 casas decimais 

%==== Procedimento para resolver sistemas lineares ====%
% Exemplo de como entrar com os valores:
% Entrada do algoritmo:

%===== Exemplo 1: ======%
%A = [10 2 3; 0 4.8 0.7; 0 0 9.02];  % matriz A dos sistema
%b = [7;-8;6];     % matriz b ou vetor das constantes.
n = 3;  %dimensão da matriz

%===== Exemplo 2: ======%
A=[10 2 3; 1 5 1; 2 3 10]; 
b = [ 7;-8;6];
%% ====== Substituição Retroativa ===== %% 

%disp('Resolução do sistema triangular superior pelo método de substituição Retroativa');
%x = SubRetroativa(n,A,b)


%% ====== Metodo Direto: Eliminação de Gauss ===== %% 
disp('Resolução pelo método de Eliminação de Gauss');

x = EliminacaoGauss(A,b,n)

%% ====== Método Iterativo: Método de Jacobi ===== %% 
% Valores de Entrada:
 x0 = [0;0;0];    % solução inicial
 eps=0.001;       % erro esperado
 IterMax = 10;       % Numero máximo de iterações
% Saida do algoritmo:
% Tabela          (Tabela com todas as soluções e os errros) 
%   X             (Solução Final do sistema)
%   R             (Resíduo)
[tabela, X, R] = jacobi(A,b,x0,eps,IterMax)
