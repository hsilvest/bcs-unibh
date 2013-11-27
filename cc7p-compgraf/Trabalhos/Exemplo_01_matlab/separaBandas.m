function separaBandas(img)

    % Número de valores em escala de cinza:
    N = 256;
    
    img = uint8(img);

    subplot(2,2,1);
    image(img)
    axis image
    
    title('Decomposição de Imagem RGB');
    listaCores = { 'Red' 'Green' 'Blue' };
    
    % Vetor-coluna de escalas de cinza  %   Normalização [ 0 .. 1 ]
    gr = 0 : 1/(N-1) : 1;               %   Incremento 1/(N-1)
      
    % Abre cada um dos três componentes de cor:
    for k = 1:3
        % Mapa de cores:
        cMap = zeros(N,3);
        cMap(:,k) = gr';
        
        % Abre a imagem da respectiva banda de cor k:
        subplot(2,2,k+1);
        image(ind2rgb(img(:,:,k),cMap));
        axis image
        title(listaCores{k});
    end
end
