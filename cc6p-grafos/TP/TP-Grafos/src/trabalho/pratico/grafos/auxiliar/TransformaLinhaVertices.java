/**
 * 
 */
package trabalho.pratico.grafos.auxiliar;

import java.awt.BasicStroke;
import java.awt.Stroke;

import org.apache.commons.collections15.Transformer;

/**
 * @author Marcos Muniz
 *
 */
public class TransformaLinhaVertices implements Transformer<String, Stroke>{

	@Override
	public Stroke transform(String arg0) {
		return new BasicStroke(3f);
	}

}
