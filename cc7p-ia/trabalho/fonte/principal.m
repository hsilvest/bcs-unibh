%Project: POC
%Author:Henrique Silvestre
%-----------------------------

addpatch C:\Users\Henrique\Dropbox\Faculdade\7º Periodo\IA\trabalho\fonte\newfolder-PRT-41facae
prtPath;

%imagens para serem utilizadas no conjunto de treinamento
red = imread('images/red.jpg');
green = imread('images/green.jpg');
blue = imread('images/blue.jpg');

%imagens para serem utilizadas no conjunto de amostras a serem analisadas
pink = imread('images/pink.jpg');
aqua = imread('images/aqua.jpg');
light_green = imread('images/light_green.jpg');


%chapar as cores em uma banda
red = red(:,);
green = green(:,:);
blue = blue(:,:);
pink = pink(:,:);
aqua = aqua(:,:);
light_green = light_green(:,:);

%atribuicao do conjunto de treinamento às imagens que ja estao
%classificadas (vermelha, verde e azul)
training = [red; green; blue];

%atribuicao do conjunto de amostra (imagens a serem analisadas pelo
%algoritmo para saber a qual classe pertencem
sample = [aqua; pink; light_green];

%group = [1,2,3];
tamLin = size(red,1);
group = [ones(tamLin,1); 2*ones(tamLin,1); 3*ones(tamLin,1)];

%chamada da funcao knn do matlab
knnclassify(sample, training, group)