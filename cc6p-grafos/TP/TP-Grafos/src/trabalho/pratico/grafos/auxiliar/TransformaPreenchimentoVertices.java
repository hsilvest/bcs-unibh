/**
 * 
 */
package trabalho.pratico.grafos.auxiliar;

import java.awt.Color;
import java.awt.Paint;

import org.apache.commons.collections15.Transformer;

/**
 * @author Marcos Muniz
 *
 */
public class TransformaPreenchimentoVertices implements Transformer<String, Paint>{

	@Override
	public Paint transform(String arg0) {
		return Color.gray;
	}

}
