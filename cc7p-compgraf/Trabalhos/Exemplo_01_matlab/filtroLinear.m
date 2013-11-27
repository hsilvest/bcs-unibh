function gf = filtroLinear(g,h)    
    % g = imagem
    % h = mascara
    g = double(g); % Transformando a imagem em imagem double
    gf = g;

    Lint = fix(size(h,1)/2); % Quantidade de linhas
    Pint = fix(size(h,2)/2); % Quantidade de colunas / pixels por linha
    % Linhas
    for l = Lint+1 : size(g,1)-Lint % Pegando da segunda linha até a penúltima (excluindo bordas)
        % Pixels
        for p = Pint+1 : size(g,2)-Pint % Pegando da segunda coluna até a penúltima (excluindo bordas)
            % Extração da subimagem (parte da imagem sob a máscara de convolução
            gj = g(l - Lint:l+Lint, p-Pint:p+Pint);
            % Convolução entre a subimagem e a mascara
            gf (l,p) = sum(sum(gj .* h)); % Somatório dos produtos entre o pixel e o respectivo valor da máscara
        end
    end
    
    gf = uint8(gf); % Voltando a imagem double para int
end
