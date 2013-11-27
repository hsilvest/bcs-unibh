package trabalho.pratico.grafos.auxiliar;

import java.awt.Shape;
import java.awt.geom.Ellipse2D;

import org.apache.commons.collections15.Transformer;

public class TransformaFormaVertices implements Transformer<String, Shape> {

	@Override
	public Shape transform(String vertice) {
		return new Ellipse2D.Float(-25, -15, 50, 30);
//		return new Rectangle(-25, -15, 50, 30);
	}

}
