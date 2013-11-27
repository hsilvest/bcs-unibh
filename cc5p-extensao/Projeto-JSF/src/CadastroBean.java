import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class CadastroBean {
	
	private Usuario usuario;
	private List<Cidade> cidades = new ArrayList<Cidade>();
	private ArrayList<Usuario> cadastros = new ArrayList<Usuario>();
		
	public ArrayList<Usuario> getCadastros() {
		return cadastros;
	}

	public void setCadastros(ArrayList<Usuario> cadastros) {
		this.cadastros = cadastros;
	}

	public CadastroBean() {
		cidades.add(new Cidade("Belo Horizonte", 200));
		cidades.add(new Cidade("São Paulo", 100));
		usuario = new Usuario();
	}
	
	public Usuario getUsuario() {
		return usuario;
	}
	public void setUsuario(Usuario usuario) {
		this.usuario = usuario;
	}
	public List<Cidade> getCidade() {
		return cidades;
	}
	public void setCidade(List<Cidade> cidade) {
		this.cidades = cidade;
	}
	
	public Collection<Cidade> recuperaCidades(Object o){
		List<Cidade> listaCidades = new ArrayList<Cidade>();
		for(Cidade cidade : this.cidades){
			if(cidade.getNome().toLowerCase().startsWith(o.toString().toLowerCase())) listaCidades.add(cidade);
		}
		return listaCidades;
	}
	
	public void salvar(){
		cadastros.add(usuario);
		usuario = new Usuario();
	}
	
	
	
	
	
	
	
}
