public class ContadorBean {
	
	private String nomeproc;
	private int contador;
	
	public String getNomeproc() {
		return nomeproc;
	}
	public void setNomeproc(String nomeproc) {
		this.nomeproc = nomeproc;
	}
	public int getContador() {
		return contador;
	}
	public void setContador(int contador) {
		this.contador = contador;
	}
	public void contar(){
		contador = nomeproc.length();
	}

}
