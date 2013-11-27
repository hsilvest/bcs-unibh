% Limpando a área de trabalho do Matlab, limpando variáveis e fechando janelas
clc
clear all
close all

[imagem,mapa] = imread('lena.jpg');
separaBandas(imagem);

figure; % Permite abrir nova janela sem sobrepor a atual

exibeImagem(imagem, mapa); % Exibindo imagem original

figure; % Permite abrir nova janela sem sobrepor a atual

fprintf ('Aplicando Filtro Passa-Baixa da Media:\n\n');
mascara = (1/9) * [1  1  1
                   1  1  1
                   1  1  1];
for i = 1 : 3
    resultado(:,:,i) = filtroLinear(imagem(:,:,i), mascara);
end
exibeImagem(resultado, mapa); % Exibindo imagem depois do filtro da média

figure; % Permite abrir nova janela sem sobrepor a atual

fprintf ('Aplicando Filtro de Detector de Linha Horizontal:\n\n');
mascara = [-1 -1 -1
            2  2  2
           -1 -1 -1];
for i = 1 : 3
    resultado(:,:,i) = filtroLinear(imagem(:,:,i), mascara);
end
exibeImagem(resultado, mapa); % Exibindo imagem depois do filtro de detector de linha horizontal

% Prossiga com o seu código a partir daqui
