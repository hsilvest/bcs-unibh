package unibh.tclf.tp2;
import java.util.ArrayList;
import java.util.Collection;

public abstract class Lexan {
	
	public static int numLine = 0;
	
	private static int state = 0, i = 0 ; 
	
	private static String simbolo, word="";
	
	private static String simbolosOp = "[+-/*=//]";
	
	private static String simbolosID = "[a-zA-Z_]";
	
	private static String simbolosNInt = "[0-9]";
	
	private static String simboloString = "\"";
	
	private static String simbolosParenteses = "[()]";
	
	private static String simboloPontoVirgula = ";";
	
	private static final String simboloInvalidos="[#~@?!\\%¨º,&|]"; 
	
	
	private static final String tokenID = "ID";
	
	private static final String tokenNReal = "nreal";
	
	private static final String tokenNInt = "nint";
	
	private static final String tokenNString = "nstring";
	
	private static final String tokenOp = "op";
	
	private static final String tokenParenteses = "par";
	
	private static final String tokenPontoVirgula = "pv";
	
	
	private static Collection<Token> tokensss = new ArrayList<Token>();
	
	public static Collection<Token> getTokensCollection(String fileRow){
		tokensss.clear();
		getTokens(fileRow);
		return tokensss;
	} 
	
	private static void getTokens(String linha){
		for (i=0;i < linha.length();i++) {
    		simbolo = Character.toString((char)linha.charAt(i));
    		if (!simbolo.matches("\\s") && !simbolo.equals(simboloPontoVirgula)) word += simbolo;
    		switch (state) {
    			case 0:
    		        if (simbolo.matches("\\s")) {
    		        	state = 0; 
    		        	word = "";
    		        } else if (simbolo.matches(simboloInvalidos)) {
		        		printMSG("Caracter inválido (" + simbolo + ")");
    				} else if(simbolo.matches(simbolosID)) {
                        state = 1; 
    				} else if (simbolo.matches(simbolosOp)) {
                        state = 3; 
    				} else if (simbolo.matches(simbolosNInt)) {
						state = 4; 
    				} else if (simbolo.equals(simboloString)) {
    					state = 6; 
    				} else if (simbolo.matches(simbolosParenteses)) {
    					printToken(tokenParenteses);
    				} else if (simbolo.equals(simboloPontoVirgula)) {
    					state = 8;
    				}
    		        break;
    			case 1:
                	if (simbolo.matches(simbolosID)) {
                        state = 1;
                	} else if(simbolo.matches(simbolosOp)) {
                		word = word.substring(0, word.length()-1);
                		forwardPrint(tokenID);
                	} else {
                		printToken(tokenID);
                	}
                	break;
    			case 3:
    				forwardPrint(tokenOp);
    				break;
    			case 4:
    				if (simbolo.equals(".")) {
    					state = 5; 
    				} else if (!simbolo.matches(simbolosNInt)) {
    					forwardPrint(tokenNInt);
    				}
    				break;
    			case 5:
    				if (!simbolo.matches(simbolosNInt)) {
    					if (!word.matches("[0-9]+\\.[0-9]+")){
    						printMSG("erro de um numero real ");
    					} else {
    						forwardPrint(tokenNReal);
    					}
    				}
    				break;
    			case 6:
    				if (simbolo.equals(simboloString))	{
    					printToken(tokenNString);
    				} else if (i == linha.length() -1) {
    					printMSG("caracter(\") nao encontrato ");
    				} 
    				break;
    			case 8:
    				forwardPrint(tokenPontoVirgula);
    				word = "";
    				break;
    				
			default:
				break;
			}
		}
	}


	private static void printToken (String token)  {
		tokensss.add(new Token(token, word,numLine));
		state = 0;
		word = "";

	}

	private static void forwardPrint (String token)  {
		printToken(token);
		i --;
	}
	
	private static void printMSG(String msg) {
		System.out.println("erro" + msg);
		throw new RuntimeException();
	}
	
	

}
