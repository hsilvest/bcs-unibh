/**
 * 
 */
package trabalho.pratico.grafos.auxiliar;

import java.awt.Color;
import java.awt.Paint;
import java.util.Collection;
import java.util.HashSet;

import org.apache.commons.collections15.Transformer;

/**
 * @author Marcos Muniz
 * 
 */
public class TransformaLinhaArestas implements Transformer<String, Paint> {
	private Collection<String> arestasColoridas = new HashSet<String>();
	@Override
	public Paint transform(String aresta) {
		if (arestasColoridas != null && arestasColoridas.contains(aresta)) {
			return Color.RED;
		}
		return Color.BLUE;
	}
	public TransformaLinhaArestas(Collection<String> arestasColoridas) {
		super();
		this.arestasColoridas = arestasColoridas;
	}
	public Collection<String> getArestasColoridas() {
		return arestasColoridas;
	}
	public void setArestasColoridas(Collection<String> arestasColoridas) {
		this.arestasColoridas = arestasColoridas;
	}
	
	
	
}
