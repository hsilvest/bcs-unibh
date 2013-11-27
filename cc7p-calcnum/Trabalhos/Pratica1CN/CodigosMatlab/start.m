%%   Dayanne Gouveia Coelho
%	UNIBH - Departamento de Ciencias Exatas e Tecnológicas
%	e-mail: dayanne.coelho@prof.unibh.br  
%%
%=============================================== %
%=================== Aula 1 ==================== %
clear all; clc;
format short  % 4 casas decimais
%format bank   % 2 casas decimais 
%==== Procedimento para  localizar os zeros da função ====% 
xmim = -5; xmax = 5;
ymim= -12; ymax = 12;
figure(1), fplot('funcao',[xmim,xmax,ymim,ymax]), grid

title('Localização Gráfica dos Zeros da funcao f(x)')
xlabel('f(x)  =  x^3 - 9x+3')

%% ====== Métodos de Resolução para obter a raiz do sistema ===== %% 
%% Método da Bisseção:
% Variáveis de entrada:
a = 0;
b =  1;
epsilon = 0.01;
iterMax = 10;

result_cordas = bissecao('funcao',a,b,epsilon, iterMax)
