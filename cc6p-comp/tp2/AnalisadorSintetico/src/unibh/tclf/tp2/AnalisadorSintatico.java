package unibh.tclf.tp2;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;

/** TRABALHO PRATICO TCLF 
 * 
 *  @author Henrique Silvestre Souza
 *  @author Leonardo Henrique
 *  @author Lucas Sampaio
 *  @author Larissa Casas
 *  
 *  INSTRUÇÕES PARA A EXECUÇÃO DO PROJETO:
 *  
 *  Dentro do diretorio do projeto existe um arquivo chamado "input.txt"
 *  Este é o arquivo de entrada, onde deverão ser colocados as strings para
 *  os testes.
 *  
 *  O resultado vai ser apresentado através do console
 *  
 *  ATENÇÃO: O ARQUIVO DE TESTE OBRIGATORIAMENTE DEVE SE CHAMAR "INPUT.TXT"
 *  E DEVE ESTAR NA PASTA RAIZ DO PROJETO, CASO CONTRARIO VAI ABENDAR
 *  
 *  REALIZEI ALGUNS TESTES, SEGUEM ABAIXO. !!LEMBRAR DE TROCAR O CONTEUDO DO ARQUIVO INPUT.TXT"
 *  
 *  Erro de Parenteses:
 *	a = (b + c + d
 *
 *  Erro de Caracter Invalido:
 *  a = b + c # d
 *
 *  Erro de Atrib
 *  a = 4.2; b = a;
 *
 *  Erro de Variaveis
 *  1 = 10+15
 *  
 */

public class AnalisadorSintatico {

	static BufferedWriter bw;
	
	static File file;

	private static Token currentToken;
	
	static Collection<Token> tokens = null;

	String result = "";
	
	private static int i = 0;

	static ArrayList<Token> tokenArr = null;
	
	private static void varCattrib() {

		Token aux;
		

			if (currentToken.getType().equals("ID")
					|| currentToken.getType().equals("nint")
					|| currentToken.getType().equals("nreal")) {

				aux = currentToken;
				nextToken();
				if (!currentToken.getType().equals("op")) {
					printError("erro, era esperado um OP");
				} else if (!aux.getType().equals("ID")
						&& currentToken.getValor().equals("=")) {
					printError("erro, operador de Atribuicao nao esperado");
				} else {
					nextToken();
					varAtrib();

					aux = currentToken;
					nextToken();
					if (aux.getType().equals("pv")
							&& currentToken.getType().equals("stop")) {
						printError("sem Atribuicoes a serem feitas.");
					}
				}
				if (aux.getType().equals("pv")) {
					// nextToken();
					varCattrib();

				}

			} else {
				printError("erro, esperado um real, int ou ID");
			}
	}

	private static void varAtrib() {
		varE();
	}

	private static void varE() {
		varT();
		varX();
	}

	private static void varX() {
		if (currentToken.getValor().equals("+")
				|| currentToken.getValor().equals("-")) {
			nextToken();
			varT();
			varX();
		}
	}

	private static void varT() {
		varF();
		varY();
	}

	private static void varY() {
		if (currentToken.getValor().equals("*")
				|| currentToken.getValor().equals("/")) {
			nextToken();
			varF();
			varY();
		}
	}

	private static void varF() {
		if (currentToken.getType().equals("par")) {
			if (currentToken.getValor().equals("(")) {
				nextToken();
				varE();
				if (!currentToken.getValor().equals(")"))
					printError("erro, esperado ')'");
			}
		} else if (!currentToken.getType().equals("nreal")
				&& currentToken.getType().equals("nint")
				&& currentToken.getType().equals("nstring")) {
			System.out.println();
		} else {
			nextToken();
		}

	}

	public static void main(String[] args) throws IOException {

		String line;

		BufferedReader bf = new BufferedReader(
				new FileReader("./src/input.txt"));

		Lexan.numLine = 0;

		while ((line = bf.readLine()) != null) {
			line = line + " ";
			Lexan.numLine += 1;
			tokens = null;
			tokenArr = null;
			tokens = Lexan.getTokensCollection(line);
			i = 0;
			nextToken();
			if (currentToken != null)
				varCattrib();
		}

		System.out.println("arquivo processado e reconhecido");
	}

	private static void printError(String msg) {
		System.out.println(msg + " (linha " + currentToken.getNumLine()
				+ ")\n");
		throw new RuntimeException();
	}

	private static void nextToken() {
		if (tokenArr == null) {
			tokenArr = new ArrayList<Token>();
			for (Token token : tokens) {
				tokenArr.add(token);
			}
		}
		if (i <= tokenArr.size() - 1) {
			currentToken = tokenArr.get(i);
			i += 1;
		} else
			currentToken = new Token("stop", "#", Lexan.numLine);
	}
	
	

}
