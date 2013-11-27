%%   Dayanne Gouveia Coelho
%	UNIBH - Departamento de Ciencias Exatas e Tecnológicas
%	e-mail: dayanne.coelho@prof.unibh.br  
%   Substituição Retroativa
%% 

function x = SubRetroativa(n, a, b)

vet(n) = b(n) / a(n,n);

for k = 1:n-1
   sum = b(n-k);
   for j = n-k+1:n
     sum = sum - a(n-k,j) * vet(j);
   end
   vet(n-k) = sum / a(n-k,n-k);
end

x = vet';