package trabalho.pratico.grafos.auxiliar;

import java.awt.Font;

import org.apache.commons.collections15.Transformer;

public class TransformaFonteVertices implements Transformer<String,Font>{

	@Override
	public Font transform(String vertice) {
		return new Font("Serif", Font.PLAIN, 18);
	}

}
