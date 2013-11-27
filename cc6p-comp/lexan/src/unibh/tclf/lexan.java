package unibh.tclf;


import java.io.FileReader;
import java.io.BufferedReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;

public class lexan {
	
	/** TRABALHO PRATICO TCLF 
	 * 
	 *  @author Henrique Silvestre Souza
	 *  @author Leonardo Henrique
	 *  @author Lucas Sampaio
	 *  
	 *  INSTRUÇÕES PARA A EXECUÇÃO DO PROJETO:
	 *  
	 *  Dentro do diretorio do projeto existe um arquivo chamado "input.txt"
	 *  Este é o arquivo de entrada, onde deverão ser colocados as strings para
	 *  os testes.
	 *  
	 *  O resultado vai ser apresentado através de um segundo arquvio "output.txt"
	 *  Que também esta no diretorio do projeto
	 *  
	 *  ATENÇÃO: O ARQUIVO DE TESTE OBRIGATORIAMENTE DEVE SE CHAMAR "INPUT.TXT"
	 *  E DEVE ESTAR NA PASTA RAIZ DO PROJETO, CASO CONTRARIO VAI ABENDAR
	 *  
	 *      	OS ESTADOS DO AFD ESTÃO MAPEADOS DA SEGUINTE MANEIRA:
	 *  
                        ESTADO 0 :  ESTADO INICIAL
                        
                        ESTADO 1 :  TRANSIÇÃO DE ID's
 
                        ESTADO 2 :  TRANSIÇÃO DE OPERADORES

						ESTADO 3:   TRANSIÇÃO DE INTEIROS

    					ESTADO 4:   TRANSIÇÃO DE STRING
    					
    					ESTADO 5:   TRANSIÇÃO DE REAL
	 */
	
	
	/* Expressões regulares suportadas pela implementação */
	private static String patternOP = "[+-/*=//]";
	private static String patternID = "[a-zA-Z_]";
	private static String patternINT = "[0-9]";
	private static String patternString = "\"";
	/* Variáveis auxiliares */
	private static int currentState = 0;
	private static int i = 0 ;
	private static String symbol;
	private static String word = "";

	
	public static void main(String[] args) throws IOException {
		
		/* Instancia o classe para gravar no arquivo */
		PrintWriter writerTokens = new PrintWriter(new FileWriter("./src/output.txt"));
		StringBuffer tokenPrint = new StringBuffer();
		
		String line;
		
		/* Instancia o classe para ler o arquivo */
        BufferedReader bf = new BufferedReader(new FileReader("./src/input.txt"));
       

        /* Leitura das lines do objeto buffer instanciado */
        	while ((line = bf.readLine()) != null) { line = line + " ";
        		processTokens(line, tokenPrint);
        		
    		}
        		writerTokens.println(String.valueOf(tokenPrint.toString()));
				bf.close();
				writerTokens.close();
				System.out.println(" * * Arquivo de Saida Gerado com Sucesso * * ");
			
			}
	/* Metodo que percorre cada char dentro da line lida no buffer */
	public static void processTokens(String line, StringBuffer tokenPrint){
		
		for(i = 0;i < line.length(); i++) {
    		symbol = Character.toString(line.charAt(i));
    		if (!symbol.matches("\\s")) {
    			word = word + symbol;
    			}
    		
    		/* Implementação do AFD com as transições de cada estado */
    		switch (currentState) {
    		
    		/* Se o primeiro caracter lido for branco continua no estado 0 */ 
    			case 0:
    		        if (symbol.matches("\\s")) {
    		        	currentState = 0;
    		        	word = "";
    				} 
    		        /* Mudança dos estados paseados na comparação das regexp */
    		        else if (symbol.matches (patternID))	currentState = 1; 
    				else if (symbol.matches(patternOP))		currentState = 2;
    				else if (symbol.matches(patternINT))	currentState = 3;
    				else if (symbol.equals (patternString))	currentState = 4;
    		        break;
    			case 1:
                	if (symbol.matches(patternID))			currentState = 1;	
                	else {
                		tokenPrint.append("ID ");
                		currentState = 0;
                		}
                	break;
    			case 2:
    				//alem de escrever o token volta 1 posição na leitura de char
    				tokenPrint.append("op ");
    				i--; 
    				currentState = 0;
    				break;
    			case 3:
    				if (symbol.equals("."))					currentState = 5;
    				else if (!symbol.matches(patternINT)) {
    				//alem de escrever o token volta 1 posição na leitura de char
    					tokenPrint.append("nint ");
    					i--; 
    					currentState = 0;
    				}
    				break;
    			case 4:
    				if (symbol.equals(patternString))	{
    					tokenPrint.append("nstring ");
    					currentState = 0;
    				} else if (i == line.length() -1) {
    					tokenPrint.append("Erro de String ");
    				} 
    				break;
    			case 5:
    				if (!symbol.matches(patternINT)) {
    					if (!word.matches("[0-9]+\\.[0-9]*")){
    						tokenPrint.append("Erro de nreal ");
    					} else {
    						tokenPrint.append("nreal ");
    						currentState = 0;
    						i--;
    					}
    				}
    				break;
			default:
				break;
			}
		}
	}
}
	
