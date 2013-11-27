
public class Cidade {
	
	private String nome;
	private int populacao;
	
		
	public Cidade(String nome, int populacao) {
		super();
		this.nome = nome;
		this.populacao = populacao;
	}
	
	public String getNome() {
		return nome;
	}
	public void setNome(String nome) {
		this.nome = nome;
	}
	public int getPopulacao() {
		return populacao;
	}
	public void setPopulacao(int populacao) {
		this.populacao = populacao;
	}
	
	
}
