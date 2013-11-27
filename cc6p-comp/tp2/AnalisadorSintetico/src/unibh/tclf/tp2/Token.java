package unibh.tclf.tp2;

public class Token {

	private String type;
	private String valor;
	private int numLine;
	
	public Token(String type, String valor, int numLine) {
		this.type = type;
		this.valor = valor;
		this.numLine = numLine;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getValor() {
		return valor;
	}

	public void setValor(String valor) {
		this.valor = valor;
	}
	
	public int getNumLine() {
		return numLine;
	}

	public void setnumLine(int numLine) {
		this.numLine = numLine;
	}

}
