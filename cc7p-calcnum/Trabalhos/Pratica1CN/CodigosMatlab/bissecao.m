%   Dayanne Gouveia Coelho
%	UNIBH - Departamento de Ciencias Exatas e Tecnológicas
%	e-mail: dayanne.coelho@prof.unibh.br

%funcao do metodo de bisseção
function  result_cordas = bissecao(fname,a,b,epsilon, IterMax)

   fa = feval(fname,a);
   fb = feval(fname,b); 
   iter = 1;
   erro = 1000;
   result_cordas=[0 0 0 0 0];
   
  while ( (erro >  epsilon)  && (iter < IterMax) )
     x  = a - (fa*(b-a))/(fb-fa);
     fx = feval(fname,x); 
     result_cordas(iter+1,:) = [a,b,x,fx,erro];
     if ( (fx*fa) < 0.0 )
        b = x;
        fb = fx; 
     else
         a = x;
         fa = fx;
     end
     erro = abs(result_cordas(iter+1,3) - result_cordas(iter,3) );
     iter = iter + 1;
  end
  
   
